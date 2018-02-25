using FlyingAnvil.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirToHtml.Pattern
{
    class TableRow
    {
        public TableRow(string term, bool isDir = false)
        {
            string extension = term.Substring(term.LastIndexOf(".") + 1);

            if (isDir)
            {
                extension = "folder";
            }

            term = "<a class=\"link-name\" href=\"" + term + "\">" + term + "</a>";

            string iconFile = Storage.dir + @"\..\icons\" + extension + ".png";
            string icon = "&nbsp;<img title=\"" + extension + "\" src=\"" + iconFile.Substring(NthIndex.IndexOfNth(iconFile, "\\", 4)) + "\" height=\"32px\" width=\"32px\">&nbsp;";

            if (!File.Exists(iconFile))
            {
                iconFile = Storage.dir + @"\icons\missing.png";
                icon = "&nbsp;<img src=\"" + iconFile.Substring(NthIndex.IndexOfNth(iconFile, "\\", 4)) + "\" height=\"32px\" width=\"32px\">&nbsp;";
            }

            if (!File.Exists(iconFile))
            {
                //icon = "<i class=\"fa fa-exclamation-triangle\" title=\"Icon not available\"></i>";
            }

            Add(icon);
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
            headers = new string[] { "Icon", "Name", "Size", "Date", "Download" };
        }
    }
}
