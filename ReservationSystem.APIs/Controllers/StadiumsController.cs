using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationSystem.Data.Stadiums;
using ReservationSystem.DataStructures;
using ReservationSystem.DataStructures.Stadiums;
using ReservationSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.APIs.Controllers;

/// <summary>
/// Provides methods for retrieving stadiums.
/// </summary>
[ApiController]
[Route("api/stadiums")]
public class StadiumsController : BaseController<StadiumsController>
{
    private readonly IStadiumRepository _stadiumRepository;

    /// <summary>
    /// Creates a new instance of the <see cref="StadiumsController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="stadiumRepository">The stadium repository.</param>
    public StadiumsController(ILogger<StadiumsController> logger, IStadiumRepository stadiumRepository) : base(logger)
    {
        _stadiumRepository = stadiumRepository;
    }

    /// <summary>
    /// Gets a list of stadiums.
    /// </summary>
    /// <response code="200">Returns a list of <see cref="StadiumInfo"/> items.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StadiumInfo>), StatusCodes.Status200OK)]
    public IActionResult GetStadiums()
    {
        _logger.LogInformation($"Call to {nameof(StadiumsController)}.{nameof(GetStadiums)}");

        var stadiums = _stadiumRepository.Get();

        return Ok(stadiums);
    }

    /// <summary>
    /// Gets a stadium by name.
    /// </summary>
    /// <param name="stadiumName">The name of the stadium.</param>
    /// <response code="200">Returns a <see cref="StadiumDetailedInfo"/> item.</response>
    /// <response code="404">If the stadium is not found.</response>
    [HttpGet("{stadiumName}")]
    [ProducesResponseType(typeof(StadiumDetailedInfo), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStadium([FromRoute] string stadiumName)
    {
        _logger.LogInformation($"Call to {nameof(StadiumsController)}.{nameof(GetStadium)}");

        if (string.IsNullOrWhiteSpace(stadiumName))
        {
            return NullParameter(nameof(stadiumName));
        }

        var stadium = await _stadiumRepository.GetAsync(stadiumName).ConfigureAwait(false);
        if (stadium is null)
        {
            return NotFound();
        }

        return Ok(stadium);
    }

    /// <summary>
    /// Adds a new stadium.
    /// </summary>
    /// <param name="stadiumPayload">The payload of the stadium to add.</param>
    /// <response code="201">Returns the newly created stadium.</response>
    /// <response code="400">If the stadium payload is null or invalid.</response>
    [HttpPost]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(typeof(StadiumInfo), StatusCodes.Status201Created)]
    public async Task<IActionResult> AddStadium([FromBody] StadiumPayload stadiumPayload)
    {
        _logger.LogInformation($"Call to {nameof(StadiumsController)}.{nameof(AddStadium)}");

        if (stadiumPayload is null)
        {
            return NullParameter(nameof(stadiumPayload));
        }

        if (string.IsNullOrWhiteSpace(stadiumPayload.Name))
        {
            return NullParameter(nameof(stadiumPayload.Name));
        }

        if (stadiumPayload.Rows < 1)
        {
            return InvalidParameter("Stadium must have at least one row.");
        }

        if (stadiumPayload.Columns < 1)
        {
            return InvalidParameter("Stadium must have at least one column.");
        }

        var existingStadium = await _stadiumRepository.GetAsync(stadiumPayload.Name).ConfigureAwait(false);
        if (existingStadium is not null)
        {
            return InvalidParameter("Stadium with this name already exists.");
        }

        var stadium = CreateStadium(stadiumPayload);
        await _stadiumRepository.AddAsync(stadium).ConfigureAwait(false);

        return CreatedAtAction(nameof(GetStadium), new { stadiumName = stadium.Name }, new StadiumInfo(stadium));
    }

    private static Stadium CreateStadium(StadiumPayload stadiumPayload)
    {
        return new Stadium
        {
            Name = stadiumPayload.Name,
            Rows = stadiumPayload.Rows,
            Columns = stadiumPayload.Columns,
        };
    }
}
