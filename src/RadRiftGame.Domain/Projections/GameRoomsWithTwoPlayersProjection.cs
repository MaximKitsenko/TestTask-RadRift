using RadRiftGame.Contracts.Events;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Projections
{
    public class GameRoomsWithTwoPlayersProjection :
        Handles<UserJoinedGameRoom>,
        Handles<GameRoomCreated>
    {

        public void Handle(UserJoinedGameRoom message)
        {
            InMemoryKvStore
                .RoomUsersCountIndex[message.GameRoomId] += 1;
        }

        public void Handle(GameRoomCreated message)
        {
            InMemoryKvStore
                .RoomUsersCountIndex[message.Id] = 1;
        }
    }
}