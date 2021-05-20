using System;
using MediaBrowser.Model.Plugins;

namespace KillStreams
{
    public class PluginConfig : BasePluginConfiguration
    {
        public Guid Guid = new Guid("1880798F-1EB9-40B3-807A-D52F04DA9A88"); // Also Needs Set In HTML File
        public string PluginName => "KillStreams-thor";
        public string PluginDesc => "Kill Streams Thor";
        
        public bool Allow4KVideoTranscode { get; set; }
        public bool Allow4KAudioTranscode { get; set; }
        public bool NagTranscode { get; set; }
        public short PausedDurationMin { get; set; }
        public short PlayingDurationH { get; set; }
    }
}