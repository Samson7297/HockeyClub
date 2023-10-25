using HockeyClub.Model;
using HockeyClub.ViewModel;
using Moq;

namespace HockeyClubTest
{
    public class CommandViewModelTest
    {
        [Fact]
        public async Task ShowHockeyPlayersCommand_SetsCurrentViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.GetAllHockeyPlayers()).Returns(Task.Run(() => new List<HockeyPlayer>()));
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            var commandViewModel = new CommandViewModel(repositoryMock.Object, mainWindowViewModel);
            // Act
            commandViewModel.ShowHockeyPlayers.Execute(null);
            // Assert
            Assert.IsType<HockeyPlayerViewModel>(mainWindowViewModel.CurrentViewModel);
        }

        [Fact]
        public async Task ShowSticksCommand_SetsCurrentViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.GetAllSticks()).Returns(Task.Run(() => new List<Stick>()));
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            var commandViewModel = new CommandViewModel(repositoryMock.Object, mainWindowViewModel);
            // Act
            commandViewModel.ShowSticks.Execute(null);
            // Assert
            Assert.IsType<StickViewModel>(mainWindowViewModel.CurrentViewModel);
        }

        [Fact]
        public async Task ShowUsageSticksCommand_SetsCurrentViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.GetAllUsageSticks()).Returns(Task.Run(() => new List<UsageStick>()));
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            var commandViewModel = new CommandViewModel(repositoryMock.Object, mainWindowViewModel);
            // Act
            commandViewModel.ShowUsageSticks.Execute(null);
            //await Task.Delay(200);
            // Assert
            Assert.IsType<UsageStickViewModel>(mainWindowViewModel.CurrentViewModel);
        }

        [Fact]
        public void ShowStatisticsCommand_SetsCurrentViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            var commandViewModel = new CommandViewModel(repositoryMock.Object, mainWindowViewModel);
            // Act
            commandViewModel.ShowStatistics.Execute(null);
            // Assert
            Assert.IsType<StatisticalDataViewModel>(mainWindowViewModel.CurrentViewModel);
        }
    }
}
