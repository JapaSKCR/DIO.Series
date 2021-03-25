using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcoes = opcaoDoUsuario();

            while(opcoes.ToUpper() != "X")
            {
                switch(opcoes){
                    case "1": 
                    Listar();
                    break;
                    case "2": 
                    Inserir();
                    break;
                    case "3": 
                    Atualizar();
                    break;
                    case "4": 
                    Excluir();
                    break;
                    case "5": 
                    Visualizar();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    default:
                    throw new ArgumentOutOfRangeException();
            
                }
                opcoes = opcaoDoUsuario();
            }
       
        }
        private static void Listar()
        {
            Console.WriteLine("Listar séries");
            var listaSerie =  repositorio.Lista();
            if(listaSerie.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in listaSerie)
            {
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.GetId(), serie.GetTitulo(), (serie.GetExcluido() ? "*Serie Indisponível": "")); 
            }

        }
         private static void Inserir()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0} - {1}", i, Enum.GetName(typeof(Genero), i)); 
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int opcaoGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string opcaoTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição da Série: ");
            string opcaoDescricao = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int opcaoAno = int.Parse(Console.ReadLine());

            repositorio.Add(
                        new Serie(id: repositorio.ProximoId(), 
                                      genero: (Genero)opcaoGenero, 
                                      titulo: opcaoTitulo, 
                                      descricao: opcaoDescricao, 
                                      ano: opcaoAno)
                                 );

        }

        private static void Atualizar()
        {
              Console.WriteLine("Atualizar série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0} - {1}", i, Enum.GetName(typeof(Genero), i)); 
            }

            Console.WriteLine("Digite o id da Série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int opcaoGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string opcaoTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição da Série: ");
            string opcaoDescricao = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int opcaoAno = int.Parse(Console.ReadLine());

            repositorio.Update(id: idSerie,
                        new Serie(id: idSerie, 
                                      genero: (Genero)opcaoGenero, 
                                      titulo: opcaoTitulo, 
                                      descricao: opcaoDescricao, 
                                      ano: opcaoAno)
                             );

        }

        private static void Excluir()
        {
            Console.WriteLine("Digite o id da Série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Remove(idSerie);
        }

        private static void Visualizar()
        {
            Console.WriteLine("Digite o id da Série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.GetbyId(idSerie));
            
        }
       
        private static string opcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series Online é nois q ta");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoDoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoDoUsuario;
        } 
    }

}
