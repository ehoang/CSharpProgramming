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
    /// <summary>A dialog that allows the user to enter transaction data.</summary>
    public partial class TransactionDialog : Form
    {
        ITransaction m_Transaction;

        /// <summary>Gets and sets the transaction associated with this dialog.</summary>
        public ITransaction Transaction
        {
            get { return m_Transaction; }
            set
            {
                m_Transaction = value;
                BindTransaction();
            }
        }

        /// <summary>Creates a new instance of this dialog.</summary>
        public TransactionDialog()
        {
            InitializeComponent();
        }

        private void BindTransaction()
        {
            lblIdValue.Text = m_Transaction.ID.ToString();
            txtAmount.Text = m_Transaction.Amount.ToString();
            txtBalance.Text = m_Transaction.Balance.ToString();
            txtDescription.Text = m_Transaction.Description;
            dtpPostingDate.Text = m_Transaction.PostingDate.ToShortDateString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_Transaction.Amount = double.Parse(txtAmount.Text);
            m_Transaction.Balance = double.Parse(txtBalance.Text);
            m_Transaction.Description = txtDescription.Text;
            m_Transaction.PostingDate = DateTime.Parse(dtpPostingDate.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}