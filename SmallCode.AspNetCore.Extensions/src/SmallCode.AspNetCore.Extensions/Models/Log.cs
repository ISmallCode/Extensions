using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.AspNetCore.Extensions.Models
{
    public class Log
    {
        public Guid Id { set; get; }

        public string Thread { set; get; }

        public LogLevel Level { set; get; }

        public string Description { set; get; }

        public string Exception { set; get; }

        public string Ip { set; get; }

        public DateTime CreateDate { set; get; }
    }

    public enum LogLevel { 异常, 记录 }
}
