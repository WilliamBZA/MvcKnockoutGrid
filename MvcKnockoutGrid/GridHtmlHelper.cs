using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcKnockoutGrid
{
    public static class GridHtmlHelper
    {
        public static Grid<T> Grid<T>(this HtmlHelper html, string id, IEnumerable<T> data)
        {
            return GridFactory.CreateGrid(id, data);
        }
    }
}