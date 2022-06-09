using System.Collections.Concurrent;
using RadRiftGame.Contracts.ValueObjects;

namespace RadRiftGame.Domain.Projections
{
    public static class InMemoryMinuteStore
    {
        public static ConcurrentDictionary<GameRoomId, int> Index =
            new ConcurrentDictionary<GameRoomId, int>();
    }
}