using AddDocumentSbo.Services;
using System;

namespace AddDocumentSbo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Teste de inclusão de documento com aprovação pelo SAP");

                var connSboService = new ConnectionSboService();
                var docService = new DocumentService();
                var company = connSboService.GetCompany();

                docService.AddDocument(company);

                PrintSuccess();
            }
            catch (Exception ex)
            {
                PrintMessageError(ex.Message);
            }
        }

        private static void PrintSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Operação realizada com sucesso");
            Console.ReadKey();
        }

        private static void PrintMessageError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
