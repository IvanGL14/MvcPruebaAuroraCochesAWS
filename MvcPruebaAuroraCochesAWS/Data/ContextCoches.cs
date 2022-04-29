using Microsoft.EntityFrameworkCore;
using MvcPruebaAuroraCochesAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPruebaAuroraCochesAWS.Data
{
    public class ContextCoches: DbContext
    {
        public ContextCoches(DbContextOptions<ContextCoches> options) : base(options) { }
        public DbSet<Coche> Coches { get; set; }
    }
}
