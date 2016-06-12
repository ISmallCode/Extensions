using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.AspNetCore.Extensions.Models
{
    public class User
    {
        public Guid Id { set; get; }

        public string UserName { set; get; }

        public string Password { set; get; }
    }
}
