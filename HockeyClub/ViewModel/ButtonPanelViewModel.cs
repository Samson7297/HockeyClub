using System.Windows.Input;

namespace HockeyClub.ViewModel
{
    public class ButtonPanelViewModel: ViewModelBase
    {
        private ICommand addCommand;
        private ICommand deleteCommand;
        private ICommand updateCommand;
        private TableViewModelBase currentTableViewModel;

        public ICommand AddCommand
        {
            get { return new RelayCommand((_) => currentTableViewModel?.Add(currentTableViewModel)); }
            set
            {
                addCommand = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand
        {
            get { return new RelayCommand((_) => currentTableViewModel?.Delete(currentTableViewModel.SelectedObject)); }
            set
            {
                deleteCommand = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCommand
        {
            get { return new RelayCommand((_) => currentTableViewModel?.Update(currentTableViewModel.SelectedObject)); } 
            set
            {
                updateCommand = value;
                OnPropertyChanged();
            }
        }

        public ButtonPanelViewModel(TableViewModelBase tableViewModel)
        {
            SetTableViewModel(tableViewModel);
        }

        public void SetTableViewModel(TableViewModelBase tableViewModel)
        {
            currentTableViewModel = tableViewModel;
            AddCommand = new RelayCommand(currentTableViewModel.Add);
            DeleteCommand = new RelayCommand(currentTableViewModel.Delete);
            UpdateCommand = new RelayCommand(currentTableViewModel.Update);
        }
    }
}
