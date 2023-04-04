namespace Akov.Chillout.Traveling.Models;

/// <summary>
/// The crazy traveler.
/// </summary>
/// <param name="FirstName">The firstname of the crazy traveler.</param>
/// <param name="LastName">The lastname of the crazy traveler.</param>
public record CrazyTraveler(string FirstName, string LastName) : Traveler(FirstName, LastName)
{
    /// <summary>
    /// The crazy level.
    /// </summary>
    public int CrazyLevel { get; set; }
}