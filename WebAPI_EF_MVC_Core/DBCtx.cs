using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Abc_Company
{
    public class DBCtx : DbContext
    {
        public DBCtx(DbContextOptions<DBCtx> options) : base(options)
        {
        }

        public DbSet<CarrierModel> Carriers { get; set; }
    }
}
