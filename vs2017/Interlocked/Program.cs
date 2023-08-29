using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interlocking
{
    static class Program
    {
        static void WorkerThread()
        {
            for (int i = 0; i < 100; i++)
            {
                int mySeq = UniqueSequence.GetNextSequence();
                Console.WriteLine("mySeq = " + mySeq.ToString());
                Thread.Sleep(10);
            }
        }

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(WorkerThread);
                threads[i].Start();
                Thread.Sleep(50);
            }
            Thread.Sleep(1000);
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
        }
    }
}
