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

            AddentriesToMainTable(entries);

            GenerateMainTable();

            html.title = curDir;
            File.WriteAllLines(curDir + @"\index.html", html.Generate());

            return false;
        }

        private void AddentriesToMainTable(string[] entries)
        {
            foreach (string entry in entries)
            {
                // Add Icon
                string extension = entry.Substring((entry.LastIndexOf(".")));

                // Add Extension and Name
                TableRow row = new TableRow(entry.Substring(entry.LastIndexOf(@"\") + 1));

                // Add Size
                row.Add(GenerateSizeString(entry));

                // Add row o mainTable
                html.mainTable.Add(row);
            }
        }

        private void GenerateMainTable()
        {
            #region Table Header
            TableHeadRow head = new TableHeadRow();
            html.mainTableStringList.Add("\t" + Elements.thead);
            html.mainTableStringList.Add("\t" + Elements.tr);
            foreach (string header in head.headers)
            {
                html.mainTableStringList.Add("\t" + Elements.th);
                html.mainTableStringList.Add("\t\t" + header);
                html.mainTableStringList.Add("\t" + Elements.thEnd);
            }
            html.mainTableStringList.Add("\t" + Elements.theadEnd);
            html.mainTableStringList.Add("\t" + Elements.tr);
            #endregion

            foreach (TableRow row in html.mainTable)
            {
                int i = 0;

                foreach (string data in row.data)
                {
                    if (i == 2) html.mainTableStringList.Add("\t\t" + "<td style=\"text-align: right\">");
                    else html.mainTableStringList.Add("\t\t" + Elements.td);
                    html.mainTableStringList.Add("\t\t\t" + data);
                    html.mainTableStringList.Add("\t\t" + Elements.tdEnd);

                    i++;
                }

                html.mainTableStringList.Add("\t" + Elements.trEnd);
            }
        }

        private string GenerateSizeString(string entry)
        {
            long size = new FileInfo(entry).Length;
            int displaySize = 0;
            string postfix = "B";

            // To KB
            if (size > 1024)
            {
                displaySize = (int)(size / 1024);
                postfix = "kB";
            }

            // To MB
            if (displaySize > 1024)
            {
                displaySize = (int)(displaySize / 1024);
                postfix = "MB";
            }

            // To GB
            if (displaySize > 1024)
            {
                displaySize = (int)(displaySize / 1024);
                postfix = "GB";
            }

            return displaySize.ToString() + " " + postfix;
        }
    }
}
