using HockeyClub.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HockeyClub.ViewModel
{
    public class HockeyPlayerViewModel : TableViewModelBase
    {
        private ObservableCollection<HockeyPlayer> hockeyPlayers;
        private HockeyPlayer selectedHockeyPlayer;

        public ObservableCollection<HockeyPlayer> HockeyPlayers
        {
            get { return hockeyPlayers; }
            set
            {
                hockeyPlayers = value;
                OnPropertyChanged();
            }
        }

        public HockeyPlayer SelectedPlayer
        {
            get { return selectedHockeyPlayer; }
            set
            {
                selectedHockeyPlayer = value;
                OnPropertyChanged();
            }
        }

        public HockeyPlayerViewModel(IRepository repository, List<HockeyPlayer> team) : base (repository)
        {
            hockeyPlayers = new ObservableCollection<HockeyPlayer> (team);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            UpdateCommand = new RelayCommand(Update);
        }

        public override void Add(object parameter)
        {
            var newHockeyPlayer = new HockeyPlayer(10,0, "Новый игрок", DateTime.Today, "", 0, "", "+7()");
            repository.AddHockeyPlayer(newHockeyPlayer);
            HockeyPlayers.Add(newHockeyPlayer);
        }

        public override void Delete(object parameter)
        {
            if (SelectedPlayer != null)
            {
                repository.DeleteHockeyPlayer(SelectedPlayer);
                HockeyPlayers.Remove(SelectedPlayer);
            }
        }

        public override void Update(object parameter)
        {
            if (SelectedPlayer != null)
            {
                repository.UpdateHockeyPlayer(SelectedPlayer);
                int index = HockeyPlayers.IndexOf(SelectedPlayer);
                if (index >= 0)
                {
                    HockeyPlayers[index] = SelectedPlayer;
                }
            }
        }
    }
}
