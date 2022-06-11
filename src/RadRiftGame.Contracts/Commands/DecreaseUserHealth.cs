using System;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Contracts.Commands
{
    public class DecreaseUserHealth : Command
    {
        public readonly GameRoomId GameId;
        public readonly UserId UserId;
        public readonly int HealthDec;
        public readonly SysInfo SysInfo;

        public DecreaseUserHealth(GameRoomId gameId, UserId userId, SysInfo sysInfo, int healthDec)
        {
            GameId = gameId;
            UserId = userId;
            SysInfo = sysInfo;
            HealthDec = healthDec;
            Console.WriteLine($"Decrease Health {UserId.Id} for {healthDec} point");
        }
    }
}