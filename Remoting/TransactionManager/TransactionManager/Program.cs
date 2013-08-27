using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Serialization;

using CommonInterface;

namespace TransactionManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Load the configuration file
            RemotingConfiguration.Configure("TransactionManager.exe.config", false);

            WellKnownClientTypeEntry[] wkst = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            string url = string.Empty;
            foreach (WellKnownClientTypeEntry tp in wkst)
            {
                if (tp.ObjectUrl.EndsWith("TransactionFactory"))
                {
                    url = tp.ObjectUrl;
                }
                Console.WriteLine(tp.ObjectUrl);
            }

            ITransactionFactory factory = null;
            if (url.Length > 0)
            {
                factory = (ITransactionFactory)RemotingServices.Connect(
                  typeof(ITransactionFactory), url);
            }
            else
            {
                Console.WriteLine("Could not find requested object!!!");
            }

            if (factory != null)
            {
                try
                {
                    // Function to test if remoting is working correctly...
                    string testStr = factory.Test();
                }
                catch (Exception ex)
                {
                    string exMsg = ex.Message;
                    string innerMsg = ex.InnerException.Message;
                }

                Console.WriteLine(factory.Test());
                Console.WriteLine();


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TransactionManager(factory));
            }

        }
    }
}