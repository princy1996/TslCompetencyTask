using TslCompetencyTaskUi.Models.Classes.Interfaces;

namespace TslCompetencyTaskUi.Models.Classes
{
    public class Config : IConfig
    {
        public string ConnectionString { get; set; }
        public string JWTBearer { get; set; }
    }
}
