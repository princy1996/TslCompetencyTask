namespace TslCompetencyTaskUi.Models.Classes.Interfaces
{
    public interface IConfig
    {
        public string ConnectionString { get; set; }
        public string JWTBearer { get; set; }
    }
}
