using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using System.ServiceModel;
using System.IO;

namespace NncServiceClientTest
{
    public partial class SubscriptionPanel : UserControl
    {
        public SubscriptionPanel()
        {
            InitializeComponent();
        }


        public string QueryType
        {
            get
            {
                return cboQueryType.SelectedItem.ToString();
            }
        }

        public bool IsNode
        {
            get
            {
                return rdoNode.Checked;
            }
        }

        public bool IsclassOfSupply
        {
            get
            {
                return rdoClassOfSupply.Checked;
            }
        }

        public string ClassOfSupply
        {
            get
            {
                return cboClassOfSupply.SelectedItem.ToString();
            }
        }

        public string Node
        {
            get
            {
                return txtNode.Text;
            }
        }

        private void rdoClassOfSupply_CheckedChanged( object sender, EventArgs e )
        {
            cboClassOfSupply.Enabled = rdoClassOfSupply.Checked;
            txtNode.Enabled = !rdoClassOfSupply.Checked;
        }

        private void rdoNode_CheckedChanged( object sender, EventArgs e )
        {
            cboClassOfSupply.Enabled = !rdoNode.Checked;
            txtNode.Enabled = rdoNode.Checked;

        }

        private void btnCreate_Click( object sender, EventArgs e )
        {
            SubscriptionRequest request = GetRequest();
            string requestId = string.Empty;

            if( request == null )
                return;

            request.IsForced = true;

            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();


                if( this.QueryType == "Ammunition" )
                {
                    requestId = client.RequestAmmunitionSubscription( request );
                }
                else if( this.QueryType == "Blood Inventory" )
                {
                    requestId = client.RequestBloodSubscription( request );
                }
                else if( this.QueryType == "Requisition Summary" )
                {
                    requestId = client.RequestRequisitionSummarySubscription( request );
                }
                else if( this.QueryType == "Unit Equipment" )
                {
                    requestId = client.RequestUnitEquipmentSubscription( request );                     
                }
                else if( this.QueryType == "War Reserves" )
                {
                    requestId = client.RequestWarReserveSubscription( request );
                }
                else if( this.QueryType == "Wholesale Inventory" )
                {
                    requestId = client.RequestWholesaleRetailSubscription( request );
                }

            }
            catch( FaultException<ValidationFault> fault )
            {
                string erroMsg = "Validation fault caught \n";
                ValidationFault validationFault = fault.Detail;
                if( validationFault.Details.Count > 0 )
                {
                    foreach( ValidationDetail detail in validationFault.Details )
                    {
                        erroMsg += detail.Message + "\n";
                    }

                    MessageBox.Show( erroMsg );
                }

                return;
            }
            catch( FaultException<RequestFault> rf )
            {
                RequestFault fault = rf.Detail;

                MessageBox.Show( "Request Fault caught.\n" +
                    "Error code: " + fault.ErrorCode + "\n" +
                    "Error message: " + fault.ErrorMessage );
                return;
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
                return;
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
                return;
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );
                return;
            }

