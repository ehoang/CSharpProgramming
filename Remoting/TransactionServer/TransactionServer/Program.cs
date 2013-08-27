using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using CommonInterface;
using CommonLibrary;

namespace TransactionServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RemotingConfiguration.Configure("TransactionServer.exe.config", false);

                Console.WriteLine("Transaction Server Registered");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }


            


            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine(); // Pressing ENTER exits.

            // Unnecessary, but complete...
            // Shut down remoting:
            IChannel[] channels = ChannelServices.RegisteredChannels;
            foreach (IChannel channel in channels)
            {
                ChannelServices.UnregisterChannel(channel);
            }

        }
    }
}
