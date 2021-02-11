using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Client
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);

            RegisterCommand("do", new Action<int, List<object>, string>((source, args, rawCommand) =>
            {
                string message = string.Join(" ", args.ConvertAll(x => x.ToString()));
                TriggerEvent("chat:addMessage", new
                {
                    // Neon type color
                    color = new[] {127, 255, 0},
                    args = new[] {"[Do]", $"^*{Game.Player.Name}: {message}"}

                });

            }), false);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            Debug.WriteLine($"The resource {resourceName} has been started on the client.");
        }
    }
}
