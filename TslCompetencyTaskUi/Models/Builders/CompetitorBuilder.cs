using TslCompetencyTaskUi.Models.Classes;
using TslCompetencyTaskUi.Models.Dtos.Interfaces;

namespace TslCompetencyTaskUi.Models.Builders
{
    public class CompetitorBuilder
    {
        private Competitor _competitor = new Competitor();

        public CompetitorBuilder AddId(string id)
        {
            _competitor.Id = id; return this;
        }
        public CompetitorBuilder AddStartNumber(string? num)
        {
            _competitor.StartNumber = num; return this;
        }
        public CompetitorBuilder AddName(string? name)
        {
            _competitor.Name = name; return this;
        }
        public CompetitorBuilder AddTeam(string? teamName)
        {
            _competitor.TeamName = teamName; return this;
        }
        public CompetitorBuilder AddClass(string? name)
        {
            _competitor.ClassName = name; return this;
        }
        public CompetitorBuilder AddPosition(int? pos)
        {
            _competitor.Position = pos; return this;
        }
        public CompetitorBuilder IsFinished(bool fin)
        {
            _competitor.Finished = fin; return this;
        }
        public CompetitorBuilder AddFastestLap(ITimeDto? time)
        {
            Time timeCon = new Time();
            if (time is null)
            {
                timeCon = new TimeBuilder().NullBuild();
            }
            else
            {
                timeCon = new TimeBuilder().AddDisplay(time.display).AddRawMs(time.rawMs).Build();
            }
            _competitor.FastestLapTime = timeCon; return this;
        }
        public CompetitorBuilder AddLastLap(ITimeDto? time)
        {
            Time timeCon = new Time();
            if (time is null)
            {
                timeCon = new TimeBuilder().NullBuild();
            }
            else
            {
                timeCon = new TimeBuilder().AddDisplay(time.display).AddRawMs(time.rawMs).Build();
            }
            _competitor.LastLapTime = timeCon; return this;
        }
        public CompetitorBuilder AddCurrentLapSectorTimes(Dictionary<string, ITimeDto?> times)
        {
            Dictionary<string, Time?> newTimes = new Dictionary<string, Time?>();
            foreach (KeyValuePair<string, ITimeDto?> values in times)
            {
                //Should handle in builder properly, will do later
                if (values.Value == null)
                {
                    newTimes.Add(values.Key, new TimeBuilder().NullBuild());
                }
                else
                {
                    newTimes.Add(values.Key, new TimeBuilder().AddDisplay(values.Value.display).AddRawMs(values.Value.rawMs).Build() ?? null);
                }
            }
            _competitor.CurrentLapSectorTimes = newTimes; return this;
        }

        public Competitor Build()
        {
            return _competitor;
        }
    }
}
