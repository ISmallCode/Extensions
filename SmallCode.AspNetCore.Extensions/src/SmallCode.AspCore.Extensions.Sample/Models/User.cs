using SmallCode.AspNetCore.Extensions.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.AspCore.Extensions.Sample.Models
{
    public class User : SmallCodeUser
    {
        [Timestamp]
 
        public byte[] RowVersion { set; get; }
    }
}
