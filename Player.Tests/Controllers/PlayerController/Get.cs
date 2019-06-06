using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Player.Models;

namespace Player.Tests.Controllers.PlayerController
{
    [TestClass]
    public class Get : PlayerControllerTestsBase
    {
        private const int ExpectedPlayerId = 10;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            PlayerService
                .Setup(x => x.GetPlayerById(It.IsAny<int>()))
                .Returns(new PlayerDetail());
        }

        private IHttpActionResult Act()
        {
            return Controller.Get(ExpectedPlayerId);
        }

        [TestMethod]
        public void ReturnsOkNegotiatedContentResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<PlayerDetail>));
        }

        [TestMethod]
        public void CallsGetPlayerById()
        {
            Act();

            PlayerService.Verify(
                x => x.GetPlayerById(ExpectedPlayerId),
                Times.Once);
        }
    }
}