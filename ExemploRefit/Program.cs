using Refit;
using System;
using System.Threading.Tasks;

namespace ExemploRefit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.Write("Informe o Cep: ");
                string CepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando Informações do Cep Informado " + CepInformado);

                var address = await cepClient.GetAddressAsync(CepInformado);

                Console.WriteLine($"\nLogradouro: {address.Logradouro}, \n" +
                    $"Bairro: {address.Bairro}, \n" +
                    $"Cidade: {address.Localidade}, \n" +
                    $"UF: {address.Uf}, \n" +
                    $"Unidade: {address.Unidade},\n" +
                    $"IBGE: {address.Ibge}, \n" +
                    $"Gia: {address.Gia}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta de Cep: " + e.Message);
            }
        }
    }
}
