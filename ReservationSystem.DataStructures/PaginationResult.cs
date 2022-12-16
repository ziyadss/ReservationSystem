using System.Collections.Generic;

namespace ReservationSystem.DataStructures;

/// <summary>
/// A paginated result.
/// </summary>
/// <typeparam name="TElement">The type of the elements.</typeparam>
public class PaginationResult<TElement>
{
    /// <summary>
    /// The <typeparamref name="TElement"/> items.
    /// </summary>
    public required IEnumerable<TElement> Items { get; set; }

    /// <summary>
    /// The number of items skipped.
    /// </summary>
    public required int Skip { get; set; }

    /// <summary>
    /// The number of items taken.
    /// </summary>
    public required int Take { get; set; }

    /// <summary>
    /// The total number of items.
    /// </summary>
    public required int Total { get; set; }

    /// <summary>
    /// Link to the next page of results.
    /// </summary>
    public required string? Next { get; set; }
}
