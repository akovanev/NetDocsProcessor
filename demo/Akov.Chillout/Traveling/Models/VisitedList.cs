namespace Akov.Chillout.Traveling.Models;

/// <summary>
/// The list of visited countries.
/// </summary>
public class VisitedList
{
    private readonly Traveler _traveler;
    private readonly List<Country> _countries;

    /// <summary>
    /// Visited const.
    /// </summary>
    public const string Visited = "Visited";
    
    /// <summary>
    /// Visited static.
    /// </summary>
    public static string VisitedStatic = "VisitedStatic";
    
    /// <summary>
    /// Creates a new country.
    /// </summary>
    /// <param name="traveler"></param>
    public VisitedList(Traveler traveler)
    {
        _traveler = traveler;
        _countries = new List<Country>();
    }

    /// <summary>
    /// Get the visited countries list.
    /// </summary>
    /// <returns>The country list.</returns>
    public IReadOnlyCollection<Country> GetCountries() => _countries;

    /// <summary>
    /// Add a new country to the list.
    /// </summary>
    /// <param name="country">The country.</param>
    internal void AddCountry(Country country)
    {
        _countries.Add(country);
        OnAddCountry?.Invoke(country);
    }

    /// <summary>
    /// Execute when a new country was added.
    /// </summary>
    protected event AddCountryDelegate? OnAddCountry;
}
