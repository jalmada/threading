using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Xml.Linq;

namespace threading
{
    class Program
    {
        static void Main(string[] args)
        {
            // var opt = Console.ReadLine();
            // if(opt == "basics")
            // {
            //     Basics.Run();
            // } else if (opt == "tasks")
            // {
            //     Tasks.Run();
            // } else if (opt == "para"){
            var sw = new Stopwatch();
            sw.Start();
            var xdoc = XDocument.Load("books.xml");

            for(var x = 0; x < 1; x++){
                var dto = Parser.ToXDto(xdoc.Root);
            }
            sw.Stop();
            System.Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            //}
        }
    }
}
