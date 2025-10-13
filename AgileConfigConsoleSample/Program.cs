using System;
using System.Threading.Tasks;
using AgileConfig.Client;

namespace AgileConfigConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Console or class-library projects may not have an appsettings.json file,
            // so use the constructor overload to supply appId and other settings manually.
            // If the console app does include appsettings.json you can use the parameterless
            // constructor, just like an MVC project, to load the settings automatically.
            var appId = "test_app";
            var secret = "test_app";
            var nodes = "http://agileconfig-server.xbaby.xyz/";
            // Provide appId and related settings explicitly via the constructor.
            var client = new ConfigClient(appId, secret, nodes, "DEV");
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(5000);
                    foreach (string key in client.Data.Keys)
                    {
                        var val = client[key];
                        Console.WriteLine("{0} : {1}", key, val);
                    }
                }
            });

            client.ConnectAsync();// Non-MVC projects that do not call AddAgileConfig need to invoke ConnectAsync manually.

            Console.WriteLine("Test started .");
            Console.Read();
        }
    }
}
