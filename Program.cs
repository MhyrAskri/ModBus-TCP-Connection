using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading;

namespace ModBus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tcp.ReadHoldingRegister();
        }
    }
}