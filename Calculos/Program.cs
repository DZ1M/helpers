using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Calculos
{
    public class Program
    {
       static async Task Main(string[] args)
        {
            //Contar o tempo dos metodos
            var stopwatch = new Stopwatch();
            Console.WriteLine("Calculando....");
            stopwatch.Start();
            Console.WriteLine("Soma1: " + await Task.Run(() => SomaFor()));
            stopwatch.Stop();
            Console.WriteLine("Tempo Soma1: "+ stopwatch.Elapsed);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Soma2: " + await Task.Run(() => SomaMatematicada()));
            Console.WriteLine("Tempo Soma2:" + stopwatch.Elapsed);
            stopwatch.Stop();
        }

        public static int SomaFor()
        {
            int soma = 0;
            for (int i = 0; i < 1000; i++)
            {
                soma = soma + i;
            }
            return soma;
        }
        public static int SomaMatematicada()
        {
            return  1000 * (1 + 1000) / 2;
        }
    }
}
