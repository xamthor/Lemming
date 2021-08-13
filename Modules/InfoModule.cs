using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Lemming.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
            => ReplyAsync(echo);

        [Command("disclosure")]
        [Summary("Lon disclosure")]
        public async Task SearchAsync()
        {
            var builder = new EmbedBuilder()
            {
                Color = new Color(114, 137, 218),
            };
            
            string block = "I always disclose how I acquired the gadget in the video description. For product samples sent to me directly from manufacturers I disclose that in the video itself. Some products I receive through the Amazon Vine program which are sent to me by Amazon for review on their site. Many other products I buy myself, review, and resell on my store at http://lon.tv/store . \n Sometimes I am allowed to keep the products sent to me, but free product never guarantees a positive review. When I receive products I review them. If it's bad I will say so.";
            
            builder.AddField(x =>
            {
                x.Name = "Disclosure";
                x.Value = block;
                x.IsInline = false;
            });
            
            await ReplyAsync("", false, builder.Build());
        }
    }
}
    