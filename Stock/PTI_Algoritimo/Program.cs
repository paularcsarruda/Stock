using System.Globalization;

class Program
{
    class Produto
    {
        public string Nome { get; set; }
        public string Plataforma { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
    }

    class Estoque
    {
        public List<Produto> produtos = new List<Produto>();

        public void NovoProduto(string nome, string plataforma, string genero, int ano, int quantidade, double preco)
        {
            Produto produto = new Produto
            {
                Nome = nome,
                Plataforma = plataforma,
                Genero = genero,
                Ano = ano,
                Quantidade = quantidade,
                Preco = preco
            };
            produtos.Add(produto);
        }
        // retorna os produtos em estoque
        public void ListarProdutos()
        {
            foreach (var produto in produtos)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("===========================================");
                Console.WriteLine($" Produto: {produto.Nome}");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" Plataforma: {produto.Plataforma}");
                Console.WriteLine($" Gênero: {produto.Genero}  || Lançamento: {produto.Ano}");
                Console.WriteLine($" Quantidade: {produto.Quantidade}");
                Console.WriteLine($" Preço: R$ {produto.Preco.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine("===========================================");
                Console.ResetColor();
            }
        }
        // opcao 3: remove os produtos do estoque
        public void RemoverProduto(string nome)
        {
            produtos.RemoveAll(produto => produto.Nome == nome);
        }
        // opcao 4: adiciona produtos ao estoque
        public void EntradaEstoque(string nome, int quantidade)
        {
            Produto produto = produtos.Find(p => p.Nome == nome);
            if (produto != null)
            {
                produto.Quantidade += quantidade;
            }
        }
        // opcao 5: remove produtos do estoque
        public void SaidaEstoque(string nome, int quantidade)
        {
            Produto produto = produtos.Find(p => p.Nome == nome);
            if (produto != null)
            {
                produto.Quantidade -= quantidade;
            }
        }
    }
    // menu
    static void ExibirMenu()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("===========================================");
        Console.WriteLine("           Controle de Estoque             ");
        Console.WriteLine("===========================================");
        Console.WriteLine();
        Console.WriteLine("===========================================");
        Console.WriteLine("| [1] Novo Produto                        |");
        Console.WriteLine("| [2] Listar Produtos                     |");
        Console.WriteLine("| [3] Remover Produtos                    |");
        Console.WriteLine("| [4] Entrada de Estoque                  |");
        Console.WriteLine("| [5] Saída de Estoque                    |");
        Console.WriteLine("| [0] Sair                                |");
        Console.WriteLine("===========================================");
        Console.ResetColor();
    }

    static void Main(string[] args)
    {
        Estoque estoque = new Estoque();

        while (true)
        {
            Console.Clear();
            ExibirMenu();
            Console.WriteLine();
            Console.Write("Digite a opção da operação que deseja efetuar: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": // cadastra novo produto
                    Console.Write("Digite o nome do produto: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite a plataforma do produto: ");
                    string plataforma = Console.ReadLine();
                    Console.Write("Digite o gênero do produto: ");
                    string genero = Console.ReadLine();
                    Console.Write("Digite o ano de lançamento: ");
                    int ano = int.Parse(Console.ReadLine());
                    Console.Write("Digite a quantidade inicial em estoque: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    Console.Write("Digite o preço do produto: ");
                    double preco = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Novo produto adicionado ao estoque!");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao inicio.");
                    Console.ReadLine();
                    estoque.NovoProduto(nome, plataforma, genero, ano, quantidade, preco);
                    break;

                case "2": // lista os produtos do estoque
                    estoque.ListarProdutos();
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao inicio.");
                    Console.ReadLine();
                    break;

                case "3": // remove o estoque de determinado produto
                    Console.Write("Digite o nome do produto que deseja remover do estoque: ");
                    string codigoRemover = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Produto removido com sucesso!");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao inicio.");
                    Console.ReadLine();
                    estoque.RemoverProduto(codigoRemover);
                    break;

                case "4": // entrada do estoque
                    Console.Write("Digite o nome do produto que deseja adicionar ao estoque: ");
                    string codigoEntrada = Console.ReadLine();
                    // check se o produto existe no estoque
                    Produto produtoEntrada = estoque.produtos.Find(p => p.Nome == codigoEntrada);
                    if (produtoEntrada == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Produto não localizado no estoque.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao inicio.");
                        Console.ReadLine();
                        continue;
                    }
                    Console.Write("Digite a quantidade a ser adicionada: ");
                    int quantidadeEntrada = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Produto adicionado com sucesso!");
                    Console.WriteLine();
                    Console.WriteLine("===========================================");
                    Console.WriteLine($"Produto: {produtoEntrada.Nome}");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine($"Novo Estoque: {produtoEntrada.Quantidade + quantidadeEntrada}");
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao inicio.");
                    Console.ReadLine();
                    estoque.EntradaEstoque(codigoEntrada, quantidadeEntrada);
                    break;

                case "5": // saída do estoque
                    Console.Write("Digite o nome do produto: ");
                    string codigoSaida = Console.ReadLine();
                    // check se o produto existe no estoque
                    Produto produtoSaida = estoque.produtos.Find(p => p.Nome == codigoSaida);
                    if (produtoSaida == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Produto não localizado no estoque.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao inicio.");
                        Console.ReadLine();
                        continue;
                    }
                    Console.Write("Digite a quantidade a ser removida: ");
                    int quantidadeSaida = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Produto removido com sucesso.");
                    Console.WriteLine();
                    Console.WriteLine("===========================================");
                    Console.WriteLine($"Produto: {produtoSaida.Nome}");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine($"Novo Estoque: {produtoSaida.Quantidade - quantidadeSaida}");
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao inicio.");
                    Console.ReadLine();
                    estoque.SaidaEstoque(codigoSaida, quantidadeSaida);
                    break;

                case "0": // exit do sistema
                    Console.Write("Tem certeza de que deseja sair? (Y/N)");
                    string confirmExit = Console.ReadLine().ToLower();
                    if (confirmExit == "y")
                    {
                        Environment.Exit(0);
                    }
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }
    }
}