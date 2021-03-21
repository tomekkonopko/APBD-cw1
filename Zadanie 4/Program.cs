using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Zadanie_4
{
    class Program
    {
        public async static System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                if (args.Length == 0) throw new ArgumentException("Parametr nie został podany");

                if (!Uri.IsWellFormedUriString(args[0], UriKind.Absolute))
                    throw new ArgumentException("Adres URL jest błędny");

                var httpClient = new HttpClient();
                var url = args[0];
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync();

                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var matches = regex.Matches(htmlContent);

                    foreach (var match in matches)
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            catch (Exception exc)
            {
                string blad = string.Format("Napotkalem blad", exc.ToString());
                Console.WriteLine("Tresc bledu: " + exc.ToString());
            }

        }
    }
}
