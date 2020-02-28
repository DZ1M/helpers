using System;
using System.Diagnostics;

namespace Demos
{
    public class Contador
    {
        public TimeSpan RetornaTempo()
        {
            var stopwatch = new Stopwatch();
            // Inicia
            stopwatch.Start();
            // Aqui executa o metodo....

            // Coloque um Metodo Aqui....

            // Para o tempo
            stopwatch.Stop();
            // Retorna Tempo
            return stopwatch.Elapsed;
        }
    }
}
