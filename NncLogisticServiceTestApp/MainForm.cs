using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;

namespace NncServiceClientTest
{
    public partial class MainForm : Form
    {
        SubscriptionPanel subscriptionPanel = new SubscriptionPanel();
        OnDemandPanel onDemandPanel = new OnDemandPanel();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click( object sender, EventArgs e )
        {
            this.Close();  
        }                                       

        private void rdoSubscription_CheckedChanged( object sender, EventArgs e )
        {
            if (rdoSubscription.Checked) {

                pnlContainer.Controls.Clear();
                pnlContainer.Controls.Add( subscriptionPanel );
                
            }
        }

        private void rdoOnDemand_CheckedChanged( object sender, EventArgs e )
        {
            if( rdoOnDemand.Checked )
            {
                pnlContainer.Controls.Clear();
                pnlContainer.Controls.Add( onDemandPanel );
            }
        }

    }
}
