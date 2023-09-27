namespace DesafioGiovanniBiblioteca
{
    public class Biblioteca
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Paginas { get; set; }
        public bool Disponibilidade { get; set; }

        public Biblioteca(string titulo, string autor, string paginas)
        {
            Titulo = titulo;
            Autor = autor;
            Paginas = paginas;
            Disponibilidade = true;
        }
    }

    public class Desafio
    {
        private List<Biblioteca> livros = new List<Biblioteca>();

        public void Cadastrar(string titulo, string autor, string paginas)
        {
            Biblioteca livro = new Biblioteca(titulo, autor, paginas);
            livros.Add(livro);
            Console.WriteLine($"O livro '{titulo}' foi cadastrado na biblioteca!");
        }

        public void Emprestar()
        {
            Console.Clear();
            Console.WriteLine("======EMPRÉSTIMO======");
            Console.WriteLine();
            Console.WriteLine("Digite o título do livro:");
            string titulo = Console.ReadLine();
            Biblioteca livro = livros.Find(l => l.Titulo == titulo);
            if (livro != null)
            {
                if (livro.Disponibilidade)
                {
                    livro.Disponibilidade = false;
                    Console.WriteLine($"O livro '{titulo}' foi emprestado.");
                }
                else
                {
                    Console.WriteLine($"O livro '{titulo}' não está disponível para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine($"O livro '{titulo}' não foi encontrado na biblioteca.");
            }
        }

        public void Devolver()
        {
            Console.Clear();
            Console.WriteLine("======DEVOLUÇÃO======");
            Console.WriteLine();
            Console.WriteLine("Digite o título do livro:");
            string titulo = Console.ReadLine();
            Biblioteca livro = livros.Find(l => l.Titulo == titulo);
            if (livro != null)
            {
                if (!livro.Disponibilidade)
                {
                    livro.Disponibilidade = true;
                    Console.WriteLine($"O livro '{titulo}' foi devolvido.");
                }
                else
                {
                    Console.WriteLine($"O livro '{titulo}' já se encontrava disponível.");
                }
            }
            else
            {
                Console.WriteLine($"O livro '{titulo}' não foi encontrado na biblioteca.");
            }
        }

        public void Verificar()
        {
            Console.Clear();
            Console.WriteLine("======ESTANTE======");
            Console.WriteLine();
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado na biblioteca.");
            }
            else
            {
                foreach (var livro in livros)
                {
                    Console.WriteLine($"Título: {livro.Titulo}");
                    Console.WriteLine($"Autor: {livro.Autor}");
                    Console.WriteLine($"Número de Páginas: {livro.Paginas}");
                    Console.WriteLine($"Disponível: {(livro.Disponibilidade ? "Sim" : "Não")}");
                    Console.WriteLine("--------------------------------");
                }
            }

            Console.WriteLine("Pressione Enter para voltar ao menu.");
            Console.ReadLine();
        }

        public void Apresentar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite a opção que deseja realizar:");
                Console.WriteLine("1- Cadastrar\n2- Emprestar\n3- Devolver\n4- Livros\n5- Sair");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("======CADASTRO======");
                        Console.WriteLine("\nDigite o título do livro:");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("\nDigite o nome do Autor do livro:");
                        string autor = Console.ReadLine();
                        Console.WriteLine("\nDigite o número de páginas do livro:");
                        string pagina = Console.ReadLine();

                        Cadastrar(titulo, autor, pagina);

                        Console.WriteLine($"O livro '{titulo}' acaba de ser cadastrado!");
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ReadLine();
                        break;

                    case "2":
                        Emprestar();
                        break;

                    case "3":
                        Devolver();
                        break;

                    case "4":
                        Verificar();
                        break;

                    case "5":
                        Console.WriteLine("VAI SAIR SÓ APERTANDO X MESMO");
                        Console.ReadLine();
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("Escolha a opção correta!");
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}



