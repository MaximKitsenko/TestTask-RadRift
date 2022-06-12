using System.Collections.Concurrent;
using System.Collections.Generic;
using RadRiftGame.Contracts.ValueObjects;

namespace RadRiftGame.Domain
{
    public interface IReadModelFacade
    {
        ConcurrentDictionary<GameRoomId, int> GetChatRooms();
        ConcurrentDictionary<GameRoomId, byte> GetJoinedButNotStoppedGames();
        ConcurrentDictionary<GameRoomId, List<UserId>> GetChatRoomsUsers();
    }
}