using System.Collections.Generic;
using RadRiftGame.Contracts.Events;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Domain.Services.Db;
using RadRiftGame.Domain.Services.ReportService;
using RadRiftGame.Infrastructure;

namespace RadRiftGame.Domain.Projections
{
    public class GameRoomsStatusProjectionExtended :
        Handles<GameStopped>,
        Handles<GameRoomCreated>
    {
        private IGameReportService gameReportSrv { get; set; }

        public GameRoomsStatusProjectionExtended(IGameReportService gameReportSrv)
        {
            this.gameReportSrv = gameReportSrv;
        }

        public void Handle(GameStopped message)
        {
          gameReportSrv.ReportGameResult(new GameResult()
            {
                GameId = message.GameRoomId.Id,
                // Player1Id = this._player1.Id,
                // Player1Health = this._player1Health,
                // HostId = this._host.Id,
                // HostHealth = this._hostHealth,
                Status = "GameStopped",
            });
        }

        public void Handle(GameRoomCreated message)
        {
            InMemoryKvStore
                .RoomUsersIndex[message.Id] = new List<UserId>() {message.SysInfo.UserId};
        }
    }
}