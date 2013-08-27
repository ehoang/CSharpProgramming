using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using CommonInterface;

namespace CommonLibrary
{
    /// <summary>
    /// Provides a class that is an enumerable list of ITransactions.
    /// </summary>
    public class TransactionList : MarshalByRefObject, ITransactionList
    {
        private List<ITransaction> m_Transactions = new List<ITransaction>();

        /// <summary>
        /// Saves the list of <see cref="ITransaction"/> to a specified file.
        /// </summary>
        /// <param name="fileName">Name of the file to store the list.</param>
        public void Save(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(TransactionCollection));
            TransactionCollection c = new TransactionCollection();
            foreach(ITransaction i in m_Transactions) {
                c.Add((Transaction) i);
            }

            using (XmlTextWriter writer = new XmlTextWriter(fileName, System.Text.Encoding.UTF8))
            {
                ser.Serialize(writer, c);
            }
        }

        /// <summary>
        /// Reads the list of <see cref="ITransaction"/> from disk.
        /// </summary>
        /// <param name="fileName">The path to the file</param>
        /// <returns>The list of <see cref="ITransaction"/></returns>
        public static TransactionList Load(string fileName)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(TransactionCollection));

                TransactionCollection c;
                TransactionList list = new TransactionList();

                using (XmlTextReader reader = new XmlTextReader(fileName))
                {
                    c = (TransactionCollection)ser.Deserialize(reader);
                }

                foreach (Transaction t in c)
                {
                    list.Add(t);
                }

                return list;
            }
            catch 
            {
                return null;
            }
        }

        #region IList<ITransaction> Members

        /// <summary>
        /// Gets the index of the <see cref="ITransaction"/> on the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(ITransaction item)
        {
            return m_Transactions.IndexOf(item);
        }

        /// <summary>
        /// Inserts this <see cref="ITransaction"/> at the index specified
        /// </summary>
        /// <param name="index">Location to insert the <see cref="ITransaction"/></param>
        /// <param name="item">The <see cref="ITransaction"/> to be inserted.</param>
        public void Insert(int index, ITransaction item)
        {
            m_Transactions.Insert(index, item);
        }

        /// <summary>
        /// Remove the <see cref="ITransaction"/> at the index specified
        /// </summary>
        /// <param name="index">the index of the <see cref="ITransaction"/> to be removed.</param>
        public void RemoveAt(int index)
        {
            m_Transactions.RemoveAt(index);
        }

        /// <summary>
        /// Gets and set the <see cref="Itransaction"/>at the specified index
        /// </summary>
        /// <param name="index">The index of the <see cref="ITransaction"/></param>
        /// <returns>The <see cref="ITransaction"/> at that location. </returns>
        public ITransaction this[int index]
        {
            get
            {
                return m_Transactions[index];
            }
            set
            {
                m_Transactions[index] = value;
            }
        }

        #endregion

        #region ICollection<ITransaction> Members

        public void Add(ITransaction item)
        {
            m_Transactions.Add(item);
        }

        public void Clear()
        {
            m_Transactions.Clear();
        }

        public bool Contains(ITransaction item)
        {
            return m_Transactions.Contains(item);
        }

        public void CopyTo(ITransaction[] array, int arrayIndex)
        {
            m_Transactions.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return m_Transactions.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(ITransaction item)
        {
            return m_Transactions.Remove(item);
        }

        #endregion

        #region IEnumerable<ITransaction> Members

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return m_Transactions.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_Transactions.GetEnumerator();
        }

        #endregion

    }
}

