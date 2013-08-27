using System;
using System.Collections.Generic;
using System.Text;

namespace CommonInterface
{
    /// <summary>An interface to the logic of the server.</summary>
    public interface ITransactionFactory
    {
        ITransactionList GetTransactionList();
        void AddTransaction(ITransaction transaction);
        ITransaction CreateNewTransaction();
        void DeleteTransaction(ITransaction transaction);
        string Test();
    }
}
