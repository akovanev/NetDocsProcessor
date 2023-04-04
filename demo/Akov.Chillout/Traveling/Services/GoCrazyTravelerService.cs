using System.Text.Json.Serialization;
using Akov.Chillout.Traveling.Models;

namespace Akov.Chillout.Traveling.Services;

/// <summary>
/// One of the craziest services.
/// </summary>
///  <remarks>
/// Use it carefully.
/// </remarks>
/// <example>
/// Here is an example how to not use `GoCrazyTravelerService`.
/// <code>
/// var traveler = new CrazyTraveler();
/// var service = new GoCrazyTravelerService(traveler);
/// string greeting = service.GetAwesomeGreeting("Boom");
/// </code>
/// Never use it like this.
/// </example>
public class GoCrazyTravelerService : GoServiceBase<CrazyTraveler>
{
    private readonly Dictionary<string, VisitedList> _visitedCountryList;

    /// <summary>
    /// The parameterless constructor.
    /// </summary>
    public GoCrazyTravelerService()
    {
        _visitedCountryList = new Dictionary<string, VisitedList>();
    }

    /// <summary>
    /// The constructor with a parameter.
    /// </summary>
    /// <param name="list">The visited list.</param>
    /// <param name="firstname">The first name</param>
    /// <param name="lastname">The last name.</param>
    public GoCrazyTravelerService(Dictionary<string, VisitedList> list, string firstname, string lastname)
    {
        _visitedCountryList = list;
        list.Add(firstname, new VisitedList(new CrazyTraveler(firstname, lastname)));
    }

    /// <summary>
    /// Crazy constructor.
    /// </summary>
    ///  <remarks>
    /// Doing nothing useful.
    /// </remarks>
    /// <example>
    /// Here is an example how to not use it.
    /// <code>
    /// var traveler = new CrazyTraveler();
    /// var service = new GoCrazyTravelerService(traveler);
    /// </code>
    /// Never use it.
    /// </example>
    /// <param name="crazyTraveler"></param>
    /// <exception cref="InvalidOperationException">The InvalidOperationException.</exception>
    /// <exception cref="ArgumentNullException">The ArgumentNullException.</exception>
    public GoCrazyTravelerService(GoServiceBase<CrazyTraveler>? crazyTraveler)
    {
        if (crazyTraveler is null) throw new ArgumentNullException(nameof(crazyTraveler));
        _visitedCountryList = default!;
        if (_visitedCountryList is null) throw new InvalidOperationException();
    }

    /// <summary>
    /// The protected internal constructor.
    /// </summary>
    /// <param name="list">The list of countries.</param>
    /// <param name="number">The dummy property.</param>
    protected internal GoCrazyTravelerService(Dictionary<string, VisitedList> list, int number)
        : this(list, "Traveler",number.ToString())
    {
        Limit = number;
    }
    
    /// <summary>
    /// The static constructor.
    /// </summary>
    static GoCrazyTravelerService(){ Limit = 50;}
    
    /// <summary>
    /// The limit for countries.
    /// </summary>
    protected static int Limit { get; private set; }
    
    /// <include file='Examples.xml' path='examples/GoCrazyTravelerService[@name="Collection"]/*' />
    [JsonPropertyName("crazyCollection")]
    public List<CrazyTraveler>? Collection { get; set; }
        
    /// <summary>
    /// Adds country to the visited list.
    /// </summary>
    /// <param name="traveler">The traveler.</param>
    /// <param name="country">The country.</param>
    /// <exception cref="ArgumentException">Wrong traveler.</exception>
    /// <exception cref="NotSupportedException">Not supported operation.</exception>
    public override void AddCountryToVisitedList(CrazyTraveler traveler, Country country)
    {
        if (!_visitedCountryList.ContainsKey(traveler.LastName))
            throw new ArgumentException("Traveler is not found");

        if (_visitedCountryList[traveler.LastName].GetCountries().Count > Limit)
            throw new NotSupportedException();
        
        _visitedCountryList[traveler.LastName].AddCountry(country);
    }

    /// <summary>
    /// Add a traveler to the list.
    /// </summary>
    /// <param name="traveler">The traveler.</param>
    public void AddTraveler(CrazyTraveler traveler) =>
        _visitedCountryList.Add(traveler.LastName, new VisitedList(traveler));


    /// <summary>
    /// Add travelers
    /// </summary>
    /// <param name="mainTraveler">Main traveler</param>
    /// <param name="travelers">Travelers</param>
    /// <param name="count">Count</param>
    /// <typeparam name="T">Type</typeparam>
    public void AddTraveler<T>(T mainTraveler, Dictionary<string, T> travelers, int count)
    {
        if(count == 0) return;

        if(mainTraveler is CrazyTraveler crazyTraveler)
            AddTraveler(crazyTraveler);

        foreach (var traveler in travelers)
        {
            if(traveler.Value is CrazyTraveler otherCrazyTraveler)
                AddTraveler(otherCrazyTraveler);
        }
    }

    /// <summary>
    /// Awesome method.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>Greeting string.</returns>
    public string GetAwesomeGreeting(string name)
        => $"Hello {name}";
}