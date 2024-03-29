﻿using System;

namespace APPCadastroSeriesUnimedBH
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("O Grupo Trugilho agradece por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série/filme: ");
            int indiceSerie = int.Parse(Console.ReadLine()!);

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série/filme: ");
            int indiceSerie = int.Parse(Console.ReadLine()!);

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série/filme: ");
            int indiceSerie = int.Parse(Console.ReadLine()!);

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o Título da série/filme: ");
            string? entradaTitulo = Console.ReadLine();

            Console.Write("Qual a duração da sua Serie/Filme? (Em minutos)");
            float duracao = float.Parse(Console.ReadLine()!);

            Console.Write("Digite o Ano de Início da série/filme: ");
            int entradaAno = int.Parse(Console.ReadLine()!);

            Console.Write("Digite a Descrição da série/filme: ");
            string entradaDescricao = Console.ReadLine()!;

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo!,
                                        duracao: duracao,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries/filmes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série/filme cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série/filme");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o Título da série/filme: ");
            string? entradaTitulo = Console.ReadLine();

            Console.Write("Qual a duração da sua Serie/Filme? (Em minutos)");
            float Duracao = float.Parse(Console.ReadLine()!);

            Console.Write("Digite o Ano de Início da série/filme: ");
            int entradaAno = int.Parse(Console.ReadLine()!);

            Console.Write("Digite a Descrição da série/filme: ");
            string? entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        duracao: Duracao,
                                        titulo: entradaTitulo!,
                                        ano: entradaAno,
                                        descricao: entradaDescricao!);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Trugilho séries/filmes para sua diversão!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries/filmes");
            Console.WriteLine("2- Inserir nova série/filme");
            Console.WriteLine("3- Atualizar série/filme");
            Console.WriteLine("4- Excluir série/filme");
            Console.WriteLine("5- Visualizar série/filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine()!.ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
