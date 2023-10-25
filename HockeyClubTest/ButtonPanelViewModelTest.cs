using HockeyClub.Model;
using HockeyClub.ViewModel;
using Moq;

namespace HockeyClubTest
{
    public class ButtonPanelViewModelTest
    {
        [Fact]
        public void AddCommandOfCurrentTableViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var tableViewModelMock = new Mock<TableViewModelBase>(repositoryMock.Object);
            var buttonPanelViewModel = new ButtonPanelViewModel(tableViewModelMock.Object);
            // Act
            buttonPanelViewModel.AddCommand.Execute(null);
            // Assert
            tableViewModelMock.Verify(m => m.Add(It.IsAny<object>()), Times.Once);
        }

        [Fact]
        public void DeleteCommandOfCurrentTableViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var tableViewModelMock = new Mock<TableViewModelBase>(repositoryMock.Object);
            var buttonPanelViewModel = new ButtonPanelViewModel(tableViewModelMock.Object);
            // Act
            buttonPanelViewModel.DeleteCommand.Execute(null);
            // Assert
            tableViewModelMock.Verify(m => m.Delete(It.IsAny<object>()), Times.Once);
        }

        [Fact]
        public void UpdateCommandOfCurrentTableViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var tableViewModelMock = new Mock<TableViewModelBase>(repositoryMock.Object);
            var buttonPanelViewModel = new ButtonPanelViewModel(tableViewModelMock.Object);
            // Act
            buttonPanelViewModel.UpdateCommand.Execute(null);
            // Assert
            tableViewModelMock.Verify(m => m.Update(It.IsAny<object>()), Times.Once);
        }
    }
}