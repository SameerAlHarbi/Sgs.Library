using Microsoft.Extensions.Configuration;

namespace Sgs.Library.Mvc.Services
{
    public class AppInfoManager : IAppInfo
    {
        private IConfiguration _config;

        public AppInfoManager(IConfiguration config)
        {
            _config = config;
        }

        public string GetAppName()
        {
            //return _config["AppName"];
            return "My Library";
        }
    }
}
