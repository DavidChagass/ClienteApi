using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClienteApi.Models;

namespace ClienteApi.Data
{
    public class ClienteApiContext : DbContext
    {
        public ClienteApiContext (DbContextOptions<ClienteApiContext> options)
            : base(options)
        {
        }

        public DbSet<ClienteApi.Models.Cliente> Cliente { get; set; } = default!;
    }
}
