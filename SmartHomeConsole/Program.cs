using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Smart Home Console Controller ===");
            Console.WriteLine("1. Turn Light ON");
            Console.WriteLine("2. Turn Light OFF");
            Console.WriteLine("3. Exit");
            Console.Write("\nEnter your choice: ");

            string? input = Console.ReadLine();

            if (input is null)
            {
                Console.WriteLine("No input received!");
                continue;
            }


            if (input == "1")
            {
                await SendCommand(client, "http://192.168.1.50/light/on");
            }
            else if (input == "2")
            {
                await SendCommand(client, "http://192.168.1.50/light/off");
            }
            else if (input == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, try again...");
                await Task.Delay(1000);
            }
        }
    }

    static async Task SendCommand(HttpClient client, string url)
    {
        try
        {
            await client.GetAsync(url);
            Console.WriteLine("Command sent successfully!");
        }
        catch
        {
            Console.WriteLine("Error: Device not reachable!");
        }
        await Task.Delay(1500);
    }
}
