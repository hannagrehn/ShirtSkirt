using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class RoleService
{
    private readonly RoleRepo _roleRepo;

    public RoleService(RoleRepo RoleRepo)
    {
        _roleRepo = RoleRepo;
    }

    public RoleEntity CreateRole(string role)
    {
        var roleEntity = _roleRepo.GetOne(x => x.RoleName == role);
        roleEntity ??= _roleRepo.Create(new RoleEntity { RoleName = role });
        return roleEntity;
    }

    public RoleEntity GetRoleByName(string role)
    {
        var roleEntity = _roleRepo.GetOne(x => x.RoleName == role);
        return roleEntity;
    }

    public RoleEntity GetRoleById(int id)
    {
        var roleEntity = _roleRepo.GetOne(x => x.RoleId == id);
        return roleEntity;
    }

    public IEnumerable<RoleEntity> GetRole()
    {
        var roles = _roleRepo.GetAll();
        return roles;
    }

    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        var updatedRoleEntity = _roleRepo.Update(x => x.RoleId == roleEntity.RoleId, roleEntity);
        return updatedRoleEntity;
    }

    public bool DeleteRole(int id)
    {
        try
        {
            return _roleRepo.Delete(x => x.RoleId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}
