using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Contracts.Commands
{
    public class JoinGameRoom : Command
    {
        public readonly GameRoomId GameId;
        public readonly UserId UserId;
        public readonly SysInfo SysInfo;

        public JoinGameRoom(GameRoomId gameId, UserId userId, SysInfo sysInfo)
        {
            GameId = gameId;
            UserId = userId;
            SysInfo = sysInfo;
        }
    }
}