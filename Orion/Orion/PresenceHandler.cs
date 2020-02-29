using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace Orion
{
    class PresenceHandler
    {
        public DiscordRpcClient client;
        public void StartRPC()
        {
            string details = "Roblox Executor";
            string state = "Open-Sourced";
            string largeimagetext = "Made by ArilisDev";

            client = new DiscordRpcClient("683151267996106807");
            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Assets = new Assets()
                {
                    LargeImageKey = "circle",
                    LargeImageText = largeimagetext
                }
            });
        }
    }
}
