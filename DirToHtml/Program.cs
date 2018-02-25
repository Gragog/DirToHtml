using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            FlyingAnvil.Manager.Debug.LogStatus = true;

            DirToHtml program = new DirToHtml();

            bool keepOn = program.Prepare(); ;

            while (keepOn) keepOn = program.Start();

            Console.ReadLine();
        }
    }
}
