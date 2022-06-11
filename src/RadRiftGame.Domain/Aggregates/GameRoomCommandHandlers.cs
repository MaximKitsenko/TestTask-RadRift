using RadRiftGame.Contracts.Commands;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Aggregates
{
    public class GameRoomCommandHandlers
    {
        private readonly IRepository<GameRoom> _repository;

        public GameRoomCommandHandlers(IRepository<GameRoom> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateGameRoom message)
        {
            var item = new GameRoom(message.GameId, message.Name, message.HostUserId);
            _repository.Save(item, -1);
        }
        public void Handle(JoinGameRoom message)
        {
            var item = _repository.GetById(message.GameId.Id);
            item.EnterUser(message.SysInfo, message.GameId, message.UserId);
            _repository.Save(item, item.Version );
        }
        public void Handle(DecreaseUserHealth message)
        {
            var item = _repository.GetById(message.GameId.Id);
            item.DecreaseHealth(message.SysInfo, message.GameId, message.UserId, message.HealthDec);
            _repository.Save(item, item.Version );
        }
    }
}