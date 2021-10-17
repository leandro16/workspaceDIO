using CadastroAppDio.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAppDio
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = Tela();
            
            while (opcao.ToUpper() != "S")
            {               

                switch (opcao)
                {
                    case "1":
                        //implementa criar serie
                        CriarSerie();
                        break;
                    case "2":
                        //implementa atualizar serie
                        AtualizarSerie();
                        break;
                    case "3":
                        //implementa listar serie
                        ListarSerie();
                        break;
                    case "4":
                        //implementa deletar serie
                        DeletarSerie();
                        break;
                    default:
                        //implementa sair app
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void DeletarSerie()
        {
            Console.WriteLine("Informe uma sèrie:");
            int auxSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(auxSerie);
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar uma séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""));
            }
        }
        
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero: ");
            int auxGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string auxTitulo = Console.ReadLine();

            Console.Write("Digite o Ano da série: ");
            int auxAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string auxDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)auxGenero,
                                        titulo: auxTitulo,
                                        ano: auxAno,
                                        descricao: auxDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void CriarSerie()
        {
            Console.WriteLine("Criar nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero: ");
            int auxGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título: ");
            string auxTitulo = Console.ReadLine();

            Console.Write("Digite o ano: ");
            int auxAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string auxDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)auxGenero,
                                        titulo: auxTitulo,
                                        ano: auxAno,
                                        descricao: auxDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string Tela()
        {
            Console.WriteLine("*****MENU PRICIPAL*****");
            Console.WriteLine("1 - Criar Uma Nova Série");
            Console.WriteLine("2 - Atualizar Uma Nova Série");
            Console.WriteLine("3 - Listar Uma Nova Série");
            Console.WriteLine("4 - Deletar Uma Nova Série");
            Console.WriteLine("S - Deseja Sair");
            string opcoes = Console.ReadLine().ToUpper();
            return opcoes;

        }
    }
}
