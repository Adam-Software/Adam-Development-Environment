using AdamDevelopmentEnvironment.Modules.Blockly.ViewModels;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Moq;
using Prism.Regions;
using Xunit;

namespace AdamDevelopmentEnvironment.Modules.Blocky.Tests.ViewModels
{
    public class BlocklyViewViewModelFixture
    {
        private readonly Mock<IMessageService> messageServiceMock;
        private readonly Mock<IRegionManager> regionManagerMock;
        const string MessageServiceDefaultMessage = "Some Value";

        public BlocklyViewViewModelFixture()
        {
            var messageService = new Mock<IMessageService>();
            messageService.Setup(x => x.GetMessage()).Returns(MessageServiceDefaultMessage);
            messageServiceMock = messageService;

            regionManagerMock = new Mock<IRegionManager>();
        }

        [Fact]
        public void MessagePropertyValueUpdated()
        {
            var vm = new BlocklyViewModel(regionManagerMock.Object, messageServiceMock.Object);

            messageServiceMock.Verify(x => x.GetMessage(), Times.Once);

            Assert.Equal(MessageServiceDefaultMessage, vm.Message);
        }

        [Fact]
        public void MessageINotifyPropertyChangedCalled()
        {
            var vm = new BlocklyViewModel(regionManagerMock.Object, messageServiceMock.Object);
            Assert.PropertyChanged(vm, nameof(vm.Message), () => vm.Message = "Changed");
        }
    }
}
