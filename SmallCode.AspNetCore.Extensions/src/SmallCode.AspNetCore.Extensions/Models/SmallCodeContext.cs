using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.AspNetCore.Extensions.Models
{
    public abstract class SmallCodeContext<T> : DbContext
         where T : class
    {
        public SmallCodeContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Log> Logs { set; get; }

        public DbSet<T> Users { set; get; }

    }
}
