using RadRiftGame.Domain.Aggregates;
using RadRiftGame.Domain.Services.Db;

namespace RadRiftGame.Domain.Services.ReportService
{
    public class GameReportService:IGameReportService
    {
        private GamesDbContext GamesDbContext { get; }

        public GameReportService(GamesDbContext gamesDbContext)
        {
            GamesDbContext = gamesDbContext;
        }

        public void ReportGameResult(GameResult gameRoom)
        {
            GamesDbContext.GameResults.Add(gameRoom);
        }
    }
}