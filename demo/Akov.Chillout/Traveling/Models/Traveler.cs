namespace Akov.Chillout.Traveling.Models;

/// <summary>
/// The traveler.
/// </summary>
/// <param name="FirstName">The traveler first name.</param>
/// <param name="LastName">The traveler last name.</param>
public record Traveler(
    string FirstName,
    string LastName)
{
    /// <summary>
    /// Specifies whether a traveler can fly.
    /// </summary>
    public bool CanFly { get; set; }
}