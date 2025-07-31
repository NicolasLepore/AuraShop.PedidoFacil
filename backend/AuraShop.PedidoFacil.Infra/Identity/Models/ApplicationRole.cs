using AuraShop.PedidoFacil.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuraShop.PedidoFacil.Infra.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            
        }
        public ApplicationRole(string roleStr)
        {
            if(Enum.TryParse<RoleEnum>(roleStr, ignoreCase: true, out var role))
            {
                this.Role = role;
            }
            else
            {
                this.Role = RoleEnum.User;
            }
        }

        public RoleEnum Role { get; set; }
    }
}
