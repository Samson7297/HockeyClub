using GalaSoft.MvvmLight.Command;
using HockeyClub.DataAccess;
using HockeyClub.Model;
using System.Windows.Input;

namespace HockeyClub.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        private HockeyPlayerViewModel hockeyPlayerViewModel;
        private StickViewModel stickViewModel;
        private UsageStickViewModel usageStickViewModel;
        private TableViewModelBase currentViewModel;
        private CommandViewModel commandViewModel;
        private ButtonPanelViewModel buttonPanelViewModel;

        public HockeyPlayerViewModel HockeyPlayerViewModel
        {
            get { return hockeyPlayerViewModel; }
            set
            {
                hockeyPlayerViewModel = value;
                OnPropertyChanged();
            }
        }

        public StickViewModel StickViewModel
        {
            get { return stickViewModel; }
            set
            {
                stickViewModel = value;
                OnPropertyChanged();
            }
        }

        public UsageStickViewModel UsageStickViewModel
        {
            get { return usageStickViewModel; }
            set
            {
                usageStickViewModel = value;
                OnPropertyChanged();
            }
        }

        public TableViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                ButtonPanelViewModel = new ButtonPanelViewModel(currentViewModel);
                OnPropertyChanged();
            }
        }

        public CommandViewModel CommandViewModel
        {
            get { return commandViewModel; }
            set
            {
                commandViewModel = value;
                OnPropertyChanged();
            }
        }

        public ButtonPanelViewModel ButtonPanelViewModel
        {
            get { return buttonPanelViewModel; }
            set
            {
                buttonPanelViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand SetTableCommand { get; }

        public MainWindowViewModel()
        {
            IRepository repository = new DbDataAccess();
            commandViewModel = new CommandViewModel(repository, this);
            SetTableCommand = new RelayCommand<string>(SetTable);
        }

        private void SetTable(string tableName)
        {
            switch (tableName)
            {
                case "HockeyPlayer":
                    CurrentViewModel = HockeyPlayerViewModel;
                    break;
                case "Stick":
                    CurrentViewModel = StickViewModel;
                    break;
                case "UsageStick":
                    CurrentViewModel = UsageStickViewModel;
                    break;
            }
        }
    }
}