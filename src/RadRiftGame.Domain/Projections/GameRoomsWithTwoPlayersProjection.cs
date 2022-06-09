using RadRiftGame.Contracts.Events;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Projections
{
    public class GameRoomsWithTwoPlayersProjection :
        Handles<UserJoinedGameRoom>
    {

        public void Handle(UserJoinedGameRoom message)
        {
            InMemoryMinuteStore
                .Index[message.GameRoomId] += 1;
        }

        public void Handle(GameRoomCreated message)
        {
            InMemoryMinuteStore
                .Index[message.Id] = 1;
        }
    }
}