namespace ReservationSystem.DataStructures.Stadiums;

/// <summary>
/// The payload for a stadium.
/// </summary>
public class StadiumPayload
{
    /// <summary>
    /// The stadium name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The stadium rows.
    /// </summary>
    public required int Rows { get; set; }

    /// <summary>
    /// The stadium columns.
    /// </summary>
    public required int Columns { get; set; }
}
