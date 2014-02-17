using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Numeri_primi
{
    class Program
    {
        static void Main(string[] args)
        {
            int scelta;
            Console.WriteLine("Cosa vuoi fare?");
            Console.WriteLine("1. Trovare i numeri primi < n");
            Console.WriteLine("2. Scomposizione in fattori primi");
            scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserire il numero di thraed: ");
                    int numThread = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserire numero massimo: ");
                    int maxNo = int.Parse(Console.ReadLine());
                    Execution ex = new Execution(maxNo, numThread);
                    ex.Execute();
                    break;
                case 2:
                    Console.WriteLine("Inserire numero da scomporre: ");
                    long num = long.Parse(Console.ReadLine());
                    Execution ex2 = new Execution(0, 0);
                    ex2.Scomponi(num);
                    break;
                default:
                    Console.WriteLine("Comando non valido");
                    break;
            }

            Console.Write("Premere un tasto per uscire...");
            Console.ReadKey();
        }
    }
}
