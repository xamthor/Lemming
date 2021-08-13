using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Lemming
{
    class Program
    {
        public static Task Main(string[] args) => Startup.RunAsync(args);
    }
}