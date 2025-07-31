using AuraShop.PedidoFacil.Domain.Enums;
using AuraShop.PedidoFacil.Infra.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace AuraShop.PedidoFacil.Infra.Services;
public static class RoleSeeder
{
    public static async Task Seed
        (UserManager<ApplicationUser> userManager, 
        RoleManager<ApplicationRole> roleManager)
    {
        foreach(RoleEnum roleType in Enum.GetValues(typeof(RoleEnum)))
        {
            string roleName = roleType.ToString();

            if(!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new ApplicationRole(roleName)
                {
                    Name = roleName,
                });
            }
        }
    }
}
