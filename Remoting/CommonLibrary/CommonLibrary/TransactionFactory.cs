using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Serialization;

using CommonInterface;

namespace CommonLibrary
{
    class TransactionFactory : MarshalByRefObject, ITransactionFactory
    {
        private static string storedTransactionsFile = "transactions.xml";

        private TransactionList m_TransactionList;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public TransactionFactory()
        {
            // Loads the list of transaction from disk
            m_TransactionList = TransactionList.Load(storedTransactionsFile);

            if (m_TransactionList == null)
                m_TransactionList = new TransactionList();
        }

        #region ITransactionFactory Members

        /// <summary>
        /// Gets the list of <see cref="ITransaction"/>
        /// </summary>
        /// <returns></returns>
        public ITransactionList GetTransactionList()
        {
            return m_TransactionList;
        }

        /// <summary>
        /// Add a <see cref="ITransaction"/> to the list.
        /// </summary>
        /// <param name="transaction">The <see cref="ITransaction"/> to be added.</param>
        public void AddTransaction(ITransaction transaction)
        {
            m_TransactionList.Add(transaction);
            m_TransactionList.Save(storedTransactionsFile);
        }


        /// <summary>
        /// Create a new <see cref="ITransaction"/>
        /// </summary>
        /// <returns>The new <see cref="ITransaction"/></returns>
        public ITransaction CreateNewTransaction()
        {
            return (ITransaction)(new Transaction());
        }

        /// <summary>
        /// Deletes the <see cref="ITransaction"/> specified.
        /// </summary>
        /// <param name="transaction">The <see cref="ITransaction"/> to be deleted.</param>
        public void DeleteTransaction(ITransaction transaction)
        {
            m_TransactionList.Remove(transaction);
            m_TransactionList.Save(storedTransactionsFile);
        }

        public string Test()
        {
            return "Successful test";
        }

        #endregion
    }
}
