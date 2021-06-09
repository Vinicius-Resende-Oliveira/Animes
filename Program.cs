using System;

namespace Animes
{
    class Program
    {
        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

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
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar o nosso serviço!");
            Console.WriteLine();
        }

        private static void VisualizaAnime()
        {
            Console.WriteLine("Digite o ID do anime:");
            int indiceAnime = int.Parse(Console.ReadLine());

            var anime = repositorio.RetornaPorID(indiceAnime);

            Console.WriteLine(anime);
        }

        private static void ExcluiAnime()
        {
            Console.WriteLine("Digite o ID do Anime");
            int indiceAnime = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceAnime);
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
            repositorio.Atualizar(indiceAnime, novoAnime);
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
            
            Animes novoAnime = new Animes(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorio.Insere(novoAnime);
        }

        private static void ListaAnime()
        {
            Console.WriteLine("Listar Animes");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum anme cadastrado");
                return;
            }
            foreach (var anime in lista)
            {
                if(!anime.returnExcluido()){
                    Console.WriteLine("#ID {0} - {1}", anime.returnTitulo(), anime.returnId());
                }
                
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Animes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada.");

            Console.WriteLine("1- Listar Animes");
            Console.WriteLine("2 -Inserir novo anime");
            Console.WriteLine("3- Atualizar anime");
            Console.WriteLine("4- Excluir anime");
            Console.WriteLine("5- Visualizar anime");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
