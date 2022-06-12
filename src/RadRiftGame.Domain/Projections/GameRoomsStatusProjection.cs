using RadRiftGame.Contracts.Events;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Projections
{
    public class GameRoomsStatusProjection :
        Handles<GameStopped>,
        Handles<UserJoinedGameRoom>
    {
        public GameRoomsStatusProjection()
        {
        }

        public void Handle(GameStopped message)
        {
            InMemoryKvStore.RoomsstartedUsersIndex.TryRemove(message.GameRoomId, out _);
        }

        public void Handle(UserJoinedGameRoom message)
        {
            InMemoryKvStore.RoomsstartedUsersIndex.TryAdd(message.GameRoomId,1);
        }
    }
}