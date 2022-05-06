using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Entities
{
    public class Usuarios : IdentityUser
    {
        public bool usuarioActivo { get; set; }
    }
}
