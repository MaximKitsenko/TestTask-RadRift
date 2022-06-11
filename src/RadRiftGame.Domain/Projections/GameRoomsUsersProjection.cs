using System.Collections.Generic;
using RadRiftGame.Contracts.Events;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Projections
{
    public class GameRoomsUsersProjection :
        Handles<UserJoinedGameRoom>,
        Handles<GameRoomCreated>
    {
        public void Handle(UserJoinedGameRoom message)
        {
            InMemoryKvStore 
                .RoomUsersIndex[message.GameRoomId].Add(message.UserId);
        }

        public void Handle(GameRoomCreated message)
        {
            InMemoryKvStore
                .RoomUsersIndex[message.Id] = new List<UserId>() {message.SysInfo.UserId};
        }
    }
}