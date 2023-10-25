using HockeyClub.Model;
using System.Collections.ObjectModel;

namespace HockeyClub.ViewModel
{
    public class StatisticalDataViewModel: TableViewModelBase
    {
        private decimal averageAge;
        private decimal averageStickLife;
        private ObservableCollection<(string,int)> hockeyPlayers;

        public ObservableCollection<(string, int)> HockeyPlayers
        {
            get { return hockeyPlayers; }
            set
            {
                hockeyPlayers = value;
                OnPropertyChanged();
            }
        }

        public decimal AverageAge
        { 
            get { return averageAge; } 
            set 
            { 
                averageAge = value; 
                OnPropertyChanged(); 
            } 
        }

        public decimal AverageStickLife
        {
            get { return averageStickLife; }
            set
            {
                averageStickLife = value;
                OnPropertyChanged();
            }
        }

        public StatisticalDataViewModel() : base(null)
        {
            StatisticalData statisticalData = new StatisticalData();
            AverageAge = statisticalData.AverageAge();
            AverageStickLife = statisticalData.AverageStickLife();
            hockeyPlayers = new (statisticalData.CountStickPerSeasonEveryOne());
        }

        public override void Add(object parameter)
        {
            
        }

        public override void Delete(object parameter)
        {
            
        }

        public override void Update(object parameter)
        {
            
        }
    }
}
