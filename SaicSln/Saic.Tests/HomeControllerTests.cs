using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Moq;
using Saic.Controllers;
using Saic.Models;
using Saic.Models.Repositories;
using Saic.Models.ViewModels;
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
        CoopsListViewModel result = controller.Index()?.ViewData.Model
            as CoopsListViewModel ?? new();

        // Assert
        Coop[] coopArray = result.Coops.ToArray();
        Assert.True(coopArray.Length == 2);
        Assert.Equal("P1", coopArray[0].CoopNome);
        Assert.Equal("P2", coopArray[1].CoopNome);
    }

    [Fact]
    public void Can_Paginate()
    {
        // Arrange
        Mock<ICoopRepository> mock = new Mock<ICoopRepository>();
        mock.Setup(m => m.Coops).Returns((new Coop[] {
            new Coop {CoopID = 1, CoopNome = "P1"},
            new Coop {CoopID = 2, CoopNome = "P2"},
            new Coop {CoopID = 3, CoopNome = "P3"},
            new Coop {CoopID = 4, CoopNome = "P4"},
            new Coop {CoopID = 5, CoopNome = "P5"}
        }).AsQueryable<Coop>());
        HomeController controller = new HomeController(mock.Object);
        controller.PageSize = 3;

        // Act
        CoopsListViewModel result = controller.Index(2)?.ViewData.Model
            as CoopsListViewModel ?? new();

        // Assert
        Coop[] coopArray = result.Coops.ToArray();
        Assert.True(coopArray.Length == 2);
        Assert.Equal("P4", coopArray[0].CoopNome);
        Assert.Equal("P5", coopArray[1].CoopNome);
    }

    [Fact]
    public void Can_Send_Pagination_View_Model()
    {
        // Arrange
        Mock<ICoopRepository> mock = new Mock<ICoopRepository>();
        mock.Setup(m => m.Coops).Returns((new Coop[] {
            new Coop {CoopID = 1, CoopNome = "P1"},
            new Coop {CoopID = 2, CoopNome = "P2"},
            new Coop {CoopID = 3, CoopNome = "P3"},
            new Coop {CoopID = 4, CoopNome = "P4"},
            new Coop {CoopID = 5, CoopNome = "P5"}
        }).AsQueryable<Coop>());

        // Arrange
        HomeController controller = new HomeController(mock.Object) { PageSize = 3 };

        // Act
        CoopsListViewModel result = controller.Index(2)?.ViewData.Model 
            as CoopsListViewModel ?? new();

        // Assert
        PagingInfo pageInfo = result.PagingInfo;
        Assert.Equal(2, pageInfo.PagAtual);
        Assert.Equal(3, pageInfo.ItemsPorPag);
        Assert.Equal(5, pageInfo.TotalItens);
        Assert.Equal(2, pageInfo.TotalPages);
    }
}