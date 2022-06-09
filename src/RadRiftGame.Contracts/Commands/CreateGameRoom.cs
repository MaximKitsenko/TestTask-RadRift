using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Contracts.Commands
{
    public class CreateGameRoom : Command
    {
        public readonly GameRoomId GameId;
        public readonly string Name;
        public readonly SysInfo SysInfo;

        public CreateGameRoom(GameRoomId gameId, string name, SysInfo sysInfo)
        {
            GameId = gameId;
            Name = name;
            SysInfo = sysInfo;
        }
    }
}
