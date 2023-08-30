using MyMovies.Common.Models;

namespace MyMovies.Common.Services
{
    public interface ILogService
    {
        public void Log(LogData logData);
    }
}
