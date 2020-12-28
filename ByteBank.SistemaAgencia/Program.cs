using System;
using Humanizer;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System.Threading;
using System.Globalization;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "paginas?argumentos";

            Console.WriteLine(url);

            int indiceInterrogacao = url.IndexOf('?');

            string argumentos = url.Substring(indiceInterrogacao);

            Console.WriteLine(argumentos);
        }

        public static void UsandoHumanizer()
        {
            CultureInfo culture = new CultureInfo("pt-BR");

            DateTime dataFimPagamento = new DateTime(2020, 12, 31);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = dataFimPagamento - dataCorrente;
            string mensagem = "Vencimento em: " + Humanizer.TimeSpanHumanizeExtensions.Humanize(diferenca, 1, culture);

            Console.WriteLine(mensagem);
        }
    }
}
