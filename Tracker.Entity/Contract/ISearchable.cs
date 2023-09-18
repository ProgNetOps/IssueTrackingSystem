using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Entity.Contract
{
    public interface ISearchable<T> where T : class
    {
        /// <summary>
        /// Returns some members of a collection based on a property and a search term
        /// </summary>
        /// <param name="searchBy">The property used to filter the collection</param>
        /// <param name="searchString">The supplied search term</param>
        /// <returns>Return search results by the supplied filters</returns>
        Task<IEnumerable<T>?> GetFilteredResultAsync(string filterOn, string filterQuery, int pageNumber, int pageSize);
    }
}
