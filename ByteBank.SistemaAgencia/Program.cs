﻿using System;
using Humanizer;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ByteBank.SistemaAgencia.Extensoes;
using ByteBank.SistemaAgencia.Comparadores;
using System.Linq;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 87480),
                null,
                new ContaCorrente(342, 12348),
                null,
                new ContaCorrente(340, 34567),
                new ContaCorrente(290, 18753),
            };

            //contas.Sort(); //implementacao de IComparable
            //contas.Sort(new ComparadorContaCorrentePorAgencia()); //implementacao de IComperer

            IOrderedEnumerable<ContaCorrente> ContasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in ContasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }

            //UsandoHumanizer();
            //ExtratorURL();
            //TestarREGEX();
            //TestaArrayInt();
            //TestaArraydeContaCorrente();
            //TestaListaDeObject();
            //TestaListaGenerica();
            //TestaSort();
        }

        static void TestaSort()
        {
            var idades = new List<int>();
            idades.Add(5);
            idades.Add(1);

            idades.Remove(5);

            idades.AdicionarVarios(123, 6, 789, 9, 0, 42, 54, -1);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

        }
        
        static void TestaListaGenerica()
        {
            Lista<int> idades = new Lista<int>();
            idades.Adicionar(5);
            idades.AdicionarVarios(1, 8, 78);

            idades.Remover(5);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                int idadeAtual = idades[i];
                Console.WriteLine(idades[i]);
            }
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);

            listaDeIdades.AdicionarVarios(1, 7, 8);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();
            lista.Adicionar(new ContaCorrente(874, 5679787));
            lista.Adicionar(new ContaCorrente(874, 5679754));


            lista.AdicionarVarios(
                new ContaCorrente(874, 5679745),
                new ContaCorrente(874, 4353635),
                new ContaCorrente(874, 6757575),
                new ContaCorrente(874, 7686868),
                new ContaCorrente(874, 9086845),
                new ContaCorrente(874, 8786845),
                new ContaCorrente(874, 1186845),
                new ContaCorrente(874, 2286845),
                new ContaCorrente(874, 3386845)
            );

            for(int i = 0; i < lista.Tamanho; i++) 
            { 
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Agencia}/{itemAtual.Numero}");
            } 
        }

        static void TestaArraydeContaCorrente()
        { 
            ContaCorrente[] contas = new ContaCorrente[]
                { 
                    new ContaCorrente(874, 5679787),
                    new ContaCorrente(874, 4456668),
                    new ContaCorrente(874, 7781438),
                };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        } 
        static void TestaArrayInt()
        {
            int[] idades = new int[5];

            idades[0] = 10;
            idades[1] = 15;
            idades[2] = 20;
            idades[3] = 25;
            idades[4] = 30;

            int sum = 0;
            for (int i = 0; i < idades.Length; i++)
            {
                sum += idades[i];

                Console.WriteLine($"Valor de idades[{i}] = {idades[i]}");
            }

            int media = sum / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }
        static void TestarREGEX()
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
