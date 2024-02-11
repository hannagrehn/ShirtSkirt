using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Tests.Repos;

public class RoleRepo_Tests
{

    private readonly AppContext _appContext =
        new(new DbContextOptionsBuilder<AppContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    private readonly DataContext _dataContext =
    new(new DbContextOptionsBuilder<DataContext>()
    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]
    public async Task CreateAsync_Should_Add_One_RoleEntity_ToDatabase_And_Return_UpdatedRoleEntity()
    {

        var roleRepo = new RoleRepo(_appContext);
        var roleEntity = new RoleEntity { RoleName = "Test" };

        var result = await roleRepo.CreateAsync(roleEntity);

        Assert.NotNull(result);
        Assert.Equal(1, result.RoleId);

    }
}
