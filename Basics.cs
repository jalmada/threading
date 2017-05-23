using System;
using System.Threading;

namespace threading
{
    public class Basics
    {
        public static void Run(){
            var a = Console.ReadKey().KeyChar;

            if(a == '1')
            {
                System.Console.WriteLine("Ex 1 ===========");            
                Thread tr = Thread.CurrentThread;
                tr.Name = "MainThread";
                System.Console.WriteLine("This is {0}", tr.Name);
                Console.ReadKey();
            }
            else if(a == '2')
            {
                System.Console.WriteLine("Ex 2 ===========");
                var childref = new ThreadStart(() => { System.Console.WriteLine("Child Thread Start");});
                System.Console.WriteLine("In Main: Creating the Child Thread");
                var childThread = new Thread(childref);
                childThread.Start();
                Console.ReadKey();
            }
            else if(a == '3')
            {
                System.Console.WriteLine("Ex 3 ===========");
                

                var ex3Th = new ThreadStart(() =>{
                    System.Console.WriteLine("Child Thread Starts");
                    var sleepFor = 5000;
                    System.Console.WriteLine("Child Thread paused for {0} miliseconds", sleepFor);
                    Thread.Sleep(sleepFor);
                    System.Console.WriteLine("Child Thread Resumes");
                });

                System.Console.WriteLine("In Main Creating the child thread");
                var ex3Thread = new Thread(ex3Th);
                ex3Thread.Start();
                Console.ReadKey();   
            }    
        }
    }
}