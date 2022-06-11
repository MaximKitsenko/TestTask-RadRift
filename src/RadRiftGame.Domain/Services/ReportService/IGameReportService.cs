using RadRiftGame.Domain.Services.Db;

namespace RadRiftGame.Domain.Services.ReportService
{
    public interface IGameReportService
    {
        void ReportGameResult(GameResult gameRoom);
    }
}