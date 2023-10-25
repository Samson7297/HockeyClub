using HockeyClub.Model;
using System.Windows.Input;

namespace HockeyClub.ViewModel
{
    public abstract class TableViewModelBase: ViewModelBase
    {
        protected IRepository repository;

        public TableViewModelBase(IRepository repository)
        {
            this.repository = repository;
        }
        
        private TableViewModelBase currentViewModel;
        public TableViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        private object selectedObject;
        public object SelectedObject
        {
            get { return selectedObject; }
            set
            {
                selectedObject = value;
                OnPropertyChanged();
            }
        }

        public abstract void Add(object parameter);
        public abstract void Delete(object parameter);
        public abstract void Update(object parameter);

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get { return addCommand; }
            set
            {
                addCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                deleteCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get { return updateCommand; }
            set
            {
                updateCommand = value;
                OnPropertyChanged();
            }
        }
    }
}
