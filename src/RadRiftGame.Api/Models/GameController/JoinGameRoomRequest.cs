using System;
using RadRiftGame.Contracts.ValueObjects;

namespace RadRiftGame.Models.GameController
{
    public class JoinGameRoomRequest
    {
        public Guid GameRoomId { get; set; }
        public Guid UserId { get; set; }
    }
}