using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PagedList<T> : List<T>
    {
        public int? PageNumber { get; set; } = null;
        public int? PageSize { get; private set; } = null;
        public bool HasPrevious => (PageNumber > 1);
        public bool HasNext => (Count == PageSize);
        public PagedList(List<T> items, int? pageNumber = null, int? pageSize = null)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            AddRange(items);
        }
        public static PagedList<T> Create(IEnumerable<T> source, int? pageNumber = null, int? pageSize = null)
        {
            return new PagedList<T>(source.ToList(), pageNumber, pageSize);
        }
    }
}
