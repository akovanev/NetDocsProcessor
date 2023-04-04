using Akov.Chillout.Traveling.Models;

namespace Akov.Chillout.Traveling.Services;

/// <summary>
/// Base implementation for GoService.
/// </summary>
/// <typeparam name="TTraveler">The traveler.</typeparam>
public abstract class GoServiceBase<TTraveler> : IGoService<TTraveler> 
    where TTraveler : Traveler
{
    /// <summary>
    /// Add country to the visited list.
    /// </summary>
    /// <param name="traveler">The traveler.</param>
    /// <param name="country">The country.</param>
    public abstract void AddCountryToVisitedList(TTraveler traveler, Country country);

    /// <summary>
    /// Print traveler to output.
    /// </summary>
    /// <param name="traveler">The traveler.</param>
    /// <param name="output">The output.</param>
    /// <param name="retry">The retry count.</param>
    /// <typeparam name="TOutput">The output type.</typeparam>
    /// <returns>Null or traveler.</returns>
    public TTraveler? PrintTraveler<TOutput>(TTraveler traveler, TOutput output, int retry)
        => null;
    
    /// <summary>
    /// The traveling provider.
    /// </summary>
    protected class TravelingProvider
    {
        /// <summary>
        /// Private constructor.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="traveler">The traveler.</param>
        private TravelingProvider(string name, TTraveler traveler)
        {
            Name = name;
            Traveler = traveler;
        }

        /// <summary>
        /// Create a traveling provider.
        /// </summary>
        /// <param name="name">The provider name.</param>
        /// <param name="traveler">The traveler.</param>
        /// <returns>Traveling provider.</returns>
        public TravelingProvider CreateProvider(string name, TTraveler traveler)
            => new(name, traveler);
        
        /// <summary>
        /// The provider name.
        /// </summary>
        public string? Name { get; protected set; }
        
        /// <summary>
        /// The traveler.
        /// </summary>
        public TTraveler Traveler { get; }
    }
}