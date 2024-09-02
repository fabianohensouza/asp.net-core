using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Moq;
using Saic.Controllers;
using Saic.Models;
using Saic.Models.Repositories;
using Xunit;

namespace Saic.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Can_Use_Repository()
    {
        // Arrange
        Mock<ICoopRepository> mock = new Mock<ICoopRepository>();
        mock.Setup(m => m.Coops).Returns((new Coop[] {
            new Coop {CoopID = 1, CoopNome = "P1"},
            new Coop {CoopID = 2, CoopNome = "P2"}
        }).AsQueryable<Coop>());
        HomeController controller = new HomeController(mock.Object);

        // Act
        IEnumerable<Coop>? result =
        (controller.Index() as ViewResult)?.ViewData.Model
        as IEnumerable<Coop>;

        // Assert
        Coop[] prodArray = result?.ToArray() ?? Array.Empty<Coop>();
        Assert.True(prodArray.Length == 2);
        Assert.Equal("P1", prodArray[0].CoopNome);
        Assert.Equal("P2", prodArray[1].CoopNome);

    }
}