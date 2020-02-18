using System;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace b2c_ms_graph
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private static async Task RunAsync()
        {
            // Read application settings from appsettings.json (tenant ID, app ID, client secret, etc.)
            AppSettings config = AppSettingsFile.ReadFromJsonFile();

            // Initialize the client credential auth provider
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(config.AppId)
                .WithTenantId(config.TenantId)
                .WithClientSecret(config.AppSecret)
                .Build();
            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);

            // Set up the Microsoft Graph service client with client credentials
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            Program.PrintCommands();

            try
            {
                while (true)
                {
                    Console.Write("Enter command, then press ENTER: ");
                    string decision = Console.ReadLine();
                    switch (decision.ToLower())
                    {
                        case "1":
                            await UserService.ListUsers(graphClient); ;
                            break;
                        case "2":
                            await UserService.GetUserById(graphClient); ;
                            break;
                        case "3":
                            await UserService.GetUserBySignInName(config, graphClient); ;
                            break;
                        case "4":
                            await UserService.DeleteUserById(graphClient);
                            break;
                        case "5":
                            await UserService.SetPasswordByUserId(graphClient);
                            break;
                        case "6":
                            await UserService.BulkCreate(config, graphClient);
                            break;
                        case "help":
                            Program.PrintCommands();
                            break;
                        case "exit":
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command. Enter 'help' to show a list of commands.");
                            Console.ResetColor();
                            break;
                    }

                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                var innerException = ex.InnerException;
                if (innerException != null)
                {
                    while (innerException != null)
                    {
                        Console.WriteLine(innerException.Message);
                        innerException = innerException.InnerException;
                    }
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
            finally
            {
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        private static void PrintCommands()
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Command  Description");
            Console.WriteLine("====================");
            Console.WriteLine("[1]      Get all users (one page)");
            Console.WriteLine("[2]      Get user by object ID");
            Console.WriteLine("[3]      Get user by sign-in name");
            Console.WriteLine("[4]      Delete user by object ID");
            Console.WriteLine("[5]      Update user password");
            Console.WriteLine("[6]      Create users (bulk import)");
            Console.WriteLine("[help]   Show available commands");
            Console.WriteLine("[exit]   Exit the program");
            Console.WriteLine("-------------------------");
        }
    }
}
