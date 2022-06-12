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
        
        //https://stackoverflow.com/questions/18922985/concurrent-hashsett-in-net-framework
        public static ConcurrentDictionary<GameRoomId, byte> RoomsstartedUsersIndex =
            new ConcurrentDictionary<GameRoomId, byte>();
        
        public static ConcurrentDictionary<GameRoomId, ConcurrentDictionary<UserId,int>> UsersHealth =
            new ConcurrentDictionary<GameRoomId, ConcurrentDictionary<UserId,int>>();
    }
}