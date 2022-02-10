using System;
using DIO_Series_Filmes.Class;

namespace DIO_Series_Filmes
{
    class Program
    {
        static SerieRepository repositorio = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    
                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        //ExcluirSerie();
                        break;

                    case "4":
                        //VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir um novo valor:");

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{item} - {Enum.GetName(typeof(Genero), item)}");
            }
            System.Console.WriteLine("Digite o gênero entre as opçòes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da Série/Filme :");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de início da Série/Filme :");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da Série/Filme :");
            string entradaDescricao = Console.ReadLine();

            Series objeto = new Series(
                Id: repositorio.ProximoId(),
                genero : (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao,
                Excluido : false
            );

            repositorio.insere(objeto);
        }

        private static void ListarSerie()
        {
            System.Console.WriteLine("Listagem de dados");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum dado cadastrado nessa lista!");
                return;
            }

            foreach (var item in lista)
            {
                System.Console.WriteLine($"ID {item.retornaId()}: - {item.retornaTitulo()}");
            }
        }

        private static string ObterOpcaoUsuario(){
            System.Console.WriteLine();
            System.Console.WriteLine("Desafio DIO Séries e Filmes");
            System.Console.WriteLine("Informe a opçao desejada:");

            System.Console.WriteLine("1 - Listar");
            System.Console.WriteLine("2 - Inserir");
            System.Console.WriteLine("3 - Atualizar");
            System.Console.WriteLine("4 - Excluir");
            System.Console.WriteLine("5 - Visualizar");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        
    }
}
