using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirToHtml.Pattern
{
    class TableRow
    {
        public TableRow(string term)
        {
            Add(term.Substring(term.LastIndexOf(".")));
            Add(term);
        }

        public List<string> data = new List<string>();

        public void Add(string term)
        {
            data.Add(term);
        }
    }

    class TableHeadRow
    {
        public string[] headers;

        public TableHeadRow()
        {
            headers = new string[] { "Icon", "Name", "Size", "Date" };
        }
    }
}
