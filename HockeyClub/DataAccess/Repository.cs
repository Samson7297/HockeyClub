using HockeyClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyClub.DataAccess
{
    public class Repository : IRepository
    {
        private List<HockeyPlayer> hockeyPlayers;
        private List<Stick> sticks;
        private List<UsageStick> usageSticks;
        public Repository()
        {
            hockeyPlayers = new List<HockeyPlayer>
        {
            new HockeyPlayer(31,87, "Клюев Артем", DateTime.Today, "Нападающий", 182, "L", "+7(999)999-99-26"),
            new HockeyPlayer(12,10, "Балалаев Семён", DateTime.Today, "Защитник", 175, "M", "+7(999)999-99-27")
        };
            sticks = new List<Stick>
            {
                new Stick(34,"Bauer", "NexusGeo", 87, 29, "левый"),
                new Stick(12,"CCM", "Ribcor Trigger 6 Pro", 85, 28, "правый")
            };
            usageSticks = new List<UsageStick>
            {
                new UsageStick (hockeyPlayers [1],sticks [0],DateTime.Now, null)
            };
        }

        public async Task<List<HockeyPlayer>> GetAllHockeyPlayers()
        {
            return await Task.FromResult(hockeyPlayers);
        }

        public async Task<List<Stick>> GetAllSticks()
        {
            return await Task.FromResult(sticks);
        }

        public async Task<List<UsageStick>> GetAllUsageSticks()
        {
            return await Task.FromResult(usageSticks);
        }

        public void AddHockeyPlayer(HockeyPlayer player)
        {
            hockeyPlayers.Add(player);
        }

        public void AddStick(Stick stick)
        {
            sticks.Add(stick);
        }

        public void AddUsageStick(UsageStick usageStick)
        {
            usageSticks.Add(usageStick);
        }

        public void DeleteHockeyPlayer(HockeyPlayer player)
        {
            hockeyPlayers.Remove(player);
        }

        public void DeleteStick(Stick stick)
        {
            sticks.Remove(stick);
        }

        public void DeleteUsageStick(UsageStick usageStick)
        {
            usageSticks.Remove(usageStick);
        }

        public void UpdateHockeyPlayer(HockeyPlayer player)
        {
            var existingPlayer = hockeyPlayers.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.GameNumber = player.GameNumber;
                existingPlayer.FullName = player.FullName;
                existingPlayer.DateBirthday = player.DateBirthday;
                existingPlayer.Role = player.Role;
                existingPlayer.Height = player.Height;
                existingPlayer.Size = player.Size;
                existingPlayer.PhoneNumber = player.PhoneNumber;
            }
        }

        public void UpdateStick(Stick stick)
        {
            var existingStick = sticks.FirstOrDefault(p => p.Id == stick.Id);
            if (existingStick != null)
            {
                existingStick.Brand = stick.Brand;
                existingStick.Model = stick.Model;
                existingStick.Flex = stick.Flex;
                existingStick.Bend = stick.Bend;
                existingStick.Grip = stick.Grip;
            }
        }

        public void UpdateUsageStick(UsageStick usageStick)
        {
            var existingUsageStick = usageSticks.FirstOrDefault(u => u.Id == usageStick.Id);
            if (existingUsageStick != null)
            {
                existingUsageStick.HockeyPlayer = usageStick.HockeyPlayer;
                existingUsageStick.Stick = usageStick.Stick;
                existingUsageStick.IssueDate = usageStick.IssueDate;
                if (usageStick.ReturnDate.HasValue)
                {
                    existingUsageStick.ReturnDate = usageStick.ReturnDate;
                }
            }
        }
    }
}
