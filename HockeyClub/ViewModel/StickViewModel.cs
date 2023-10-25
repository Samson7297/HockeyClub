using HockeyClub.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HockeyClub.ViewModel
{
    public class StickViewModel: TableViewModelBase
    {
        private ObservableCollection<Stick> sticks;
        private Stick selectedStick;

        public ObservableCollection<Stick> Sticks
        {
            get { return sticks; }
            set
            {
                sticks = value;
                OnPropertyChanged();
            }
        }

        public Stick SelectedStick
        {
            get { return selectedStick; }
            set
            {
                selectedStick = value;
                OnPropertyChanged();
            }
        }

        public StickViewModel(IRepository repository, List<Stick> sticks) : base(repository)
        {
            Sticks = new ObservableCollection<Stick>(sticks);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            UpdateCommand = new RelayCommand(Update);
        }

        public override void Add(object parameter)
        {
            var newStick = new Stick(31, "Bauer", "HyperLite", 77, 29, "левый");
            repository.AddStick(newStick);
            Sticks.Add(newStick);
        }

        public override void Delete(object parameter)
        {
            if (SelectedStick != null)
            {
                repository.DeleteStick(SelectedStick);
                Sticks.Remove(SelectedStick);
            }
        }

        public override void Update(object parameter)
        {
            if (SelectedStick != null)
            {
                repository.UpdateStick(SelectedStick);
                int index = Sticks.IndexOf(SelectedStick);
                if (index >= 0)
                {
                    Sticks[index] = SelectedStick;
                }
            }
        }
    }
}
