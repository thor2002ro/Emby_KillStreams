using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KillStreams
{
    public class PlayingSession
    {
        public string SessionId { get; set; }
        public DateTime PlayingAtTimeUtc { get; set; }
        public DateTime KillAtTimeUtc { get; set; }
    }

    public static class PlayingSessionsHelper
    {
        private static List<PlayingSession> PlayingSessions { get; set; }

        public static void AddSessionToList(string sessionId)
        {
            var duration = Plugin.Instance.PluginConfiguration.PlayingDurationH == 0 ? 5 : Plugin.Instance.PluginConfiguration.PlayingDurationH;

            PlayingSessions ??= new List<PlayingSession>();

            if (!PlayingSessions.Select(x => x.SessionId).Contains(sessionId))
            {
                PlayingSessions.Add(new PlayingSession { SessionId = sessionId, PlayingAtTimeUtc = DateTime.UtcNow, KillAtTimeUtc = DateTime.UtcNow.AddHours(duration) });
            }
        }

        public static void RemoveSessionFromList(string sessionId)
        {
            PlayingSessions ??= new List<PlayingSession>();

            PlayingSessions.RemoveAll(x => x.SessionId == sessionId);
        }

        public static List<PlayingSession> GetSessionsToKill()
        {
            PlayingSessions ??= new List<PlayingSession>();

            var output = PlayingSessions.Where(x => x.KillAtTimeUtc <= DateTime.UtcNow).ToList();

            return output;
        }
    }
}