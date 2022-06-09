using System.Collections.Generic;
using RadRiftGame.Domain.Projections;

namespace RadRiftGame.Domain
{
    public class ReadModelFacade : IReadModelFacade
    {
        public IEnumerable<RoomListDto> GetChatRooms()
        {
            return InMemoryFakeDatabase.Index.Values;
        }
    }
}