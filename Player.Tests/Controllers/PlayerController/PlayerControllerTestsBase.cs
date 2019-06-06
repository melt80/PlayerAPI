using System;
using Player.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Player.API.Controllers;

namespace Player.Tests.Controllers.PlayerController
{
    [TestClass]
    public abstract class PlayerControllerTestsBase
    {
        protected API.Controllers.PlayerController Controller;

        protected Mock<IPlayerService> PlayerService;

        [TestInitialize]
        public virtual void Arrange()
        {
            PlayerService = new Mock<IPlayerService>();

            Controller = new API.Controllers.PlayerController(
                new Lazy<IPlayerService>(() => PlayerService.Object));
        }
    }
}