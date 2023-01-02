using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationSystem.DataStructures;
using ReservationSystem.DataStructures.Reservations;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.APIs.Controllers;

/// <summary>
/// Provides methods for reservations.
/// </summary>
[ApiController]
[Route("api/reservations")]
public class ReservationsController : BaseController<ReservationsController>
{
    private readonly IReservationRepository _reservationRepository;

    /// <summary>
    /// Creates a new instance of the <see cref="ReservationsController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="reservationRepository">The reservation repository.</param>
    public ReservationsController(ILogger<ReservationsController> logger, IReservationRepository reservationRepository) : base(logger)
    {
        _reservationRepository = reservationRepository;
    }

    /// <summary>
    /// Gets the current user's reservations.
    /// </summary>
    /// <param name="skip">The index of the first reservation to return.</param>
    /// <param name="take">The maximum number of reservation to return.</param>
    /// <response code="200">Returns a <see cref="PaginationResult{TElement}"/> of <see cref="ReservationInfo"/> items.</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(PaginationResult<ReservationInfo>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReservations([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        _logger.LogInformation($"Call to {nameof(ReservationsController)}.{nameof(GetReservations)}");

        var userName = User.Identity!.Name!;

        var reservations = _reservationRepository.Get(userName, skip, take);
        var count = await _reservationRepository.CountAsync(userName).ConfigureAwait(false);

        var done = skip + take >= count;
        var next = done ? null : Url.ActionLink(values: new { skip = skip + take, take });

        var result = new PaginationResult<ReservationInfo>
        {
            Items = reservations,
            Skip = skip,
            Take = take,
            Total = count,
            Next = next
        };

        return Ok(result);
    }

    /// <summary>
    /// Makes a reservation for tickets.
    /// </summary>
    /// <param name="ticketsPayload">The payload containing the seats to book.</param>
    /// <response code="200">Returns a <see cref="ReservationInfo"/> item.</response>
    [HttpPost("book")]
    [Authorize(Roles = "User")]
    [ProducesResponseType(typeof(ReservationInfo), StatusCodes.Status200OK)]
    public async Task<IActionResult> MakeReservation([FromBody] TicketsPayload ticketsPayload)
    {
        _logger.LogInformation($"Call to {nameof(ReservationsController)}.{nameof(MakeReservation)}");

        var userName = User.Identity!.Name!;

        IList<(int, int, int)> tickets;
        try
        {
            tickets = ParseTicketNumbers(ticketsPayload.TicketNumbers);

        }
        catch (ArgumentException e)
        when (e.Message.StartsWith("Invalid ticket number") || e.Message == "All tickets in a reservation must be for the same match.")
        {
            return BadRequest("InvalidBooking", e.Message);
        }

        try
        {
            var result = await _reservationRepository.BookTickets(userName, tickets).ConfigureAwait(false);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest("InvalidBooking", e.Message);
        }
    }

    /// <summary>
    /// Cancels a reservation.
    /// </summary>
    /// <param name="reservationId">The reservation id to cancel.</param>
    /// <response code="204">The ticket was cancelled.</response>
    [HttpPost("{reservationId}/cancel")]
    [Authorize(Roles = "User")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CancelReservation([FromRoute] int reservationId)
    {
        _logger.LogInformation($"Call to {nameof(ReservationsController)}.{nameof(CancelReservation)}");

        var userName = User.Identity!.Name!;

        try
        {
            await _reservationRepository.Cancel(userName, reservationId).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return BadRequest("InvalidBooking", e.Message);
        }

        return NoContent();
    }

    private static IList<(int, int, int)> ParseTicketNumbers(string[] ticketNumbers)
    {
        var tickets = ticketNumbers.Select(ticketNumber =>
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
        }).ToList();

        if (tickets.DistinctBy(t => t.matchId).Count() > 1)
        {
            throw new ArgumentException("All tickets in a reservation must be for the same match.");
        }

        return tickets;
    }
}
