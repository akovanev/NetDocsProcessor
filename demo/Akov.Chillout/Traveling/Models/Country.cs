namespace Akov.Chillout.Traveling.Models;

/// <summary>
/// The country.
/// </summary>
public class Country
{
    /// <summary>
    /// Creates a new country.
    /// </summary>
    /// <param name="name">The country name.</param>
    /// <param name="countryType">The country type.</param>
    public Country(string name, CountryType countryType)
    {
        Name = name;
        CountryType = countryType;
    }

    /// <summary>
    /// The country name.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// The country type.
    /// </summary>
    public CountryType CountryType { get; private set; }

    /// <summary>
    /// Change the dangerous level for the country type.
    /// </summary>
    /// <param name="countryType"></param>
    internal void ChangeCountryType(CountryType countryType) => CountryType = countryType;
}