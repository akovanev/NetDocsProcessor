using Akov.Chillout.Traveling.Models;

namespace Akov.Chillout.Traveling.Services;

/// <summary>
/// I would like to go...
/// </summary>
/// <typeparam name="TTraveler">Some traveler.</typeparam>
public interface IGoService<in TTraveler> where TTraveler : Traveler
{
    /// <summary>
    /// The interface method for adding to the visited list.
    /// Preferable for using.
    /// </summary>
    /// <param name="traveler">The traveler.</param>
    /// <param name="country">The country.</param>
    void AddCountryToVisitedList(TTraveler traveler, Country country);

    /// <summary>
    /// Test method.
    /// </summary>
    /// <param name="number">The number</param>
    void Test(int number);
}