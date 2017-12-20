using Rocket.API;

namespace Crux.EzMessageAnnouncer
{
    public class Configuration : IRocketPluginConfiguration
    {
        public string Message1;
        public string Message2;
        public string Message3;
        public string Message4;

        public float MessageInterval;

        public void LoadDefaults()
        {
            Message1 = "Welcome to SERVER_NAME, Have a great stay ;)";
            Message2 = "Be sure to join our discord.";
            Message3 = "Please be respectful towards others.";
            Message4 = "All communication remains in English.";

            MessageInterval = 300;
        }
    }
}
