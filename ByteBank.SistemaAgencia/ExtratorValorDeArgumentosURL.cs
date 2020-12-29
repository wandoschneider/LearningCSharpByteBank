using System;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; }
        public ExtratorValorDeArgumentosURL(string url)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio.", nameof(url));

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            URL = url;

        }
        public string GetValor(string nomeParametro)
        {
            nomeParametro = nomeParametro.ToLower();
            string argumentoEmCaixaAlta = _argumentos.ToLower();

            string termo = nomeParametro + "=";
            int indiceTermo = argumentoEmCaixaAlta.IndexOf(termo);

            string resultado = _argumentos.Substring(indiceTermo + termo.Length);
            int indiceEComercial = resultado.IndexOf('&');

            if (indiceEComercial == -1)
                return resultado;

            return resultado.Remove(indiceEComercial);
        }

    }
}