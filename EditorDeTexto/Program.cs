using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EditorDeTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Novo Arquivo");
            Console.WriteLine("0 - Sair");
            Console.Write("\nSelecione uma opção: ");

            short opcao = Convert.ToInt16(Console.ReadLine());

            switch (opcao)
            {
                case 0: System.Environment.Exit(0); break;

                case 1: Abrir(); break;

                case 2: Novo(); break;

                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.Write("Digite o caminho do arquivo que deseja abrir: ");

            string camninho = Console.ReadLine();

            Console.WriteLine("----------------------------------------\n");

            using (var arquivo = new StreamReader(camninho))
            {
                string texto = arquivo.ReadToEnd();

                Console.WriteLine(texto);
            }

            Console.ReadLine();

            Menu();
        }

        static void Novo()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo. (ESC para sair)");
            Console.WriteLine("----------------------------------------");

            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);
        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.Write("Digite o caminho para salvar o arquivo: ");

            var caminho = Console.ReadLine();

            Console.WriteLine("----------------------------------------\n");

            using (var arquivo = new StreamWriter(caminho))
            {
                arquivo.Write(texto);
            }

            Console.Clear();
            Console.WriteLine($"Arquivo salvo com sucesso em {caminho}");
            Console.ReadLine();
            Menu();
        }
    }
}
