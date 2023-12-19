using System.ComponentModel;
using System.Linq.Expressions;

namespace Akov.Chillout.Traveling.Models;

/// <summary>
/// Represents a set of parameters used to query a data source.
/// </summary>
/// <typeparam name="TCondition">The condition.</typeparam>
public sealed class TravelSearchParameters<TCondition>
{
    /// <summary>
    /// Gets or sets the sorting rules to apply to the data source.
    /// </summary>
    public IEnumerable<Tuple<Expression<Func<TCondition, object?>>, ListSortDirection>>? SortingRules { get; set; }

    /// <summary>
    /// Gets or sets the filter expression to apply to the data source.
    /// </summary>
    public Expression<Func<TCondition, bool>>? Filter { get; set; }

    /// <summary>
    /// Gets or sets CalculateTotalCount.
    /// </summary>
    public bool CalculateTotalCount { get; set; } = true;
}