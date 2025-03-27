using System;

class Program
{   
    static string caminhoArquivo = "contatos.txt";


    static void Main(string[] args)
    {
        string response;

        Console.WriteLine("Olá bem vindo ao meu AT de C#");
        while (true)
        {
            Console.WriteLine("Qual exercicio você quer executar?");
            Console.WriteLine("1 - Criando e Executando seu Primeiro Programa");
            Console.WriteLine("2 - Manipulação de Strings - Cifrador de Nome");
            Console.WriteLine("3 - Calculadora de Operações Matemáticas");
            Console.WriteLine("4 - Manipulação de Datas - Dias até o Próximo Aniversário");
            Console.WriteLine("5 - Tempo Restante para Conclusão do Curso - Diferença Entre Datas");
            Console.WriteLine("6 - Cadastro de Alunos");
            Console.WriteLine("7 - Banco Digital (Encapsulamento)");
            Console.WriteLine("8 - Cadastro de Funcionários (Herança)");
            Console.WriteLine("9 - Controle de Estoque via Linha de Comando");
            Console.WriteLine("10 - Jogo de Adivinhação");
            Console.WriteLine("11 - Manipulação de Arquivos - Cadastro e Listagem de Contatos");
            Console.WriteLine("12 - Manipulação de Arquivos com Herança e Polimorfismo - Formatos de Exibição");
            Console.WriteLine("Presione enter para sair");
            response = Console.ReadLine();
            switch (response)
            {
                case "1": Ex_1(); break;
                case "2": Ex_2(); break;
                case "3": Ex_3(); break;
                case "4": Ex_4(); break;
                case "5": Ex_5(); break;
                case "6": Ex_6(); break;
                case "7": Ex_7(); break;
                case "8": Ex_8(); break;
                case "9": Ex_9(); break;
                case "10": Ex_10(); break;
                case "11": Ex_11(); break;
                case "12": Ex_12(); break;
                case "":
                    Console.WriteLine("Saindo do programa...");
                    return;
                default:
                    Console.WriteLine("Opção invalida, digite outro número ou aperte enter para sair");
                    break;
            }
        }
    }

    // Exercicio 1
    public static void Ex_1()
    {
        Console.WriteLine("Olá meu nome é José Luís");
        Console.WriteLine("Nasci em 03/03/2005 e estou aprendendo C#!");
    }
    
    // Exercicio 2
    public static string Ex_2()
    {
        string nome;
        int deslocamento = 2;
        
        Console.WriteLine("Digite seu  nome completo");
        nome = Console.ReadLine();
        
        char[] resultado = new char[nome.Length];

        for (int i = 0; i < nome.Length; i++)
        {
            char caractere = nome[i];

            if (char.IsLetter(caractere))
            {
                char baseLetra = char.IsUpper(caractere) ? 'A' : 'a';
                resultado[i] = (char)((caractere - baseLetra + deslocamento) % 26 + baseLetra);
            }
            else
            {
                resultado[i] = caractere;
            }
        }

        return new string(resultado);
    }
    
