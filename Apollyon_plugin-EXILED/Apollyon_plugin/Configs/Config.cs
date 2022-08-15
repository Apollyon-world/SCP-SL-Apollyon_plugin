using Apollyon_plugin.Configs;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Apollyon_plugin
{
    public sealed class Config : IConfig
    {
        private bool isEnabled = true;

        public bool GetIsEnabled()
        {
            return isEnabled;
        }

        public void SetIsEnabled(bool value)
        {
            isEnabled = value;
        }

        [Description("Whether or not debug messages will be shown")]
        public bool Debug { get; set; } = false;

        [Description("Options for Manager O5 players")]
        public SerpentsHandModifiers SerpentsHandModifiers { get; set; } = new SerpentsHandModifiers();

        [Description("Options for Manager O5 spawn")]
        public SpawnManager SpawnManager { get; set; } = new SpawnManager();

        public bool IsEnabled { get; set; } = true;

        [Description("Sets the message for when the round starts.")]
        public string RoundStartedMessage { get; set; } = "Site-69 est en alerte, veuillez �vacuez imm�diatement !";
    }
}
