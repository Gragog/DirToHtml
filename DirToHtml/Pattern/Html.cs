using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirToHtml.Pattern
{
    class Html
    {
        public static string title = "Page";

        public static string body = "";

        static string q = "\"";

        public static string html = "";

        public static string[] Generate()
        {
            html = @"<!DOCTYPE html>
<html lang=" + q + @"\en\ xmlns=" + q + @"http://www.w3.org/1999/xhtml" + q + @">
<head>
<meta charset=" + q + "utf-8" + q + @" />
<title>" + title + @"</title>
</head>
<body>
" + body + @"
</body>
</html>";

            return new string[] { html };
        }
    }
}
