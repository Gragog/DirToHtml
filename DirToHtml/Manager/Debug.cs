using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingAnvil.Manager
{
    static class Debug
    {
        static bool isLogging = false;

        public static bool LogStatus
        {
            get { return isLogging; }
            set { isLogging = value; }
        }

        public static void Log(
            dynamic term,
            [System.Runtime.CompilerServices.CallerLineNumber] int callerLine = 0,
            [System.Runtime.CompilerServices.CallerFilePath] string callerOrigin = ""
            )
        {
            if (isLogging)
            {
                ConsoleColor backupForegroundColor = Console.ForegroundColor;
                ConsoleColor backupBackroundColor = Console.BackgroundColor;

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                string typeString = "Type: " + term.GetType();
                Console.CursorLeft = Console.BufferWidth - Math.Max(typeString.Length, 1);

                Console.Write(typeString);

                if (term is Array)
                {
                    foreach (dynamic content in term)
                    {
                        Log(content, callerLine, callerOrigin);
                    }
                }

                string orginMessage = "logged from " + callerOrigin.Substring(53) + " on line " + callerLine;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                int cursorOffset = Console.BufferWidth - Math.Max(term.ToString().Length, 1);
                Console.CursorLeft = cursorOffset;
                Console.Write(term);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.CursorLeft = Console.BufferWidth - orginMessage.Length;
                Console.WriteLine(orginMessage);

                Console.ForegroundColor = backupForegroundColor;
                Console.BackgroundColor = backupBackroundColor;

            }
        }

        public static void ForceLog(dynamic term,
            [System.Runtime.CompilerServices.CallerLineNumber] int callerLine = 0,
            [System.Runtime.CompilerServices.CallerMemberName] string callerOrigin = "")
        {
            isLogging = true;
            Log(term, callerLine, callerOrigin);
            isLogging = false;
        }
    }
}
