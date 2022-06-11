using System;

namespace RadRiftGame.Models.GameController
{
    public class CreateGameRoomRequest
    {
        public string Name { get; set; }
        public Guid HostUserId { get; set; }
    }
}