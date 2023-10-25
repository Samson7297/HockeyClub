using HockeyClub.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HockeyClub.ViewModel
{
    public class UsageStickViewModel: TableViewModelBase
    {
        private ObservableCollection<UsageStick> usageSticks;
        private UsageStick selectedUsageStick;

        public ObservableCollection<UsageStick> UsageSticks
        {
            get { return usageSticks; }
            set
            {
                usageSticks = value;
                OnPropertyChanged();
            }
        }

        public UsageStick SelectedUsageStick
        {
            get { return selectedUsageStick; }
            set
            {
                selectedUsageStick = value;
                OnPropertyChanged();
            }
        }

        public UsageStickViewModel(IRepository repository, List<UsageStick> usageSticks) : base(repository)
        {
            UsageSticks = new ObservableCollection<UsageStick>(usageSticks);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            UpdateCommand = new RelayCommand(Update);
        }

        public override void Add(object parameter)
        {
            var newHockeyPlayer = new HockeyPlayer(31,10, "Балалаев Семён", DateTime.Today, "Защитник", 175, "M", "+7(999)999-99-27");
            var newStick = new Stick(31,"Bauer", "Vapor 3X Pro", 77, 28, "левый");
            var newUsageStick = new UsageStick(newHockeyPlayer, newStick, DateTime.Now, null);
            repository.AddUsageStick(newUsageStick);
            UsageSticks.Add(newUsageStick);
        }

        public override void Delete(object parameter)
        {
            if (SelectedUsageStick != null)
            {
                repository.DeleteUsageStick(SelectedUsageStick);
                UsageSticks.Remove(SelectedUsageStick);
            }
        }

        public override void Update(object parameter)
        {
            if (SelectedUsageStick != null)
            {
                repository.UpdateUsageStick(SelectedUsageStick);
                int index = UsageSticks.IndexOf(SelectedUsageStick);
                if (index >= 0)
                {
                    UsageSticks[index] = SelectedUsageStick;
                }
            }
        }
    }
}
