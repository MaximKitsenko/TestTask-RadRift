using System;
using RadRiftGame.Domain.Aggregates;
using RadRiftGame.Domain.Services.Db;

namespace RadRiftGame.Domain.Services.ReportService
{
    public class GameReportService:IGameReportService, IDisposable
    {
        private GamDbContext2 GamesDbContext { get; }

        public GameReportService(GamDbContext2 gamesDbContext)
        {
            GamesDbContext = gamesDbContext;
        }

        public void ReportGameResult(GameResult gameRoom)
        {
            GamesDbContext.GamesResults.Add(gameRoom);
            GamesDbContext.SaveChanges();
        }

        public void Dispose()
        {
            GamesDbContext?.Dispose();
        }
    }
}