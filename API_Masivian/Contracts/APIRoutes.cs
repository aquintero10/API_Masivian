
namespace API_Masivian.Contracts
{
    public static class ApiRoutes
    {
        public const string main = "api/";

        public const string version = "v1/";

        public const string Base = main + version;

        public const string AddRoulette = Base + "AddRoulette";

        public const string OpenRoulette = Base + "OpenRoulette";

        public const string BetInRoulette = Base + "BetInRoulette";

        public const string CloseRoulette = Base + "CloseRoulette";

        public const string GetAllRoulettes = Base + "GetAllRoulettes";
    }
}
