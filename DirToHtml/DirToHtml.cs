using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyingAnvil.Manager;
using DirToHtml.Pattern;

namespace DirToHtml
{
    class DirToHtml
    {
        public bool Start()
        {
            Directory.SetCurrentDirectory(@"D:\HFS\FlyingAnvil\DirToHtml");

            string curDir = Directory.GetCurrentDirectory();

            string[] entries = Directory.GetFiles(curDir);

            Debug.Log(curDir);

            Html.title = curDir;
            File.WriteAllLines(curDir + @"\index.html", Html.Generate());

            return false;
        }
    }
}
