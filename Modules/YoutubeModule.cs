using System;
using System.Threading.Tasks;
using Discord.Commands;
using Lemming.Services;
using Microsoft.Extensions.Configuration;

namespace Lemming.Modules
{
    [Group("YT")]
    public class YoutubeModule : ModuleBase<SocketCommandContext>
    {
        private readonly IConfigurationRoot _config;
        
        public YoutubeModule(IConfigurationRoot config)
        {
            _config = config;
        }
        
        [Command("random")]
        [Summary("returns a random youtube video of lon.tv")]
        public async Task RandomAsync()
        {
            string data = await new YTService(_config).Random();
            
            await Context.Channel.SendMessageAsync(data);
        }
        
        [Command("search")]
        [Summary("search lon.tv youtube videos")]
        public async Task SearchAsync(string query, int results)
        {
            string data = await new YTService(_config).Search(query, results);
            
            await Context.Channel.SendMessageAsync(data);
        }
    }
}