using ChallengeAlkemy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Context
{
    public class UsuariosContext : IdentityDbContext<Usuarios>
    {
        private const string schema = "usuarios";
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(schema);
        }

    }
}
