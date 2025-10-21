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

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            var veiculo = veiculos.FirstOrDefault(x => x.ToUpper() == placa.ToUpper());
            if (veiculo != null)
            {
                string horasInput = "";
                do
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    horasInput = Console.ReadLine();
                    // Verifica se a quantidade digitada é válida
                    if (!CheckIntUserInput(horasInput))
                    {
                        Console.WriteLine("Quantidade inválida.");
                    }
                } while (!CheckIntUserInput(horasInput));

                decimal valorTotal = precoInicial + (precoPorHora * int.Parse(horasInput));

                veiculos.Remove(veiculo);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool CheckIntUserInput(string userInput)
        {
            return int.TryParse(userInput, out int value);
        }
    }
}
