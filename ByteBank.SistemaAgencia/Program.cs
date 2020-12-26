using System;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ContaCorrente conta = new ContaCorrente(123, 123456);
            Funcionario funcionario = null;


            Console.WriteLine(conta.Numero);
        
        }
    }
}
