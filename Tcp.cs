using NModbus;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace ModBus
{
    public class Tcp
    {
        public static int ReadHoldingRegister()
        {
            try
            {
                ModbusTcpMasterReadInputsFromModbusSlave();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        /// <summary>
        ///     Modbus TCP master and slave example.
        /// </summary>
        public static void ModbusTcpMasterReadInputsFromModbusSlave()
        {
            string ipAddress = "192.168.2.135";
            ushort port = 502;
            using TcpClient client = new TcpClient(ipAddress, port);
            var factory = new ModbusFactory();
            
            // create the master
            IModbusMaster master = factory.CreateMaster(client);
			
            // read holding values
			ushort startAddress = "20";
            ushort needBytes = 10;
			UInt16[] inputs = new UInt16[needBytes];
            inputs = master.ReadHoldingRegisters(1, startAddress, needBytes);

            for (int i = 0; i < needBytes; i++)
            {
                Console.WriteLine(inputs[i]);
            }
			
            Thread.Sleep(500);
            ReadHoldingRegister();
        }
    }
}