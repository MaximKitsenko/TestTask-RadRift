using System.Collections.Concurrent;
using System.Collections.Generic;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Domain.Projections;

namespace RadRiftGame.Domain
{
    public class ReadModelFacade : IReadModelFacade
    {
        public ConcurrentDictionary<GameRoomId, int> GetChatRooms()
        {
            return InMemoryKvStore.RoomUsersCountIndex;
        }
        public ConcurrentDictionary<GameRoomId, List<UserId>> GetChatRoomsUsers()
        {
            return InMemoryKvStore.RoomUsersIndex;
        }
    }
}