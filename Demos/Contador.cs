using System;
using System.Diagnostics;

namespace Demos
{
    public class Contador
    {
        public TimeSpan RetornaTempo()
        {
            var stopwatch = new Stopwatch();
            //Inicia
            stopwatch.Start();
            //Aqui executa o metodo....

            //Metodo....

            //Para o tempo
            stopwatch.Stop();
            //Retorna Tempo
            return stopwatch.Elapsed;
        }
    }
}
