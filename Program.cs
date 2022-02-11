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
                        ListarRegistro();
                        break;
                    
                    case "2":
                        InserirRegistro();
                        break;

                    case "3":
                        AtualizarRegistro();
                        break;

                    case "4":
                        ExcluirRegistro();
                        break;
                        
                    case "5":
                        VisualizarRegistro();
                        
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

        private static void AtualizarRegistro()
        {
            System.Console.WriteLine("Qual registro você quer atualizar?");
            int input = int.Parse(Console.ReadLine());

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

            foreach (int item in Enum.GetValues(typeof(Categoria)))
            {
                System.Console.WriteLine($"{item} - {Enum.GetName(typeof(Categoria), item)}");
            }
            System.Console.WriteLine("Selecione a categoria do registro:");
            int entradaCategoria = int.Parse(Console.ReadLine());


            Series objeto = new Series(
                Id: repositorio.ProximoId(),
                genero : (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao,
                categoria: (Categoria)entradaCategoria,
                Excluido : false
            );

            repositorio.Atualizar(input,objeto);
        }

        private static void VisualizarRegistro()
        {
            System.Console.WriteLine("Digite o ID do item que deseja visualizar: ");
            int input = int.Parse(Console.ReadLine());
            System.Console.WriteLine(repositorio.RetornaPorID(input));    
        }

        private static void ExcluirRegistro()
        {
            System.Console.WriteLine("Digite o ID do registro para excluir :");
            int input = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Tem certeza que deseja excluir o registro de ID "+input+"? \n Digite 1 para Sim \n Digite 2 para Não e escolher outro registro \n Digite 3 para retornar ao menu");
            int decision = int.Parse(Console.ReadLine());
            switch (decision)
            {
                case 1:
                repositorio.Excluir(input);
                break;

                case 2:
                ExcluirRegistro();
                break;

                case 3:
                break;

                default:
                System.Console.WriteLine("Opção não esta presente na lista, por favor, digite um número válido");
                break;
            }
            
        }

        private static void InserirRegistro()
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

            foreach (int item in Enum.GetValues(typeof(Categoria)))
            {
                System.Console.WriteLine($"{item} - {Enum.GetName(typeof(Categoria), item)}");
            }
            System.Console.WriteLine("Selecione a categoria do registro:");
            int entradaCategoria = int.Parse(Console.ReadLine());

            Series objeto = new Series(
                Id: repositorio.ProximoId(),
                genero : (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao,
                categoria: (Categoria)entradaCategoria,
                Excluido : false
            );

            repositorio.insere(objeto);
        }

        private static void ListarRegistro()
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
                var excluido = item.retornaExcluido();
                Console.WriteLine("ID: {0}: - {1} {2}", item.retornaId(), item.retornaTitulo(), (excluido ? "*Excluído*" : ""));
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
