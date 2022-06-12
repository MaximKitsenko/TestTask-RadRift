using System;
using System.Linq;
using System.Threading;
using RadRiftGame.Contracts.Commands;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Domain.Projections;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Services
{
    public class GameProcessService:IGameProcessService
    {
        private readonly Random _rndUser;
        
        private static object _lock = new object();
        private IReadModelFacade _readModel { get; }
        private FakeBus _fakeBus { get; }

        private Timer _timer;

        public GameProcessService(IReadModelFacade readModel, FakeBus fakeBus)
        {
            _readModel = readModel;
            _fakeBus = fakeBus;
            _rndUser = new Random();
            _timer = new Timer((TimerCallback) (state => DecreaseHealth()), null, 0, 1000);
        }

        public void Stub()
        {
            
        }
        
        public void DecreaseHealth()
        {
            var entered = Monitor.TryEnter(_lock,10);
            if (entered)
            {
                try
                {
                    // var rooms = _readModel
                    //     .GetChatRooms()
                    //     .Where(x=>x.Value>1)
                    //     .ToList();
                        
                    var roomsInGame = _readModel
                        .GetJoinedButNotStoppedGames()
                        .ToList();
                    
                    var users = _readModel
                        .GetChatRoomsUsers()
                        .ToList();

                    var roomsWith2Users = (from r in roomsInGame
                        join u in
                            users on r.Key equals u.Key select u).ToList();
            
                    foreach (var room in roomsWith2Users)
                    {
                        var user = _rndUser.Next(0, 2);
                        var health = _rndUser.Next(0, 3);
                        var roomUsers = room.Value;
                        _fakeBus.Send(new DecreaseUserHealth(room.Key, roomUsers[user], SysInfo.CreateSysInfo(), health));
                    }
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }
    }

    public interface IGameProcessService
    {
        void DecreaseHealth();
        void Stub();
    }
}