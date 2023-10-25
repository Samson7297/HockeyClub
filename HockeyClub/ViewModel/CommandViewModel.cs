using HockeyClub.Model;
using System.Collections.Generic;
using System.Windows.Input;

namespace HockeyClub.ViewModel
{
    public class CommandViewModel : ViewModelBase
    {
        private readonly IRepository repository;
        private readonly MainWindowViewModel mmvm;

        public CommandViewModel(IRepository repository, MainWindowViewModel mmvm)
        {
            this.repository = repository;
            this.mmvm = mmvm;
        }

        public ICommand ShowHockeyPlayers
        {
            get { return new RelayCommand(async(_) =>
            {
                List<HockeyPlayer> team = await repository.GetAllHockeyPlayers();
                HockeyPlayerViewModel hpmv = new HockeyPlayerViewModel(repository,team);
                mmvm.CurrentViewModel = hpmv;
            });
            }
        }

        public ICommand ShowSticks
        {
            get
            {
                return new RelayCommand(async(_) =>
                {
                    List<Stick> sticks = await repository.GetAllSticks();
                    StickViewModel smv = new StickViewModel(repository, sticks);
                    mmvm.CurrentViewModel = smv;
                });
            }
        }

        public ICommand ShowUsageSticks
        {
            get
            {
                return new RelayCommand(async(_) =>
                {
                    List<UsageStick> usageSticks = await repository.GetAllUsageSticks();
                    UsageStickViewModel usmv = new UsageStickViewModel(repository, usageSticks);
                    mmvm.CurrentViewModel = usmv;
                });
            }
        }

        public ICommand ShowStatistics
        {
            get
            {
                return new RelayCommand((_) =>
                {
                    StatisticalDataViewModel sdmv = new StatisticalDataViewModel();
                    mmvm.CurrentViewModel = sdmv;
                });
            }
        }
    }
}
