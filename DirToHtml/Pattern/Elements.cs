using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirToHtml.Pattern
{
    class Elements
    {
        #region Table
        public static string tr = "<tr>";
        public static string trEnd = "</tr>";

        public static string td = "<td>";
        public static string tdEnd = "</td>";
        #endregion

        public static string TableLine(string term)
        {
            return td + term + tdEnd;
        }
    }
}
