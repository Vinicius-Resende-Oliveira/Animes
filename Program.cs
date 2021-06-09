using System;

namespace Animes
{
    class Program
    {
        static AnimeRepositorio repositorioAnime = new();
        static SerieRepositorio repositorioSerie = new();
        static MovieRepositorio repositorioMovie = new();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuarioMain();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        MenuAnime();
                        break;
                    case "2":
                        MenuSerie();
                        break;
                    case "3":
                        MenuMovie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuarioMain();
            }
            Console.WriteLine("Obrigado por usar o nosso serviço!");
            Console.WriteLine();
        }

        private static void VisualizaAnime()
        {
            Console.WriteLine("Digite o ID do anime:");
            int indiceAnime = int.Parse(Console.ReadLine());

            var anime = repositorioAnime.RetornaPorID(indiceAnime);

            Console.WriteLine(anime);
        }

        private static void ExcluiAnime()
        {
            Console.WriteLine("Digite o ID do Anime");
            int indiceAnime = int.Parse(Console.ReadLine());

            repositorioAnime.Excluir(indiceAnime);
        }

        private static void AtualizaAnime()
        {
            Console.WriteLine("Digite o ID do anime");
            int indiceAnime = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do Anime: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano do Anime: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descricao do Anime: ");
            string entradaDescricao = Console.ReadLine();
            
            Animes novoAnime = new Animes(id: indiceAnime, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorioAnime.Atualizar(indiceAnime, novoAnime);
        }

        private static void InserirAnime()
        {
            Console.WriteLine("Inserir novo Anime");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do Anime: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano do Anime: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descricao do Anime: ");
            string entradaDescricao = Console.ReadLine();
            
            Animes novoAnime = new Animes(id: repositorioAnime.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorioAnime.Insere(novoAnime);
        }

        private static void ListaAnime()
        {
            Console.WriteLine("Listar Anime");
            var lista = repositorioAnime.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum anime cadastrado");
                return;
            }
            foreach (var anime in lista)
            {
                if(!anime.returnExcluido()){
                    Console.WriteLine("#ID {0} - {1}", anime.returnTitulo(), anime.returnId());
                }
                
            }
        }
        private static void VisualizaMovie()
        {
            Console.WriteLine("Digite o ID do filme:");
            int indiceAnime = int.Parse(Console.ReadLine());

            var movie = repositorioMovie.RetornaPorID(indiceAnime);

            Console.WriteLine(movie);
        }

        private static void ExcluiMovie()
        {
            Console.WriteLine("Digite o ID do filme");
            int indiceMovie = int.Parse(Console.ReadLine());

            repositorioMovie.Excluir(indiceMovie);
        }

        private static void AtualizaMovie()
        {
            Console.WriteLine("Digite o ID do filme");
            int indiceMovie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do filme: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descricao do filme: ");
            string entradaDescricao = Console.ReadLine();
            
            Movies novoMovie = new Movies(id: indiceMovie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorioMovie.Atualizar(indiceMovie, novoMovie);
        }

        private static void InserirMovie()
        {
            Console.WriteLine("Inserir novo filme");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do filme: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descricao do filme: ");
            string entradaDescricao = Console.ReadLine();
            
            Movies novoMovie = new Movies(id: repositorioMovie.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorioMovie.Insere(novoMovie);
        }

        private static void ListaMovie()
        {
            Console.WriteLine("Listar filme");
            var lista = repositorioMovie.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado");
                return;
            }
            foreach (var movie in lista)
            {
                if(!movie.returnExcluido()){
                    Console.WriteLine("#ID {0} - {1}", movie.returnTitulo(), movie.returnId());
                }
                
            }
        }
        private static void VisualizaSerie()
        {
            Console.WriteLine("Digite o ID da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorID(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluiSerie()
        {
            Console.WriteLine("Digite o ID da serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSerie.Excluir(indiceSerie);
        }

        private static void AtualizaSerie()
        {
            Console.WriteLine("Digite o ID da serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do serie: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano do serie: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descricao do serie: ");
            string entradaDescricao = Console.ReadLine();
            
            Series novoSerie = new Series(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorioSerie.Atualizar(indiceSerie, novoSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do serie: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano do serie: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descricao do serie: ");
            string entradaDescricao = Console.ReadLine();
            
            Series novaSerie = new Series(id: repositorioSerie.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorioSerie.Insere(novaSerie);
        }

        private static void listaSerie()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorioSerie.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum serie cadastrado");
                return;
            }
            foreach (var serie in lista)
            {
                if(!serie.returnExcluido()){
                    Console.WriteLine("#ID {0} - {1}", serie.returnTitulo(), serie.returnId());
                }
                
            }
        }

        private static string ObterOpcaoUsuario(string pagina)
        {
            Console.WriteLine();
            Console.WriteLine("DIO Animes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada.");

            Console.WriteLine("1- Listar {0}" + pagina);
            Console.WriteLine("2 -Inserir novo {0}" + pagina);
            Console.WriteLine("3- Atualizar {0}" + pagina);
            Console.WriteLine("4- Excluir {0}" + pagina);
            Console.WriteLine("5- Visualizar {0}" + pagina);
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static string ObterOpcaoUsuarioMain()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Animes a seu dispor!!!");
            Console.WriteLine("Informe a página desejada.");

            Console.WriteLine("1- Animes");
            Console.WriteLine("2 -Séries");
            Console.WriteLine("3- Filmes");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void MenuAnime()
        {
            string opcaoUsuario = ObterOpcaoUsuario("anime");

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaAnime();
                        break;
                    case "2":
                        InserirAnime();
                        break;
                    case "3":
                        AtualizaAnime();
                        break;
                    case "4":
                        ExcluiAnime();
                        break;
                    case "5":
                        VisualizaAnime();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario("anime");
            }
        }
        private static void MenuSerie()
        {
            string opcaoUsuario = ObterOpcaoUsuario("série");

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listaSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcluiSerie();
                        break;
                    case "5":
                        VisualizaSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario("série");
            }
        }
        private static void MenuMovie()
        {
            string opcaoUsuario = ObterOpcaoUsuario("filme");

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaMovie();
                        break;
                    case "2":
                        InserirMovie();
                        break;
                    case "3":
                        AtualizaMovie();
                        break;
                    case "4":
                        ExcluiMovie();
                        break;
                    case "5":
                        VisualizaMovie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario("filme");
            }
        }
    }
}
