using System.Text.Json.Serialization;

namespace ReservationSystem.Data.Users;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Unknown,
    Unspecified,
    Male,
    Female
}
