using System.Collections.Generic;

namespace RiotPls.Binding
{
    /// <summary>
    /// Facilitates data binding of a collection of the specified type
    /// </summary>
    /// <typeparam name="T">Object type to bind to</typeparam>
    interface IInfoBindingList<T>
    {
        #region Instance Properties
        /// <summary>
        /// Data to bind directly to control(s) 
        /// </summary>
        SortableBindingList<T> Binding { get; }
        /// <summary>
        /// Categories/columns to be used when filtering
        /// </summary>
        /// <seealso cref="SetFilter"/>
        List<string> FilterItems { get; }
        /// <summary>                              
        /// Search text used when filtering
        /// </summary>
        /// <seealso cref="SetFilter"/>
        string SearchText { get; }
        /// <summary>
        /// Original data collection, without filters
        /// </summary>
        SortableBindingList<T> Source { get; }
        #endregion
        #region Instance Methods     
        /// <summary>
        /// Retrieve an instance that uses the specified name
        /// </summary>
        /// <param name="name">Identifier to search for</param>
        /// <returns>Bound datum using the specified name, if any</returns>
        T Retrieve(string name);
        /// <summary>
        /// Set filter category(s) and search text
        /// </summary>
        /// <param name="items">Categories/columns to filter</param>
        /// <param name="search_text">Search text to include in the filter</param>
        /// <remarks>Filter is not updated until Update() is called</remarks>
        void SetFilter(IEnumerable<string> items, string search_text);
        /// <summary>
        /// Update binding to reflect data or filter changes
        /// </summary>
        void UpdateFilter();
        #endregion
    }
}
