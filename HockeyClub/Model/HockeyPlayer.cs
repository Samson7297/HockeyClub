using System;

namespace HockeyClub.Model
{
    public class HockeyPlayer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int GameNumber { get; set; }
        public DateTime DateBirthday { get; set; }
        public string Role { get; set; }
        public int Height { get; set; }
        public string Size { get; set; }
        public string PhoneNumber { get; set; }


        public HockeyPlayer (int id, int gameNumber, string fullName, DateTime dateBirthday, string role, int height, string size, string phoneNumber)
        {
            Id = id;
            GameNumber = gameNumber;
            FullName = fullName;
            DateBirthday = dateBirthday;
            Role = role;
            Height = height;
            Size = size;
            PhoneNumber = phoneNumber;
        }
    }
}
