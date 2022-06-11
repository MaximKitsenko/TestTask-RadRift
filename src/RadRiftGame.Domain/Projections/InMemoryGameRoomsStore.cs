using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Domain.Aggregates;

namespace RadRiftGame.Domain.Projections
{
    public static class InMemoryKvStore
    {
        public static ConcurrentDictionary<GameRoomId, int> RoomUsersCountIndex =
            new ConcurrentDictionary<GameRoomId, int>();
        
        public static ConcurrentDictionary<GameRoomId, List<UserId>> RoomUsersIndex =
            new ConcurrentDictionary<GameRoomId, List<UserId>>();
        
        public static ConcurrentDictionary<GameRoomId, GameStatus> RoomsstartedUsersIndex =
            new ConcurrentDictionary<GameRoomId, GameStatus>();
        
        public static ConcurrentDictionary<GameRoomId, ConcurrentDictionary<UserId,int>> UsersHealth =
            new ConcurrentDictionary<GameRoomId, ConcurrentDictionary<UserId,int>>();
    }
}