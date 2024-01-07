using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
     public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public bool ValidarPlaca(string placa)
    {
        // Padrão para placas com 3 letras e 4 números
        string padrao1 = @"^[A-Z]{3}-\d{4}$";

        // Padrão para placas com 4 letras, um número e dois números
        string padrao2 = @"^[A-Z]{3}\d[A-Z]\d{2}$";

        // Verifica se a placa corresponde a algum dos padrões
        if (Regex.IsMatch(placa, padrao1) || Regex.IsMatch(placa, padrao2))
        {
            return true;
        }

        Console.WriteLine("Placa inválida. Digite novamente.");
        return false;
    }

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para estacionar:");

        string placa;
        do
        {
            placa = Console.ReadLine();
        } while (!ValidarPlaca(placa));

        veiculos.Add(placa);
        Console.WriteLine($"O veículo com placa {placa} foi estacionado.");
    }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var item in veiculos)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
