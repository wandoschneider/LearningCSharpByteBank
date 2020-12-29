using System;
using Humanizer;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(123, 123456);
            Console.WriteLine(conta);
            //UsandoHumanizer();
            //ExtratorURL();
            // REGEX();
        }


        static void REGEX()
        {
            string textoDeTeste = "Meu nome é Wando, me ligue em 4784-4546";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            Match resultado = Regex.Match(textoDeTeste, padrao);

            Console.WriteLine(resultado.Value);
        }
        static void ExtratorURL()
        {
            string urlParametros = "https://www.bytebank.com/cambio?moedaOrigem=Real&moedaDestino=Dolar&valor=1500";
            ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(urlParametros);

            string valor = extratorDeValores.GetValor("moedaDestino");
            Console.WriteLine("Valor de moeda Destino: " + valor);

            string valorOrigem = extratorDeValores.GetValor("moedaOrigem");
            Console.WriteLine("Valor de moeda Origem: " + valorOrigem);

            Console.WriteLine(extratorDeValores.GetValor("VALOR"));
        }
        static void UsandoHumanizer()
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