    // Exercicio 3
    public static void Ex_3()
    {
        Console.Write("Digite o primeiro número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite o segundo número: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Escolha a operação:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        int operacao = Convert.ToInt32(Console.ReadLine());

        switch (operacao)
        {
            case 1:
                Console.WriteLine($"Resultado: {num1 + num2}");
                break;
            case 2:
                Console.WriteLine($"Resultado: {num1 - num2}");
                break;
            case 3:
                Console.WriteLine($"Resultado: {num1 * num2}");
                break;
            case 4:
                if (num2 != 0)
                    Console.WriteLine($"Resultado: {num1 / num2}");
                else
                    Console.WriteLine("Erro: Divisão por zero não é permitida.");
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    
    // Exercicio 4
    public static void Ex_4()
    {
        Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
        DateTime dataNascimento;

        while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
        {
            Console.Write("Data inválida. Digite novamente (dd/MM/yyyy): ");
        }

        DateTime hoje = DateTime.Today;
        DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);
        if (proximoAniversario < hoje)
        {
            proximoAniversario = proximoAniversario.AddYears(1);
        }

        int diasRestantes = (proximoAniversario - hoje).Days;
        Console.WriteLine($"Faltam {diasRestantes} dias para seu próximo aniversário!");

        if (diasRestantes < 7)
        {
            Console.WriteLine("🎉 Falta menos de uma semana para seu aniversário! Parabéns adiantado! 🎂");
        }
    }
    
    // Exercicio 5
    public static void Ex_5()
    {
        DateTime dataFormatura = new DateTime(2026, 12, 15);

        Console.Write("Digite a data atual (dd/MM/yyyy): ");
        DateTime dataAtual;

        while (!DateTime.TryParse(Console.ReadLine(), out dataAtual) || dataAtual > DateTime.Today)
        {
            Console.Write("Data inválida. Digite novamente (dd/MM/yyyy): ");
        }

        if (dataAtual > dataFormatura)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
        }
        else
        {
            TimeSpan diferenca = dataFormatura - dataAtual;
            int anos = diferenca.Days / 365;
            int meses = (diferenca.Days % 365) / 30;
            int dias = (diferenca.Days % 365) % 30;

            Console.WriteLine($"Faltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");

            if (diferenca.Days < 180)
            {
                Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
            }
        }
    }
    
    // Exercicio 6
    class Aluno
    {
        public string Nome { get; set; }
        public string Matricula  { get; set; }
        public string Curso  { get; set; }
        public double MediaNotas  { get; set; }
        public void ExibirDados()
        {
            Console.WriteLine("Dados do Aluno:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Curso: {Curso}");
            Console.WriteLine($"Média das Notas: {MediaNotas:F2}");
        }
        public string VerificarAprovacao()
        {
            return MediaNotas >= 7 ? "Aprovado" : "Reprovado";
        }
    }
    
    public static void Ex_6()
    {
        string nome;
        string matricula;
        string curso;
        double mediaNotas;
        
        Console.WriteLine("Digite o nome do aluno: ");
        nome = Console.ReadLine();        
        Console.WriteLine("Digite a matricula do aluno: ");
        matricula = Console.ReadLine();
        Console.WriteLine("Digite o curso do aluno: ");
        curso = Console.ReadLine();        
        Console.WriteLine("Digite a media das notas do aluno: ");
        mediaNotas = double.Parse(Console.ReadLine());
        
        
        Aluno aluno = new Aluno()
        {
            Nome = nome,
            Matricula = matricula,
            Curso = curso,
            MediaNotas = mediaNotas
        };
        
        Console.WriteLine("Dados do Aluno:");
        aluno.ExibirDados();
        Console.WriteLine($"Status: {aluno.VerificarAprovacao()}");
    }
    
    // Exercicio 7
    class ContaBancaria
    {
        public string Titular { get; set; }
        private double Saldo { get; set; }
        
        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("O valor do depósito deve ser positivo!");
            }
        }
        
