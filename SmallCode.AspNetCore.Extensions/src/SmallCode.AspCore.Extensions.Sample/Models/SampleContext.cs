using SmallCode.AspNetCore.Extensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmallCode.AspCore.Extensions.Sample.Models
{
    public class SampleContext : SmallCodeContext
    {
        public SampleContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<User> Users { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
