using RadRiftGame.Contracts.ValueObjects;

namespace RadRiftGame.Domain
{
    public class RoomListDto
    {
        public GameRoomId Id;
        public string Name;

        public RoomListDto(GameRoomId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}