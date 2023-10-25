using System.Collections.Generic;
using System.Threading.Tasks;

namespace HockeyClub.Model
{
    public interface IRepository
    {
        void AddHockeyPlayer(HockeyPlayer player);
        void AddStick(Stick stick);
        void AddUsageStick(UsageStick usageStick);
        void DeleteHockeyPlayer(HockeyPlayer player);
        void DeleteStick(Stick stick);
        void DeleteUsageStick(UsageStick usageStick);
        Task<List<HockeyPlayer>> GetAllHockeyPlayers();
        Task<List<Stick>> GetAllSticks();
        Task<List<UsageStick>> GetAllUsageSticks();
        void UpdateHockeyPlayer(HockeyPlayer player);
        void UpdateStick(Stick stick);
        void UpdateUsageStick(UsageStick usageStick);
    }
}