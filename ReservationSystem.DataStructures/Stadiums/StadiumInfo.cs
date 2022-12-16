using ReservationSystem.Data.Stadiums;

namespace ReservationSystem.DataStructures.Stadiums;

/// <summary>
/// Information about a stadium.
/// </summary>
public class StadiumInfo
{
    /// <summary>
    /// The stadium name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The stadium capacity.
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="StadiumInfo"/>.
    /// </summary>
    /// <param name="stadium">The stadium.</param>
    public StadiumInfo(Stadium stadium)
    {
        Name = stadium.Name;
        Capacity = stadium.Capacity;
    }
}
