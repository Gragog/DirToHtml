using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirToHtml.Pattern
{
    class Html
    {
        public Html()
        {
            mainTableStringList.Add("<table border=" + q + "2px" + q + ">");
        }

        public string title = "Page";

        string q = "\"";

        public string html = "";

        public List<string> body = new List<string>();
        public List<TableRow> mainTable = new List<TableRow>();
        public List<string> mainTableStringList = new List<string>();

        public string[] Generate()
        {
            mainTableStringList.Add("</table>");
            body.Add(String.Join("\n", mainTableStringList.ToArray()));

            string bodyString = String.Join("\n", body.ToArray());

            html = @"<!DOCTYPE html>
<html lang=" + q + @"\en\ xmlns=" + q + @"http://www.w3.org/1999/xhtml" + q + @">
<head>
<meta charset=" + q + "utf-8" + q + @" />
<title>" + title + @"</title>" +
"<link rel=\"stylesheet\" href=\"https://raw.githubusercontent.com/Gragog/DirToHtml/dth-2/DirToHtml/my.css\"" + @">
</head>
<body>
" + bodyString + @"
</body>
</html> ";

            return new string[] { html };
        }
    }
}
