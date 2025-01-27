using TslCompetencyTaskUi.Models.Classes;

namespace TslCompetencyTaskUi.Models.Builders
{
    public class TimeBuilder
    {
        private Time _time = new Time();

        public TimeBuilder AddDisplay(string? display)
        {
            _time.Display = display; return this;
        }

        public TimeBuilder AddRawMs(int raws)
        {
            _time.RawMs = raws; return this;
        }

        public Time Build()
        {
            return _time;
        }

        public Time NullBuild()
        {
            _time = new Time() { Display = "0", RawMs = 0 };
            return _time;
        }
    }
}
