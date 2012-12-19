using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcKnockoutGrid
{
    public static class GridFactory
    {
        public static Grid<T> CreateGrid<T>(string id, IEnumerable<T> data)
        {
            return new Grid<T>(id, data);
        }
    }
}
