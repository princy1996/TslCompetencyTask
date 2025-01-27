using TslCompetencyTaskUi.Models.Classes;
using TslCompetencyTaskUi.Models.Dtos.Interfaces;
using TslCompetencyTaskUi.Models.Enums;

namespace TslCompetencyTaskUi.Models.Builders
{
    public class RaceDataBuilder
    {
        private RaceData _raceData = new RaceData();

        public RaceDataBuilder AddSessionId(string sessionId)
        {
            _raceData.SessionId = sessionId; return this;
        }
        public RaceDataBuilder AddSeries(string? series)
        {
            _raceData.Series = series; return this;
        }
        public RaceDataBuilder AddTrack(string? track)
        {
            _raceData.SessionId = track; return this;
        }
        public RaceDataBuilder AddSessionState(SessionState sessionState)
        {
            _raceData.SessionState = sessionState; return this;
        }
        public RaceDataBuilder AddStartTime(string? time)
        {
            _raceData.StartTime = time; return this;
        }
        public RaceDataBuilder AddDuration(string? duration)
        {
            _raceData.Duration = duration; return this;
        }
        public RaceDataBuilder AddTimeRemaining(string? time)
        {
            _raceData.TimeRemaining = time; return this;
        }
        public RaceDataBuilder AddClassification(List<ICompetitorDto>? comp)
        {
            List<Competitor?> competitor = new List<Competitor?>();
            foreach (ICompetitorDto compItem in comp)
            {
                competitor.Add(
                    new CompetitorBuilder()
                        .AddId(compItem.id)
                        .AddPosition(compItem.position)
                        .AddLastLap(compItem.lastLapTime)
                        .AddTeam(compItem.teamName)
                        .AddStartNumber(compItem.startNumber)
                        .AddLastLap(compItem.lastLapTime)
                        .AddFastestLap(compItem.fastestLapTime)
                        .AddClass(compItem.className)
                        .AddCurrentLapSectorTimes(compItem.currentLapSectorTimes)
                        .AddName(compItem.name)
                        .Build()
                    );
            }
            _raceData.Classification = competitor; return this;
        }

        public RaceData Build()
        {
            return _raceData;
        }
    }
}
