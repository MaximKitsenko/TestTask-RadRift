using System;
using RadRiftGame.Contracts.Events;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Aggregates
{
    public class GameRoom : AggregateRoot
    {
        private string _name;
        private GameRoomId _id;
        private UserId _host;
        private UserId _player1;
        
        public static bool DebugMode = false;

        public void Apply(GameRoomCreated e)
        {
            _id = e.Id;
            _name = e.Name;
            _host = e.SysInfo.UserId;
        }

        public void Apply(UserJoinedGameRoom e)
        {
        }

        public void EnterUser(SysInfo sysInfo, GameRoomId GameRoomId, UserId userId)
        {
            if (this._host != userId && this._player1 == null)
            {
                this.ApplyChange(new UserJoinedGameRoom(sysInfo, GameRoomId, userId));
            }
        }

        public override Guid Id
        {
            get { return _id.Id; }
        }

        public GameRoom()
        {
            // used to create in repository ... many ways to avoid this, eg making private constructor
        }

        public GameRoom(GameRoomId id, string name, UserId userId)
        {
            ApplyChange(new GameRoomCreated(id, name, SysInfo.CreateSysInfo(userId)));
        }
    }
}