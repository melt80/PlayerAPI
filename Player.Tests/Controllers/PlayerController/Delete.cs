using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Player.Tests.Controllers.PlayerController
{
    [TestClass]
    public class Delete : PlayerControllerTestsBase
    {
        private const int ExpectedPlayerId = 10;
        private bool _deletePlayerSuccess = true;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            PlayerService
                .Setup(x => x.DeletePlayer(It.IsAny<int>()))
                .Returns(() => _deletePlayerSuccess);
        }

        private IHttpActionResult Act()
        {
            return Controller.Delete(ExpectedPlayerId);
        }

        [TestMethod]
        public void ReturnsOkResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void CallsDeletePlayer()
        {
            Act();

            PlayerService.Verify(
                x => x.DeletePlayer(ExpectedPlayerId),
                Times.Once);
        }

        [TestMethod]
        public void ReturnsInternalServerErrorResult_GivenCreatePlayerFails()
        {
            _deletePlayerSuccess = false;

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}