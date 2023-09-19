using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Discord_Bot_CHATP
{
    class Program
    {
        DiscordSocketClient client;
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "token";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
                switch(msg.Content)
                {
                    case "!help":
                        {
                            msg.Channel.SendMessageAsync($"Need help, {msg.Author}");
                            break;
                        }
                    case "!random":
                        {
                            Random rnd = new Random();
                            msg.Channel.SendMessageAsync($"Random number {rnd.Next(-1000, 1000)}");
                        }
                        break;
                }
            return Task.CompletedTask;
        }
    }
}
