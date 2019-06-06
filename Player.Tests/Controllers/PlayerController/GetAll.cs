using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Player.Models;
using Player.Services;

namespace Player.Tests.Controllers.PlayerController
{
    [TestClass]
    public class GetAll : PlayerControllerTestsBase
    {
        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            PlayerService
                .Setup(x => x.GetPlayers())
                .Returns(new List<PlayerListItem>
                {
                    new PlayerListItem(),
                    new PlayerListItem(),
                    new PlayerListItem()
                });
        }

        private IHttpActionResult Act()
        {
            return Controller.GetAll();
        }

        [TestMethod]
        public void ReturnsOkNegotiatedContentResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<PlayerListItem>>));
        }

        [TestMethod]
        public void CallsGetPlayers()
        {
            Act();

            PlayerService.Verify(
                x => x.GetPlayers(),
                Times.Once);
        }
    }
}