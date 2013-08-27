using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using CommonInterface;

namespace CommonLibrary
{
    /// <summary>Holds data of a transaction.</summary>
    [Serializable]
    public class Transaction : MarshalByRefObject,ISerializable, ITransaction
    {

        /// <summary>Creates a new instance of this class with a random ID.</summary>
        public Transaction()
        {   
            Random rnd = new Random();
            this.m_ID = rnd.Next(1, 999999999);
        }

        #region ID
        private long m_ID;

        /// <summary>Gets and sets the transaction's ID. </summary>
        public long ID
        {
            get
            {
                return m_ID;
            }

            set { m_ID = value; }
        }

        #endregion

        #region PostingDate
        private DateTime m_PostingDate = DateTime.Today;

        /// <summary>
        /// Gets and set the Posting Date of this <see cref="Transaction"/>.
        /// </summary>
        public DateTime PostingDate
        {
            get { return m_PostingDate; }
            set { m_PostingDate = value; }
        }
        #endregion

        #region Description 
        private string m_Description;

        /// <summary>
        /// Gets and sets the description of this <see cref="Transaction"/>.
        /// </summary>
        public string Description
        {
            get
            {
                if (m_Description == null) m_Description = string.Empty;
                return m_Description;
            }
            set
            {
                if (value == null) value = string.Empty;
                m_Description = value;
            }
        }
        #endregion

        #region Amount 
        private double m_Amount = 0.0;

        /// <summary>
        /// Gets and sets the dollar amount of the transaction
        /// </summary>
        public double Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }
        #endregion

        #region Balance 
        private double m_Balance = 0.0;

        /// <summary>
        /// Gets and set the balance of the <see cref="Transaction"/>
        /// </summary>
        public double Balance
        {
            get { return m_Balance; }
            set
            {
                m_Balance = value;
            }
        }
        #endregion

        #region ISerializable Members

        /// <summary>Rules to follow when serialize the object</summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("PostingDate", PostingDate);
            info.AddValue("Description", Description);
            info.AddValue("Amount", Amount);
            info.AddValue("Balance", Balance);
        }

        #endregion
    }
}
