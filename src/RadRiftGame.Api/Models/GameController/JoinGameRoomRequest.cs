using RadRiftGame.Contracts.ValueObjects;

namespace RadRiftGame.Models.GameController
{
    public class JoinGameRoomRequest
    {
        public GameRoomId GameRoomId { get; set; }
        public UserId UserId { get; set; }
    }
}