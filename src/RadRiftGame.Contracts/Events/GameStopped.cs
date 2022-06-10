using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Contracts.Events
{
    public class GameStopped : Event
    {
        public GameRoomId GameRoomId { get; }
        public UserId UserId { get; }
        public SysInfo SysInfo { get; }

        public GameStopped(SysInfo sysInfo, GameRoomId gameRoomId, UserId userId)
        {
            GameRoomId = gameRoomId;
            UserId = userId;
            SysInfo = sysInfo;
        }
    }
}