            MessageBox.Show( "Successful. RequestId = " + requestId );
            txtRequestId.Text = requestId;
        }



        private TypeOfClassOfSupply ConvertTo( string cos )
        {
            cos = cos.ToUpper();

            if( cos == "CLASSI" )
                return TypeOfClassOfSupply.ClassI;
            if( cos == "CLASSIII" )
                return TypeOfClassOfSupply.ClassIII;
            if( cos == "CLASSIV" )
                return TypeOfClassOfSupply.ClassIV;
            if( cos == "CLASSV" )
                return TypeOfClassOfSupply.ClassV;
            if( cos == "CLASSVI" )
                return TypeOfClassOfSupply.ClassVI;
            if( cos == "CLASSVII" )
                return TypeOfClassOfSupply.ClassVII;
            if( cos == "CLASSVIII" )
                return TypeOfClassOfSupply.ClassVIII;
            if( cos == "CLASSX" )
                return TypeOfClassOfSupply.ClassX;

            return TypeOfClassOfSupply.ClassI;
        }

        private void btnGetData_Click( object sender, EventArgs e )
        {
            string requestId = txtRequestId.Text;
            Stream data;
            long filePosisiton = 0;
            long fileSize = 0;

            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();
                fileSize = client.FulFillSubscriptionRequest( ref filePosisiton, ref requestId, out data );
            }

            catch( FaultException<ValidationFault> fault )
            {
                string erroMsg = "Validation fault caught \n";
                ValidationFault validationFault = fault.Detail;
                if( validationFault.Details.Count > 0 )
                {
                    foreach( ValidationDetail detail in validationFault.Details )
                    {
                        erroMsg += detail.Message + "\n";
                    }

                    MessageBox.Show( erroMsg );
                }

                return;
            }
            catch( FaultException<RequestFault> rf )
            {
                RequestFault fault = rf.Detail;

                MessageBox.Show( "Request Fault caught.\n" +
                    "Error code: " + fault.ErrorCode + "\n" +
                    "Error message: " + fault.ErrorMessage );
                return;
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
                return;
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
                return;
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );
                return;
            }

            MessageBox.Show( "Successfully retrieved data.\n" + "Total file size = " + fileSize + "(kb).\n" );
            
        }

        private void cboClassOfSupply_SelectedIndexChanged( object sender, EventArgs e )
        {
            rdoClassOfSupply.Checked = true;
        }

        private void btnCheckData_Click( object sender, EventArgs e )
        {
            SubscriptionRequest request = GetRequest();
            SubscriptionInfo info = null;

            if( request == null )
                return;            
            
            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();


                if( this.QueryType == "Ammunition" )
                {
                    info = client.IsAmmunitionSubscriptionUpdated( request );
                }
                else if( this.QueryType == "Blood Inventory" )
                {
                    info = client.IsBloodSubscriptionUpdated( request );
                }
                else if( this.QueryType == "Requisition Summary" )
                {
                    info = client.IsRequisitionSummarySubscriptionUpdated( request );
                }
                else if( this.QueryType == "Unit Equipment" )
                {
                    info = client.IsUnitEquipmentSubscriptionUpdated( request );
                }
                else if( this.QueryType == "War Reserves" )
                {
                    info = client.IsWarReserveSubscriptionUpdated( request );
                }
                else if( this.QueryType == "Wholesale Inventory" )
                {
                    info = client.IsWholesaleRetailSubscriptionUpdated( request );
                }

            }
            catch( FaultException<ValidationFault> fault )
            {
                string erroMsg = "Validation fault caught \n";
                ValidationFault validationFault = fault.Detail;
                if( validationFault.Details.Count > 0 )
                {
                    foreach( ValidationDetail detail in validationFault.Details )
                    {
                        erroMsg += detail.Message + "\n";
                    }

                    MessageBox.Show( erroMsg );
                }

                return;
            }
            catch( FaultException<RequestFault> rf )
            {
                RequestFault fault = rf.Detail;

                MessageBox.Show( "Request Fault caught.\n" +
                    "Error code: " + fault.ErrorCode + "\n" +
                    "Error message: " + fault.ErrorMessage );
                return;
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
                return;
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
                return;
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );
                return;
            }

            string message = "Successful. New data availability = {0}. File generation = {1}. File generation time = {2}.";


            MessageBox.Show( string.Format(message, info.IsUpdateAvailable, info.IsFileGenerated, info.LastTimeUpdated.ToShortDateString() ));
        }


        private SubscriptionRequest GetRequest()
        {
            SubscriptionRequest request = null;

            if( this.IsclassOfSupply )
            {
                request = SubscriptionRequestFactory.Create( TypeOfSubscriptionRequest.ClassOfSupply );
                ( ( ClassOfSupplySubscriptionRequest ) request ).ClassOfSupply = ConvertTo( this.ClassOfSupply );
            }
            else if( this.IsNode )
            {
                request = SubscriptionRequestFactory.Create( TypeOfSubscriptionRequest.Node );
                ( ( NodeSubscriptionRequest ) request ).KeyValue = this.Node;
            }

            return request;
        }

    }

}
