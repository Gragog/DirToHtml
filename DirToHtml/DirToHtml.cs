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
        Html html = new Html();

        public bool Start()
        {
            Directory.SetCurrentDirectory(@"D:\HFS\FlyingAnvil\DirToHtml");

            string curDir = Directory.GetCurrentDirectory();

            string[] entries = Directory.GetFiles(curDir);

            Debug.Log(curDir);

            GenerateMainTable(entries);

            html.title = curDir;
            File.WriteAllLines(curDir + @"\index.html", html.Generate());

            return false;
        }

        private void GenerateMainTable(string[] entries)
        {
            foreach (string entry in entries)
            {
                html.mainTable.Add(Elements.tr);
                html.mainTable.Add(Elements.TableLine(entry));
                html.mainTable.Add(Elements.trEnd);
            }
        }
    }
}
