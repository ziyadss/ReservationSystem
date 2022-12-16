using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationSystem.Data.Matches;
using ReservationSystem.DataStructures;
using ReservationSystem.DataStructures.Matches;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ReservationSystem.APIs.Controllers;

[ApiController]
[Route("api/matches")]
public class MatchesController : BaseController<MatchesController>
{
    private readonly IMatchRepository _matchRepository;

    public MatchesController(ILogger<MatchesController> logger, IMatchRepository matchRepository) : base(logger)
    {
        _matchRepository = matchRepository;
    }

    /// <summary>
    /// Gets a list of matches.
    /// </summary>
    /// <param name="skip">The index of the first match to return.</param>
    /// <param name="take">The maximum number of matches to return.</param>
    /// <response code="200">Returns a <see cref="PaginationResult{TElement}"/> of <see cref="MatchInfo"/> items.</response>
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<MatchInfo>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMatches([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        _logger.LogInformation($"Call to {nameof(MatchesController)}.{nameof(GetMatches)}");

        var matches = _matchRepository.Get(skip, take);
        var count = await _matchRepository.CountAsync().ConfigureAwait(false);

        var done = skip + take >= count;
        var next = done ? null : Url.ActionLink(values: new { skip = skip + take, take });

        var result = new PaginationResult<MatchInfo>
        {
            Items = matches,
            Skip = skip,
            Take = take,
            Total = count,
            Next = next
        };

        return Ok(result);
    }

    /// <summary>
    /// Gets a match by id.
    /// </summary>
    /// <param name="id">The id of the match.</param>
    /// <response code="200">Returns a <see cref="MatchDetailedInfo"/> item.</response>
    /// <response code="404">If the match is not found.</response>
    [HttpGet("{matchId}")]
    [ProducesResponseType(typeof(MatchDetailedInfo), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMatch([FromRoute] int matchId)
    {
        _logger.LogInformation($"Call to {nameof(MatchesController)}.{nameof(GetMatch)}");

        var match = await _matchRepository.GetAsync(matchId).ConfigureAwait(false);
        if (match is null)
        {
            return NotFound();
        }

        return Ok(match);
    }

    /// <summary>
    /// Adds a match.
    /// </summary>
    /// <param name="matchPayload">The payload containing the match information.</param>
    /// <response code="201">Returns the newly created <see cref="MatchDetailedInfo"/> item.</response>
    /// <response code="400">If the match payload is null.</response>
    [HttpPost]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(typeof(MatchDetailedInfo), StatusCodes.Status201Created)]
    public async Task<IActionResult> AddMatch([FromBody] MatchPayload matchPayload)
    {
        _logger.LogInformation($"Call to {nameof(MatchesController)}.{nameof(AddMatch)}");

        if (matchPayload is null)
        {
            return NullParameter(nameof(matchPayload));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.HomeTeam))
        {
            return NullParameter(nameof(matchPayload.HomeTeam));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.AwayTeam))
        {
            return NullParameter(nameof(matchPayload.AwayTeam));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.Stadium))
        {
            return NullParameter(nameof(matchPayload.Stadium));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.Referee))
        {
            return NullParameter(nameof(matchPayload.Referee));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.FirstLinesman))
        {
            return NullParameter(nameof(matchPayload.FirstLinesman));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.SecondLinesman))
        {
            return NullParameter(nameof(matchPayload.SecondLinesman));
        }

        if (matchPayload.HomeTeam == matchPayload.AwayTeam)
        {
            return InvalidParameter("Home team and away team cannot be the same.");
        }

        var match = CreateMatch(matchPayload);

        try
        {
            await _matchRepository.AddAsync(match).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return BadRequest("InvalidMatch", e.Message);
        }

        return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, new MatchDetailedInfo(match));
    }

    /// <summary>
    /// Updates a match.
    /// </summary>
    /// <param name="matchPayload">The payload containing the match information.</param>
    /// <response code="204">The match was updated.</response>
    /// <response code="400">If the match payload is null.</response>
    [HttpPut("{matchId}")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateMatch([FromRoute] int matchId, [FromBody] MatchPayload matchPayload)
    {
        _logger.LogInformation($"Call to {nameof(MatchesController)}.{nameof(UpdateMatch)}");

        if (matchPayload is null)
        {
            return NullParameter(nameof(matchPayload));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.HomeTeam))
        {
            return NullParameter(nameof(matchPayload.HomeTeam));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.AwayTeam))
        {
            return NullParameter(nameof(matchPayload.AwayTeam));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.Stadium))
        {
            return NullParameter(nameof(matchPayload.Stadium));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.Referee))
        {
            return NullParameter(nameof(matchPayload.Referee));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.FirstLinesman))
        {
            return NullParameter(nameof(matchPayload.FirstLinesman));
        }

        if (string.IsNullOrWhiteSpace(matchPayload.SecondLinesman))
        {
            return NullParameter(nameof(matchPayload.SecondLinesman));
        }

        if (matchPayload.HomeTeam == matchPayload.AwayTeam)
        {
            return InvalidParameter("Home team and away team cannot be the same.");
        }

        var match = await _matchRepository.FindAsync(matchId).ConfigureAwait(false);
        if (match is null)
        {
            return NotFound();
        }

        match.HomeTeamName = matchPayload.HomeTeam;
        match.AwayTeamName = matchPayload.AwayTeam;
        match.StadiumName = matchPayload.Stadium;
        match.DateTime = matchPayload.Time;
        match.Referee = matchPayload.Referee;
        match.FirstLinesman = matchPayload.FirstLinesman;
        match.SecondLinesman = matchPayload.SecondLinesman;

        try
        {
            await _matchRepository.UpdateAsync(match).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return BadRequest("InvalidMatch", e.Message);
        }

        return NoContent();
    }

    private static Match CreateMatch(MatchPayload matchPayload)
    {
        return new Match
        {
            HomeTeamName = matchPayload.HomeTeam,
            AwayTeamName = matchPayload.AwayTeam,
            StadiumName = matchPayload.Stadium,
            DateTime = matchPayload.Time,
            Referee = matchPayload.Referee,
            FirstLinesman = matchPayload.FirstLinesman,
            SecondLinesman = matchPayload.SecondLinesman
        };
    }
}
