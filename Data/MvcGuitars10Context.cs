using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcGuitars10.Models;

namespace MvcGuitars10.Data
{
    public class MvcGuitars10Context : DbContext
    {
        public MvcGuitars10Context (DbContextOptions<MvcGuitars10Context> options)
            : base(options)
        {
        }

        public DbSet<MvcGuitars10.Models.Guitars> Guitars { get; set; }
    }
}
