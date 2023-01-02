﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationSystem.Data.Matches;
using ReservationSystem.DataStructures.Matches;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.APIs.Controllers;

/// <summary>
/// Provides methods for matches.
/// </summary>
[ApiController]
[Route("api/matches")]
public class MatchesController : BaseController<MatchesController>
{
    private readonly IMatchRepository _matchRepository;
    private readonly IStadiumRepository _stadiumRepository;

    /// <summary>
    /// Creates a new instance of the <see cref="MatchesController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="matchRepository">The match repository.</param>
    /// <param name="stadiumRepository">The stadium repository.</param>
    public MatchesController(
        ILogger<MatchesController> logger,
        IMatchRepository matchRepository,
        IStadiumRepository stadiumRepository) : base(logger)
    {
        _matchRepository = matchRepository;
        _stadiumRepository = stadiumRepository;
    }

    /// <summary>
    /// Gets a list of matches.
    /// </summary>
    /// <response code="200">Returns a list of <see cref="MatchInfo"/> items.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MatchInfo>), StatusCodes.Status200OK)]
    public IActionResult GetMatches()
    {
        _logger.LogInformation($"Call to {nameof(MatchesController)}.{nameof(GetMatches)}");

        var matches = _matchRepository.Get();

        return Ok(matches);
    }

    /// <summary>
    /// Gets a match by id.
    /// </summary>
    /// <param name="matchId">The id of the match.</param>
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
    /// Gets the nearest upcoming match.
    /// </summary>
    /// <response code="200">Returns a <see cref="MatchDetailedInfo"/> item.</response>
    /// <response code="404">If no upcoming matces.</response>
    [HttpGet("next")]
    [ProducesResponseType(typeof(MatchDetailedInfo), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNext()
    {
        _logger.LogInformation($"Call to {nameof(MatchesController)}.{nameof(GetNext)}");

        var match = await _matchRepository.GetNextAsync().ConfigureAwait(false);
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

        try
        {
            var match = await CreateMatch(matchPayload).ConfigureAwait(false);
            await _matchRepository.AddAsync(match).ConfigureAwait(false);

            return CreatedAtAction(nameof(GetMatch), new { matchId = match.Id }, new MatchDetailedInfo(match));
        }
        catch (Exception e)
        {
            return BadRequest("InvalidMatch", e.Message);
        }
    }

    /// <summary>
    /// Updates a match.
    /// </summary>
    /// <param name="matchId">The id of the match.</param>
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

        try
        {
            await UpdateMatchHelper(match, matchPayload).ConfigureAwait(false);
            await _matchRepository.UpdateAsync(match).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return BadRequest("InvalidMatch", e.Message);
        }

        return NoContent();
    }

    private async Task<Match> CreateMatch(MatchPayload matchPayload)
    {
        var stadium = await _stadiumRepository.FindAsync(matchPayload.Stadium).ConfigureAwait(false);
        if (stadium is null)
        {
            throw new Exception($"Stadium {matchPayload.Stadium} does not exist.");
        }

        return new Match
        {
            HomeTeamName = matchPayload.HomeTeam,
            AwayTeamName = matchPayload.AwayTeam,
            StadiumName = matchPayload.Stadium,
            DateTime = matchPayload.Time,
            Referee = matchPayload.Referee,
            FirstLinesman = matchPayload.FirstLinesman,
            SecondLinesman = matchPayload.SecondLinesman,
            Stadium = stadium
        };
    }

    private async Task UpdateMatchHelper(Match match, MatchPayload matchPayload)
    {
        var stadium = await _stadiumRepository.FindAsync(matchPayload.Stadium).ConfigureAwait(false);
        if (stadium is null)
        {
            throw new Exception($"Stadium {matchPayload.Stadium} does not exist.");
        }

        if (match.Tickets!.Any(t => t.ReservationId is null && (t.Row > stadium.Rows || t.Column > stadium.Columns)))
        {
            throw new Exception("Cannot change stadium of a match with sold tickets outside bounds of new stadium.");
        }

        match.HomeTeamName = matchPayload.HomeTeam;
        match.AwayTeamName = matchPayload.AwayTeam;
        match.StadiumName = matchPayload.Stadium;
        match.DateTime = matchPayload.Time;
        match.Referee = matchPayload.Referee;
        match.FirstLinesman = matchPayload.FirstLinesman;
        match.SecondLinesman = matchPayload.SecondLinesman;
        match.Stadium = stadium;
    }
}
