﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationSystem.Data.Stadiums;
using ReservationSystem.DataStructures;
using ReservationSystem.DataStructures.Stadiums;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ReservationSystem.APIs.Controllers;

[ApiController]
[Route("api/stadiums")]
public class StadiumsController : BaseController<StadiumsController>
{
    private readonly IStadiumRepository _stadiumRepository;

    public StadiumsController(ILogger<StadiumsController> logger, IStadiumRepository stadiumRepository) : base(logger)
    {
        _stadiumRepository = stadiumRepository;
    }

    /// <summary>
    /// Gets a list of stadiums.
    /// </summary>
    /// <param name="skip">The index of the first stadium to return.</param>
    /// <param name="take">The maximum number of stadiums to return.</param>
    /// <response code="200">Returns a <see cref="PaginationResult{TElement}"/> of <see cref="StadiumInfo"/> items.</response>
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<StadiumInfo>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStadiums([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        _logger.LogInformation($"Call to {nameof(StadiumsController)}.{nameof(GetStadiums)}");

        var stadiums = _stadiumRepository.Get(skip, take);
        var count = await _stadiumRepository.CountAsync().ConfigureAwait(false);

        var done = skip + take >= count;
        var next = done ? null : Url.ActionLink(values: new { skip = skip + take, take });

        var result = new PaginationResult<StadiumInfo>
        {
            Items = stadiums,
            Skip = skip,
            Take = take,
            Total = count,
            Next = next
        };

        return Ok(result);
    }

    /// <summary>
    /// Gets a stadium by name.
    /// </summary>
    /// <param name="name">The name of the stadium.</param>
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

        var stadium = CreateStadium(stadiumPayload);
        await _stadiumRepository.AddAsync(stadium).ConfigureAwait(false);

        return CreatedAtAction(nameof(GetStadium), new { name = stadium.Name }, new StadiumInfo(stadium));
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