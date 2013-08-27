using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonInterface;

namespace TransactionManager
{
    /// <summary>The main form that drives the client application.</summary>
    public partial class TransactionManager : Form
    {
        ITransactionFactory m_Factory;

        /// <summary>Gets and sets the <see cref="ITransactionFactory"/>.</summary>
        public ITransactionFactory Factory
        {
            get { return m_Factory; }
            set { m_Factory = value; }
        }

        /// <summary>Initialize this class with the <see cref="ITransactionFactory"/>.</summary>
        /// <param name="factory">The <see cref="ITransactionFactory"/> obtained from the server.</param>
        public TransactionManager(ITransactionFactory factory)
        {
            Factory = factory;
            InitializeComponent();
        }

        private void TransactionManager_Load(object sender, EventArgs e)
        {
            InitializeList();
        }

        private void AddListHeaders()
        {
            lvwTransactions.Columns.Add("", -1);
            lvwTransactions.Columns.Add("ID", 90);
            lvwTransactions.Columns.Add("Date", 90);
            lvwTransactions.Columns.Add("Description", 170);
            lvwTransactions.Columns.Add("Amount", 90);
            lvwTransactions.Columns.Add("Balance", 90);
        }

        private void AddTransactionToList(ITransaction t)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(t.ID.ToString());
            item.SubItems.Add(t.PostingDate.ToShortDateString());
            item.SubItems.Add(t.Description);
            item.SubItems.Add(t.Amount.ToString());
            item.SubItems.Add(t.Balance.ToString());
            lvwTransactions.Items.Add(item);
            item.Tag = t;
        }

        private void InitializeList()
        {
            AddListHeaders();

            if (Factory != null)
            {
                ITransactionList list = Factory.GetTransactionList();
                if (list == null) return;

                foreach (ITransaction t in list)
                {
                    AddTransactionToList(t);
                }
            }
        }

        private void lvwTransactions_KeyDown(object sender, KeyEventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ITransaction t = Factory.CreateNewTransaction();

            TransactionDialog d = new TransactionDialog();
            d.Transaction = t;
            d.ShowDialog(this);

            if (d.DialogResult == DialogResult.Cancel) return;

            Factory.AddTransaction(d.Transaction);
            AddTransactionToList(d.Transaction);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((lvwTransactions.SelectedItems != null) && (lvwTransactions.SelectedItems.Count != 0))
            {
                foreach (ListViewItem i in lvwTransactions.SelectedItems)
                {
                    Factory.DeleteTransaction((ITransaction) i.Tag);
                    lvwTransactions.Items.Remove(i);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}