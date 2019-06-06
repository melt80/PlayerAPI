using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Player.Models;

namespace Player.Tests.Controllers.PlayerController
{
    [TestClass]
    public class Put : PlayerControllerTestsBase
    {
        private bool _updatePlayerSuccess = true;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            PlayerService
                .Setup(x => x.UpdatePlayer(It.IsAny<PlayerEdit>()))
                .Returns(() => _updatePlayerSuccess);
        }

        private IHttpActionResult Act()
        {
            return Controller.Put(new PlayerEdit());
        }

        [TestMethod]
        public void ReturnsOkResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void CallsUpdatePlayer()
        {
            Act();

            PlayerService.Verify(
                x => x.UpdatePlayer(It.IsAny<PlayerEdit>()),
                Times.Once);
        }

        [TestMethod]
        public void ReturnsInvalidModelStateResult_GivenInvalidModelState()
        {
            Controller.ModelState.AddModelError("", "some error");

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void ReturnsInternalServerErrorResult_GivenCreatePlayerFails()
        {
            _updatePlayerSuccess = false;

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}