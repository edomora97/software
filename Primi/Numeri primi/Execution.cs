using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Numeri_primi
{
    class Execution
    {
        public Execution(int maxNo, int threadNo) 
        {
            this.maxNo = maxNo;
            this.threadNo = threadNo;
            this.inc = threadNo * 2;
        }

        int maxNo;
        int threadNo;
        int numPrimi;
        int inc;
        StreamWriter stream = new StreamWriter("file.txt");
        public void Execute()
        {
            stream.WriteLine("I numeri primi minori di {0} sono:", maxNo);
            Stopwatch sw = new Stopwatch();
            Thread[] threads = new Thread[threadNo];
            sw.Start();
            if (maxNo > 2)
            {
                numPrimi++;
                Console.WriteLine("2");
            }
            for (int i = 1; i <= threadNo; i++)
            {
                ParameterizedThreadStart pTs = new ParameterizedThreadStart(ThreadJob);
                threads[i - 1] = new Thread(pTs);
                threads[i - 1].Start(i * 2 - 1);
            }
            foreach (Thread thread in threads)
                thread.Join();
            sw.Stop();
            stream.Close();
            Console.WriteLine("FINISH! " + numPrimi + " numeri primi trovati minori di " + maxNo);
            Console.WriteLine(sw.Elapsed);
        }


        void ThreadJob(object start)
        {
            int num = (int)start;
            while (num < maxNo)
            {
                if (isPrime(num))
                    Console.WriteLine(num);
                num += inc;
            }
        }
        bool isPrime(int num)
        {
            if (num == 1)
                return false;
            if (num == 2)
                goto Primo;
            if (num % 2 == 0)
                return false;
            else
                for (int i = 3; i <= (int)Math.Sqrt(num); i+=2)
                    if ((num%i==0) && (maxNo != i))
                        return false;
            Primo:
            numPrimi++;
            stream.WriteLine(num);
            return true;
        }

        bool isPrimeLong(long num)
        {
            long i = num / 2;
            while (i > 1)
            {
                if (num % i == 0)
                    return false;
                i--;
            }
            numPrimi++;
            return true;
        }

        System.Collections.Generic.Dictionary<long, int> dic = new Dictionary<long, int>();
        public void Scomponi(long num)
        {
            long k = 2;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (num != 1)
            {
                if (num % k == 0 && isPrimeLong(k))
                {
                    Console.Write(k + " (" + num + ")\n");
                    num /= k;
                    if (dic.ContainsKey(k))
                        dic[k]++;
                    else
                        dic.Add(k, 1);
                    k = 2;
                }
                else
                    k++;
            }
            sw.Stop();
            Console.WriteLine("\n\nTempo trascorso: " + sw.Elapsed);
            Console.WriteLine("Il numero scomposto è: ");
            foreach (int key in dic.Keys)
            {
                Console.Write(key);
                if (dic[key] > 1)
                {
                    Console.Write("^");
                    Console.WriteLine(dic[key]);
                }
                else
                    Console.WriteLine();
            }
        }
    }
}
