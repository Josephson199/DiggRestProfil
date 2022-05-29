using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiggRestProfil.Core.Interfaces
{
    public interface INotifier
    {
        Task Notify<T>(T message, string topic);
    }
}