        public void Sacar(double valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
            }
        }
        
        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual: R$ {Saldo:F2}");
        }
    }
    
    public static void Ex_7()
    {
        string titular;
        double deposito;
        double saque;
        double saldo;
        Console.WriteLine("Digite o nome do Titular da conta");
        titular = Console.ReadLine();
        ContaBancaria conta = new ContaBancaria
        {
            Titular = titular
        };
        
        Console.WriteLine($"Titular: {conta.Titular}");
        string response;
        while (true)
        {
            Console.WriteLine("O que você deseja fazer? (Digite um número)");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Mostrar saldo");
            Console.WriteLine("Ou aperte enter para sair");
            response = Console.ReadLine();
            switch (response)
            {
                case "1": 
                    Console.WriteLine("Quanto voce quer depositar?");
                    deposito = Convert.ToDouble(Console.ReadLine());
                    conta.Depositar(deposito);
                    break;
                case "2":
                    Console.WriteLine("Quanto voce quer sacar?");
                    saque = Convert.ToDouble(Console.ReadLine());
                    conta.Sacar(saque);
                    break;
                case "3":
                    conta.ExibirSaldo();
                    break;
                case "":
                    Console.WriteLine("Saindo do programa...");
                    return;
                default:
                    Console.WriteLine("Opção invalida, digite outro número ou aperte enter para sair");
                    break;
            }
        }
    }
    
    // Exercicio 8
    class Funcionario
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public double SalarioBase { get; set; }

        public virtual void ExibirSalario()
        {
            Console.WriteLine($"{Nome} ({Cargo}) - Salário: R$ {SalarioBase:F2}");
        }
    }
    
    class Gerente : Funcionario
    {
        public override void ExibirSalario()
        {
            double salarioComBonus = SalarioBase * 1.20; 
            Console.WriteLine($"{Nome} ({Cargo}) - Salário com bônus: R$ {salarioComBonus:F2}");
        }
    }

    
    public static void Ex_8()
    {
        Console.WriteLine("Digite os dados do Funcionário:");
        Console.Write("Nome: ");
        string nomeFuncionario = Console.ReadLine();
        Console.Write("Cargo: ");
        string cargoFuncionario = Console.ReadLine();
        Console.Write("Salário Base: R$ ");
        double salarioFuncionario = Convert.ToDouble(Console.ReadLine());

        Funcionario funcionario = new Funcionario
        {
            Nome = nomeFuncionario,
            Cargo = cargoFuncionario,
            SalarioBase = salarioFuncionario
        };

        Console.WriteLine("\nDigite os dados do Gerente:");
        Console.Write("Nome: ");
        string nomeGerente = Console.ReadLine();
        Console.Write("Cargo: ");
        string cargoGerente = Console.ReadLine();
        Console.Write("Salário Base: R$ ");
        double salarioGerente = Convert.ToDouble(Console.ReadLine());

        Gerente gerente = new Gerente
        {
            Nome = nomeGerente,
            Cargo = cargoGerente,
            SalarioBase = salarioGerente
        };

        Console.WriteLine("\nInformações do Funcionário:");
        funcionario.ExibirSalario();

        Console.WriteLine("\nInformações do Gerente:");
        gerente.ExibirSalario();
    }
    
    // Exercicio 9
    class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, int quantidade, double preco)
        {
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"Produto: {Nome} | Quantidade: {Quantidade} | Preço: R$ {Preco:F2}";
        }

        public string ToFileFormat()
        {
            return $"{Nome},{Quantidade},{Preco:F2}";
        }
    }
    
    class Estoque
    {
        private const int LimiteMaximoProdutos = 5;
        private Produto[] produtos = new Produto[LimiteMaximoProdutos];
        private int contadorProdutos = 0;
        private string arquivoEstoque = "estoque.txt";

        public void InserirProduto()
        {
            if (contadorProdutos >= LimiteMaximoProdutos)
            {
                Console.WriteLine("Limite de produtos atingido!");
                return;
            }

            Console.Write("Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Preço unitário: R$ ");
            double preco = double.Parse(Console.ReadLine());

            Produto produto = new Produto(nome, quantidade, preco);
            produtos[contadorProdutos] = produto;
            contadorProdutos++;

            SalvarProdutoNoArquivo(produto);
            Console.WriteLine("Produto inserido com sucesso!");
        }

        private void SalvarProdutoNoArquivo(Produto produto)
        {
            using (StreamWriter writer = new StreamWriter(arquivoEstoque, append: true))
            {
                writer.WriteLine(produto.ToFileFormat());
            }
        }

        public void ListarProdutos()
        {
            if (File.Exists(arquivoEstoque))
            {
                string[] linhas = File.ReadAllLines(arquivoEstoque);

                if (linhas.Length == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
                else
                {
                    foreach (var linha in linhas)
                    {
                        var dados = linha.Split(',');

                        if (dados.Length == 3)
                        {
                            string nome = dados[0];
                            int quantidade = int.Parse(dados[1]);
                            double preco = double.Parse(dados[2]);

                            Produto produto = new Produto(nome, quantidade, preco);
                            Console.WriteLine(produto);
                        }
                        else
                        {
                            Console.WriteLine("Erro no formato do arquivo.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Arquivo de estoque não encontrado. Nenhum produto cadastrado.");
            }
        }
    }
    
    public static void Ex_9()
    {
        Estoque estoque = new Estoque();
        string opcao;

        do
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    estoque.InserirProduto();
                    break;
                case "2":
                    estoque.ListarProdutos();
                    break;
                case "3":
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        while (opcao != "3");
    }
    
    // Exercicio 10
    public static void Ex_10()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51);
        
        int tentativasRestantes = 5;
        bool numeroCorreto = false;

        Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
        Console.WriteLine("Tente adivinhar um número entre 1 e 50.");
        Console.WriteLine("Você tem 5 tentativas.");

        while (tentativasRestantes > 0 && !numeroCorreto)
        {
            try
            {
                Console.WriteLine($"\nTentativas restantes: {tentativasRestantes}");
                Console.Write("Digite um número: ");
                string input = Console.ReadLine();
                
                if (!int.TryParse(input, out int palpite))
                {
                    Console.WriteLine("Erro: Você deve digitar um número válido!");
                    continue;
                }

                if (palpite < 1 || palpite > 50)
                {
                    Console.WriteLine("Erro: O número deve estar entre 1 e 50!");
                    continue;
                }

                if (palpite == numeroSecreto)
                {
                    numeroCorreto = true;
                    Console.WriteLine("Parabéns! Você adivinhou o número corretamente!");
                }
                else if (palpite < numeroSecreto)
                {
                    Console.WriteLine("O número secreto é maior que o seu palpite.");
                }
                else
                {
                    Console.WriteLine("O número secreto é menor que o seu palpite.");
                }

                tentativasRestantes--;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        if (!numeroCorreto)
        {
            Console.WriteLine($"\nVocê perdeu! O número secreto era {numeroSecreto}.");
        }
    }
    
    // Exercicio 11
    public static void Ex_11()
    {
        static void Main()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciador de Contatos ===");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos cadastrados");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarContato();
                        break;
                    case 2:
                        ListarContatos();
                        break;
                    case 3:
                        Console.WriteLine("Encerrando programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

            } while (opcao != 3);
        }

        static void AdicionarContato()
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Novo Contato ===");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
                {
                    writer.WriteLine($"{nome},{telefone},{email}");
                }
                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o contato: {ex.Message}");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void ListarContatos()
        {
            Console.Clear();
            Console.WriteLine("=== Contatos Cadastrados ===");

            if (File.Exists(caminhoArquivo))
            {
                string[] contatos = File.ReadAllLines(caminhoArquivo);

                if (contatos.Length > 0)
                {
                    foreach (var contato in contatos)
                    {
                        string[] dados = contato.Split(',');
                        Console.WriteLine($"Nome: {dados[0]} | Telefone: {dados[1]} | Email: {dados[2]}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum contato cadastrado.");
                }
            }
            else
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
    
    // Exercicio 12
    class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Contato(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }

    abstract class ContatoFormatter
    {
        public abstract void ExibirContatos(List<Contato> contatos);
    }

    class MarkdownFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("## Lista de Contatos\n");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"- **Nome:** {contato.Nome}");
                Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
                Console.WriteLine($"- 📧 Email: {contato.Email}\n");
            }
        }
    }

    class TabelaFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("| Nome               | Telefone        | Email             |");
            Console.WriteLine("----------------------------------------");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"| {contato.Nome,-18} | {contato.Telefone,-15} | {contato.Email,-17} |");
            }
            Console.WriteLine("----------------------------------------");
        }
    }

    class RawTextFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            foreach (var contato in contatos)
            {
                Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
            }
        }
    }

    //Exercicio 12
    public static void Ex_12()
    {
            List<Contato> contatos = new List<Contato>();

            CarregarContatos(contatos);

            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciador de Contatos ===");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos cadastrados");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarContato(contatos);
                        break;
                    case 2:
                        ExibirContatos(contatos);
                        break;
                    case 3:
                        Console.WriteLine("Encerrando programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

            } while (opcao != 3);
        }

        static void AdicionarContato(List<Contato> contatos)
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Novo Contato ===");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            contatos.Add(new Contato(nome, telefone, email));

            try
            {
                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
                {
                    writer.WriteLine($"{nome},{telefone},{email}");
                }
                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o contato: {ex.Message}");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void ExibirContatos(List<Contato> contatos)
        {
            if (contatos.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }
            else
            {
                Console.WriteLine("Escolha o formato de exibição:");
                Console.WriteLine("1 - Markdown");
                Console.WriteLine("2 - Tabela");
                Console.WriteLine("3 - Texto Puro");
                Console.Write("Escolha uma opção: ");
                int formato = int.Parse(Console.ReadLine());

                ContatoFormatter formatter = null;

                switch (formato)
                {
                    case 1:
                        formatter = new MarkdownFormatter();
                        break;
                    case 2:
                        formatter = new TabelaFormatter();
                        break;
                    case 3:
                        formatter = new RawTextFormatter();
                        break;
                    default:
                        Console.WriteLine("Formato inválido.");
                        return;
                }

                formatter.ExibirContatos(contatos);
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void CarregarContatos(List<Contato> contatos)
        {
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (var linha in linhas)
                {
                    string[] dados = linha.Split(',');
                    if (dados.Length == 3)
                    {
                        contatos.Add(new Contato(dados[0], dados[1], dados[2]));
                    }
                }
            }
        }
    }