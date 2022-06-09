using System;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Contracts.Events
{
    public class GameRoomCreated: Event
    {
        public GameRoomId Id { get; }
        public string Name { get; }
        
        public SysInfo SysInfo { get; }

        public GameRoomCreated(GameRoomId id, string name, SysInfo sysInfo)
        {
            Id = id;
            Name = name;
            SysInfo = sysInfo;
        }
    }
}