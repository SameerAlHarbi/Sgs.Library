using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Library.Mvc.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string phoneNumber, string message);
    }
}
