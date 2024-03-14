using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // Process
using System.Threading; // Thread, ThreadPool

namespace ClassWork_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта Поток
            Thread th1 = new Thread(ThreadProcedura);
            th1.Name = "First Thread";
            th1.IsBackground = true;
            th1.Start(); // Starting Thread on execution

            Thread th2 = new Thread(ThreadProcedura);
            th2.Name = "Second Thread";
            th2.IsBackground = true;
            th2.Start(); // Starting Thread on execution

            // Waiting Thread exit - simple variant to syncronization Thread
            th1.Join();
            th2.Join();

            Console.WriteLine("Main Thread exit");
        }
        static Random rnd = new Random((int)DateTime.Now.Ticks);
        // Поточная ф-ция без параметра
        static void ThreadProcedura()
        {
            Console.WriteLine("New Thread started");
            Console.WriteLine("Thread ID {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread Name {0}", Thread.CurrentThread.Name);
            int timeOut = rnd.Next(2000, 5000);
            Console.WriteLine("{0}: Time out = {1}", Thread.CurrentThread.ManagedThreadId, timeOut);
            Thread.Sleep(timeOut);
            Console.WriteLine("{0}: Thread exit", Thread.CurrentThread.ManagedThreadId);
        }
    }
}