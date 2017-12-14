using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections;
using UnityEngine;

using Logger = Rocket.Core.Logging.Logger;

namespace Crux.EzMessageAnnouncer
{
    public class EzMessageAnnouncer : RocketPlugin<Configuration>
    {
        public static EzMessageAnnouncer Instance;
        public static Configuration Config => Instance.Configuration.Instance;

        protected override void Load()
        {
            Instance = this;

            U.Events.OnPlayerConnected += Events_OnPlayerConnected;

            Logger.Log("EzMessageAnnouncer Sucessfully Loaded!", color: ConsoleColor.Green);

            loop();
        }

        protected override void Unload()
        {
            Logger.Log("EzMessageAnnouncer Sucessfully Unloaded!");

            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
        }

        void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            if (player != null)
            {
                StartCoroutine(StartDelayedUrlRequest(player));
            }
        }

        private IEnumerator StartDelayedUrlRequest(UnturnedPlayer player)
        {
            yield return new WaitForSeconds(1.5f);
        }

        public static IEnumerator loop()
        {
            while (true)
            {
                UnturnedChat.Say(Config.Message1);

                yield return new WaitForSeconds(Config.MessageInterval);
                UnturnedChat.Say(Config.Message2);

                yield return new WaitForSeconds(Config.MessageInterval);
                UnturnedChat.Say(Config.Message3);

                yield return new WaitForSeconds(Config.MessageInterval);
                UnturnedChat.Say(Config.Message4);

                yield return new WaitForSeconds(Config.MessageInterval);
            }
        }
    }
}
