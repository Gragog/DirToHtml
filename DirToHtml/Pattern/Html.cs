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
            mainTable.Add("<table>");
        }

        public string title = "Page";

        string q = "\"";

        public string html = "";

        public List<string> body = new List<string>();
        public List<string> mainTable = new List<string>();

        public string[] Generate()
        {
            mainTable.Add("</table>");
            body.Add(String.Join("\n", mainTable.ToArray()));

            string bodyString = String.Join("\n", body.ToArray());

            html = @"<!DOCTYPE html>
<html lang=" + q + @"\en\ xmlns=" + q + @"http://www.w3.org/1999/xhtml" + q + @">
<head>
<meta charset=" + q + "utf-8" + q + @" />
<title>" + title + @"</title>
</head>
<body>
" + bodyString + @"
</body>
</html>";

            return new string[] { html };
        }
    }
}
