using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;


namespace SmallCode.AspNetCore.Extensions.Services
{
    public class MessageServices : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var m = new TcpClient();

            return Task.FromResult(0);
        }

    }
}
