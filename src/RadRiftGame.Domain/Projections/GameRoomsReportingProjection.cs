using RadRiftGame.Contracts.Events;
using RadRiftGame.Domain.Aggregates;
using RadRiftGame.Domain.DbModels;
using RadRiftGame.Domain.Services.ReportService;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Projections
{
    public class GameRoomsReportingProjection :
        Handles<GameStopped>,
        Handles<GameRoomCreated>
    {
        private readonly Repository<GameRoom> _repository;
        private readonly IGameReportService _gameReportSrv;

        public GameRoomsReportingProjection(IGameReportService gameReportSrv, Repository<GameRoom> repository)
        {
            _repository = repository;
            this._gameReportSrv = gameReportSrv;
        }

        public void Handle(GameStopped message)
        {
            var aggr = _repository.GetById(message.GameRoomId.Id);
            _gameReportSrv.ReportGameResult(new GameResult()
            {
                GameId = message.GameRoomId.Id,
                Player1Id = aggr.Player1.Id,
                Player1Health = aggr.PlayerHealth,
                HostId = aggr.Host.Id,
                HostHealth = aggr.HostHealth,
                Status = aggr.GameStatus.ToString(),
            });
        }

        public void Handle(GameRoomCreated message)
        {
        }
    }
}