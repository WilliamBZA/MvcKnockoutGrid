using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MvcKnockoutGrid
{
    public class Grid<T> : IHtmlString, IKnockoutGrid<T>
    {
        private IEnumerable<T> _data;

        public Grid(string id, IEnumerable<T> data)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            Id = id;
            _data = data;
        }

        public string ToHtmlString()
        {
            var columnNames = GetColumnNames(_data);

            string columnHeadings = string.Join(string.Empty, columnNames.Select(name => "<th>" + name + "</th>"));
            string columnBindings = string.Join(string.Empty, columnNames.Select(name => "<td data-bind=\"text: " + name + "\"></td>"));

            return string.Format(@"<table>
    <thead>
        <tr>
            {0}
        </tr>
    </thead>
    <tbody data-bind=""foreach: seats"">
        <tr>
            {1}
        </tr>    
    </tbody>
</table>", columnHeadings, columnBindings);
        }

        private IEnumerable<string> GetColumnNames(IEnumerable<T> data)
        {
            var genericTypes = data.GetType().GetInterfaces();
            foreach (Type genericType in genericTypes)
            {
                if (genericType.IsGenericType && genericType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return genericType.GetGenericArguments()[0].GetProperties().Select(p => p.Name);
                }
            }

            return null;
        }

        public string Id { get; set; }
    }
}