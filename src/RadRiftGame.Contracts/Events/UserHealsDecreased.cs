using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Contracts.Events
{
    public class UserHealsDecreased : Event
    {
        public GameRoomId GameRoomId { get; }
        public UserId UserId { get; }
        
        public int HealthDecrease { get; }
        public SysInfo SysInfo { get; }

        public UserHealsDecreased(SysInfo sysInfo, GameRoomId gameRoomId, UserId userId, int healthDecrease)
        {
            GameRoomId = gameRoomId;
            UserId = userId;
            HealthDecrease = healthDecrease;
            SysInfo = sysInfo;
        }
    }
}