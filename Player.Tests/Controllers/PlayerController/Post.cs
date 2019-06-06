using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Player.Models;

namespace Player.Tests.Controllers.PlayerController
{
    [TestClass]
    public class Post : PlayerControllerTestsBase
    {
        private bool _createPlayerSuccess = true;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            PlayerService
                .Setup(x => x.CreatePlayer(It.IsAny<PlayerCreate>()))
                .Returns(() => _createPlayerSuccess);
        }

        private IHttpActionResult Act()
        {
            return Controller.Post(new PlayerCreate());
        }

        [TestMethod]
        public void ReturnsOkResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void CallsCreatePlayer()
        {
            Act();

            PlayerService.Verify(
                x => x.CreatePlayer(It.IsAny<PlayerCreate>()),
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
            _createPlayerSuccess = false;

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}