using System;

namespace HockeyClub.Model
{
    public class UsageStick
    {
        public int Id { get; set; }
        public HockeyPlayer HockeyPlayer { get; set; }
        public Stick Stick { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        
        public UsageStick(HockeyPlayer hockeyPlayer, Stick stick, DateTime issueDate, DateTime? returnDate)
        {
            HockeyPlayer = hockeyPlayer;
            Stick = stick;
            IssueDate = issueDate;
            ReturnDate = returnDate;
        }
    }
}
