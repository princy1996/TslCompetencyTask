using TslCompetencyTaskUi.Models.Classes.Interfaces;

namespace TslCompetencyTaskUi.Models.Classes
{
    public class Config
    {
        public const string ConfigRef = "AppConfig";

        public string ConnectionString { get; set; }
        public string JWTBearer { get; set; }
    }
}
