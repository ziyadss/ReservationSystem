using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationSystem.DataStructures.Matches;
using ReservationSystem.DataStructures;
using ReservationSystem.DataStructures.Tickets;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationSystem.Repositories;

namespace ReservationSystem.APIs.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketsController : BaseController<TicketsController>
{
    private readonly ITicketRepository _ticketRepository;

    public TicketsController(ILogger<TicketsController> logger, ITicketRepository ticketRepository) : base(logger)
    {
        _ticketRepository = ticketRepository;
    }

    /// <summary>
    /// Gets the current user's tickets.
    /// </summary>
    /// <param name="skip">The index of the first match to return.</param>
    /// <param name="take">The maximum number of matches to return.</param>
    /// <response code="200">Returns a <see cref="PaginationResult{TElement}"/> of <see cref="TicketInfo"/> items.</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(PaginationResult<TicketInfo>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTickets([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        _logger.LogInformation($"Call to {nameof(TicketsController)}.{nameof(GetTickets)}");

        var userName = User.Identity!.Name!;

        var tickets = _ticketRepository.Get(userName, skip, take);
        var count = await _ticketRepository.CountAsync(userName).ConfigureAwait(false);

        var done = skip + take >= count;
        var next = done ? null : Url.ActionLink(values: new { skip = skip + take, take });

        var result = new PaginationResult<TicketInfo>
        {
            Items = tickets,
            Skip = skip,
            Take = take,
            Total = count,
            Next = next
        };

        return Ok(result);
    }

    /// <summary>
    /// Gets a ticket for a match.
    /// </summary>
    /// <param name="ticketNumber">The ticket number.</param>
    /// <response code="200">A <see cref="TicketInfo""/> object.</response>
    [HttpGet("{ticketNumber}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTicket([FromRoute] string ticketNumber)
    {
        _logger.LogInformation($"Call to {nameof(TicketsController)}.{nameof(GetTicket)}");

        if (string.IsNullOrWhiteSpace(ticketNumber))
        {
            return BadRequest("Ticket number is null or empty");
        }

        int matchId, row, column;
        try
        {
            (matchId, row, column) = ParseTicketNumber(ticketNumber);
        }
        catch (ArgumentException e) when (e.Message.StartsWith("Invalid ticket number"))
        {
            return BadRequest("InvalidTicketNumber", e.Message);
        }

        var ticket = await _ticketRepository.FindAsync(matchId, row, column).ConfigureAwait(false);
        if (ticket is null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    /// <summary>
    /// Books tickets for a match.
    /// </summary>
    /// <param name="ticketsPayload">The payload containing the seats to book.</param>
    /// <response code="200">Returns a list of booked <see cref="TicketBriefInfo"/> items.</response>
    [HttpPost("book")]
    [Authorize(Roles = "User")]
    [ProducesResponseType(typeof(IEnumerable<TicketBriefInfo>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ReserveTickets([FromBody] TicketsPayload ticketsPayload)
    {
        _logger.LogInformation($"Call to {nameof(MatchesController)}.{nameof(ReserveTickets)}");

        var userName = User.Identity!.Name!;

        List<(int, int, int)> tickets;
        try
        {
            tickets = ticketsPayload.TicketNumbers.Select(ParseTicketNumber).ToList();
        }
        catch (ArgumentException e) when (e.Message.StartsWith("Invalid ticket number"))
        {
            return BadRequest("InvalidTicketNumber", e.Message);
        }

        try
        {
            var result = await _ticketRepository.BookTickets(userName, tickets).ConfigureAwait(false);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest("InvalidBooking", e.Message);
        }
    }

    /// <summary>
    /// Cancels a ticket for a match.
    /// </summary>
    /// <param name="ticketNumber">The ticket number to cancel.</param>
    /// <response code="204">The ticket was cancelled.</response>
    [HttpPost("{ticketNumber}/cancel")]
    [Authorize(Roles = "User")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CancelTicket([FromRoute] string ticketNumber)
    {
        _logger.LogInformation($"Call to {nameof(MatchesController)}.{nameof(CancelTicket)}");

        var userName = User.Identity!.Name!;

        int matchId, row, column;
        try
        {
            (matchId, row, column) = ParseTicketNumber(ticketNumber);
        }
        catch (ArgumentException e) when (e.Message.StartsWith("Invalid ticket number"))
        {
            return BadRequest("InvalidTicketNumber", e.Message);
        }

        try
        {
            await _ticketRepository.CancelTicket(userName, matchId, row, column).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return BadRequest("InvalidBooking", e.Message);
        }

        return NoContent();
    }

    private static (int, int, int) ParseTicketNumber(string ticketNumber)
    {
        var parts = ticketNumber.Split('-');
        if (parts.Length != 3)
        {
            throw new ArgumentException($"Invalid ticket number {ticketNumber}.");
        }

        var matchId = int.Parse(parts[0]);
        var row = int.Parse(parts[1]);
        var column = int.Parse(parts[2]);

        return (matchId, row, column);
    }
}
