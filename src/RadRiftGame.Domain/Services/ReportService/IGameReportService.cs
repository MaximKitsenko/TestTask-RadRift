using RadRiftGame.Domain.DbModels;

namespace RadRiftGame.Domain.Services.ReportService
{
    public interface IGameReportService
    {
        void ReportGameResult(GameResult gameRoom);
    }
}