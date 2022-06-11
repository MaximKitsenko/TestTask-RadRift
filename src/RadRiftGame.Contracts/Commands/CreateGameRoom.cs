using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Contracts.Commands
{
    public class CreateGameRoom : Command
    {
        public readonly GameRoomId GameId;
        public readonly string Name;
        public readonly UserId HostUserId;
        public readonly SysInfo SysInfo;

        public CreateGameRoom(GameRoomId gameId, string name, UserId hostUserId, SysInfo sysInfo)
        {
            GameId = gameId;
            Name = name;
            HostUserId = hostUserId;
            SysInfo = sysInfo;
        }
    }
}
