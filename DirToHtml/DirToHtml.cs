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

        // Queue<string> folderQueue = new Queue<string>();

        public bool Prepare()
        {
            Directory.SetCurrentDirectory(@"D:\HFS\FlyingAnvil\DirToHtml");
            Storage.dir = Directory.GetCurrentDirectory();

            if (!Directory.Exists(Storage.dir + @"\..\icons"))
            {
                Directory.CreateDirectory(Storage.dir + @"\icons");
            }

            return true;
        }

        public bool Start()
        {
            string curDir = Directory.GetCurrentDirectory();

            string[] entries = Directory.GetFiles(curDir);
            string[] dirs = Directory.GetDirectories(curDir);

            Debug.Log(curDir);

            Console.WriteLine("generating dirs for: " + curDir);
            AddDirectoriesToMainTable(dirs);
            Console.WriteLine("generating entries for: " + curDir);
            AddEntriesToMainTable(entries);

            GenerateMainTable();

            html.title = curDir;

            File.WriteAllLines(curDir + @"\indexx.html", html.Generate());

            return false;
        }

        private void AddEntriesToMainTable(string[] entries)
        {
            foreach (string entry in entries)
            {
                // Add Icon and Name
                TableRow row = new TableRow(entry.Substring(entry.LastIndexOf(@"\") + 1));

                // Add Size
                row.Add(GenerateSizeString(entry));

                // Add Date
                row.Add("no date yet, sry");

                // Add Download
                row.Add("<a download href=\"" + entry.Substring(NthIndex.IndexOfNth(entry, "\\", 3)) + "\"><i class=\"fa fa-download\">");

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
                    switch (i)
                    {
                        // Icon
                        case 0: html.mainTableStringList.Add("\t\t" + "<td style=\"text-align: center; width: 40px\">"); break;
                        // Name
                        case 1: html.mainTableStringList.Add("\t\t" + "<td style=\"padding-left: 10px; width: 50%\">"); break;
                        // Size
                        case 2: html.mainTableStringList.Add("\t\t" + "<td style=\"padding-right: 10px; text-align: right; width: 10%\">"); break;
                        // Date
                        case 3: html.mainTableStringList.Add("\t\t" + "<td style=\"padding-left: 10px; width: 25%\">"); break;
                        // Download
                        case 4: html.mainTableStringList.Add("\t\t" + "<td style=\"text-align: center; width: 5%\">"); break;

                        default:
                            html.mainTableStringList.Add("\t\t" + Elements.td);
                            break;
                    }
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
            string postfix = "&nbsp;B";

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

        private void AddDirectoriesToMainTable(string[] dirs)
        {
            foreach (string dir in dirs)
            {
                TableRow row = new TableRow(dir.Substring(dir.LastIndexOf(@"\") + 1), true);

                row.Add("No folder size yet, sry");

                // Add Date
                row.Add("no date yet, sry");

                // Add Download
                row.Add("<a href=\"" + dir.Substring(NthIndex.IndexOfNth(dir, "\\", 3)) + "\"><i class=\"fa fa-folder-open\">");

                // Add row o mainTable
                html.mainTable.Add(row);
            }

        }
    }
}
