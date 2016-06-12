using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.AspNetCore.Extensions.Models
{
    public class SmallCodeContext : DbContext
    {
        public SmallCodeContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Log> Logs { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
