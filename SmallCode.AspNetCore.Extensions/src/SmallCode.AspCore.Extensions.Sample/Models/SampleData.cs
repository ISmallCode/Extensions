using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SmallCode.AspNetCore.Extensions.Extensions;
using SmallCode.AspNetCore.Extensions.Models;

namespace SmallCode.AspCore.Extensions.Sample.Models
{
    public class SampleData
    {

        public async static Task InitDB(IServiceProvider service)
        {
            var db = service.GetService<SampleContext>();

            if (db.Database != null && db.Database.EnsureCreated())
            {
                User user = new User
                {
                    UserName = "admin",
                    Password = "123456".ToMD5(),
                };

                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }

        public void SaveLog(Log log)
        {
            var db = service.GetService<SampleContext>();
            db.Logs.Add(db);
            db.SaveChanges();
        }
    }
}
