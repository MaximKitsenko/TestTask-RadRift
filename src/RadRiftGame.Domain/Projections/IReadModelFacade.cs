using System;
using System.Collections.Generic;

namespace RadRiftGame.Domain.Projections
{
    public interface IReadModelFacade
    {
        IEnumerable<RoomListDto> GetChatRooms();
    }
}