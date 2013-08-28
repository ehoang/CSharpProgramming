using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using System.IO;

namespace NcServiceClientTest
{
    public partial class OnDemandPanel : UserControl
    {
        public OnDemandPanel()
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

        public string PrimaryField
        {
            get
            {
                return cboPrimaryField.SelectedItem.ToString();
            }
        }

        public string[] PrimaryValues
        {
            get
            {
                if( txtPrimaryValues.Text.Trim().Length > 0 )
                    return txtPrimaryValues.Text.Split( ',' );
                else
                    return null;
            }
        }

        public string SecondaryField
        {
            get
            {
                return cboSecondaryField.SelectedItem.ToString();
            }
        }

        public string[] SecondaryValues
        {
            get
            {
                if( txtSecondaryValues.Text.Trim().Length > 0 )
                    return txtSecondaryValues.Text.Split( ',' );
                else
                    return null;
            }
        }

        private void btnCreate_Click( object sender, EventArgs e )
        {
            SubmitOnDemandRequest();
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
                fileSize = client.FulFillOnDemandRequest( ref filePosisiton, ref requestId, out data );
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

            DialogResult result = MessageBox.Show( "Successfully retrieved data. " + "Total file size = " + fileSize + " (bytes).\n" + 
                "Do you want to see some data?", "Data Confirmation", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if( result != DialogResult.Yes )
            {
                return;
            }             

        }


        private void SubmitOnDemandRequest()
        {
            if( this.QueryType == "Ammunition" )
            {
                SubmitAmmoOnDemandRequest();
            }
            else if( this.QueryType == "Blood Inventory" )
            {
                SubmitBloodOnDemandRequest();
            }
            else if( this.QueryType == "Requisition Summary" )
            {
                SubmitRequisitionOnDemandRequest();
            }
            else if( this.QueryType == "Unit Equipment" )
            {
                SubmitEquipmentOnDemandRequest();
            }
            else if( this.QueryType == "War Reserves" )
            {
                SubmitWarReserveOnDemandRequest();
            }
            else if( this.QueryType == "Wholesale Inventory" )
            {
                SubmitWholesaleOnDemandRequest();
            }
        }


        private void SubmitRequisitionOnDemandRequest()
        {
            string requestId = string.Empty;

            RequisitionOnDemandPrimaryClass primary = new RequisitionOnDemandPrimaryClass();
            primary.FieldName = TypeOfRequisitionOnDemandPrimaryField.MaterialAssetId;
            primary.ClassValues.AddRange( this.PrimaryValues );

            RequisitionOnDemandRequest request = new RequisitionOnDemandRequest( primary );

            if( ( this.SecondaryValues != null ) && ( this.SecondaryValues.Length != 0 ) )
            {
                request.SecondaryClass = new RequisitionOnDemandSecondaryClass();
                request.SecondaryClass.FieldName = TypeOfRequisitionOnDemandSecondaryField.Node;
                request.SecondaryClass.ClassValues.AddRange( this.SecondaryValues );
            }

            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();
                requestId = client.RequestOnDemandRequisitionSummary( request );
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
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );
            }

            MessageBox.Show( "Successful. RequestId = " + requestId );
        }

        private void SubmitAmmoOnDemandRequest()
        {
            string requestId = string.Empty;

            AmmoOnDemandPrimaryClass primary = new AmmoOnDemandPrimaryClass();
            primary.FieldName = TypeOfAmmoOnDemandPrimaryField.MaterialAssetId;
            if( this.PrimaryValues == null )
                primary.ClassValues = null;
            else
                primary.ClassValues.AddRange( this.PrimaryValues );

            AmmoOnDemandRequest request = new AmmoOnDemandRequest( primary );

            if( ( this.SecondaryValues != null ) && ( this.SecondaryValues.Length != 0 ) )
            {
                request.SecondaryClass = new AmmoOnDemandSecondaryClass();
                request.SecondaryClass.FieldName = TypeOfAmmoOnDemandSecondaryField.Node;
                request.SecondaryClass.ClassValues.AddRange( this.SecondaryValues );
            }

            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();
                requestId = client.RequestOnDemandAmmunition( request );
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
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );

                return;
            }

            MessageBox.Show( "Successful. RequestId = " + requestId );
            txtRequestId.Text = requestId;
        }


        private void SubmitBloodOnDemandRequest()
        {
            string requestId = string.Empty;

            BloodOnDemandPrimaryClass primary = new BloodOnDemandPrimaryClass();
            primary.FieldName = TypeOfBloodOnDemandPrimaryField.MaterialAssetId;
            if( this.PrimaryValues == null )
                primary.ClassValues = null;
            else
                primary.ClassValues.AddRange( this.PrimaryValues );

            BloodOnDemandRequest request = new BloodOnDemandRequest( primary );

            if( ( this.SecondaryValues != null ) && ( this.SecondaryValues.Length != 0 ) )
            {
                request.SecondaryClass = new BloodOnDemandSecondaryClass();
                request.SecondaryClass.FieldName = TypeOfBloodOnDemandSecondaryField.Node;
                request.SecondaryClass.ClassValues.AddRange( this.SecondaryValues );
            }

            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();
                requestId = client.RequestOnDemandBlood( request );
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
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );

                return;
            }

            MessageBox.Show( "Successful. RequestId = " + requestId );
            txtRequestId.Text = requestId;
        }


        private void SubmitEquipmentOnDemandRequest()
        {
            string requestId = string.Empty;

            EquipmentOnDemandPrimaryClass primary = new EquipmentOnDemandPrimaryClass();
            primary.FieldName = TypeOfEquipmentOnDemandPrimaryField.MaterialAssetId;
            if( this.PrimaryValues == null )
                primary.ClassValues = null;
            else
                primary.ClassValues.AddRange( this.PrimaryValues );

            EquipmentOnDemandRequest request = new EquipmentOnDemandRequest( primary );

            if( ( this.SecondaryValues != null ) && ( this.SecondaryValues.Length != 0 ) )
            {
                request.SecondaryClass = new EquipmentOnDemandSecondaryClass();
                request.SecondaryClass.FieldName = TypeOfEquipmentOnDemandSecondaryField.Node;
                request.SecondaryClass.ClassValues.AddRange( this.SecondaryValues );
            }

            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();
                requestId = client.RequestOnDemandUnitEquipment( request );
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
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );

                return;
            }

            MessageBox.Show( "Successful. RequestId = " + requestId );
            txtRequestId.Text = requestId;
        }

        private void SubmitWarReserveOnDemandRequest()
        {
            string requestId = string.Empty;

            WarReserveOnDemandPrimaryClass primary = new WarReserveOnDemandPrimaryClass();
            primary.FieldName = TypeOfWarReserveOnDemandPrimaryField.MaterialAssetId;
            if( this.PrimaryValues == null )
                primary.ClassValues = null;
            else
                primary.ClassValues.AddRange( this.PrimaryValues );

            WarReserveOnDemandRequest request = new WarReserveOnDemandRequest( primary );

            if( ( this.SecondaryValues != null ) && ( this.SecondaryValues.Length != 0 ) )
            {
                request.SecondaryClass = new WarReserveOnDemandSecondaryClass();
                request.SecondaryClass.FieldName = TypeOfWarReserveOnDemandSecondaryField.Node;
                request.SecondaryClass.ClassValues.AddRange( this.SecondaryValues );
            }

            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();
                requestId = client.RequestOnDemandWarReserve( request );
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
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );

                return;
            }

            MessageBox.Show( "Successful. RequestId = " + requestId );
            txtRequestId.Text = requestId;
        }


        private void SubmitWholesaleOnDemandRequest()
        {
            string requestId = string.Empty;

            WholesaleOnDemandPrimaryClass primary = new WholesaleOnDemandPrimaryClass();
            primary.FieldName = TypeOfWholesaleOnDemandPrimaryField.MaterialAssetId;
            if( this.PrimaryValues == null )
                primary.ClassValues = null;
            else
                primary.ClassValues.AddRange( this.PrimaryValues );

            WholesaleOnDemandRequest request = new WholesaleOnDemandRequest( primary );

            if( ( this.SecondaryValues != null ) && ( this.SecondaryValues.Length != 0 ) )
            {
                request.SecondaryClass = new WholesaleOnDemandSecondaryClass();
                request.SecondaryClass.FieldName = TypeOfWholesaleOnDemandSecondaryField.Node;
                request.SecondaryClass.ClassValues.AddRange( this.SecondaryValues );
            }

            try
            {
                NncLogisticServiceClient client = new NncLogisticServiceClient();
                requestId = client.RequestOnDemandWholesaleRetail( request );
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
            }
            catch( FaultException<ExceptionFault> ef )
            {
                ExceptionFault fault = ef.Detail;

                MessageBox.Show( "Exception Fault caught.\n" +
                    fault.Message + "\n" +
                    fault.OriginalStackTrace );
            }
            catch( LogisticServiceException le )
            {
                MessageBox.Show( "Logistic Service Exception caught.\n" +
                    le.ToString() );
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Exception caught \n" + ex.ToString() );

                return;
            }

            MessageBox.Show( "Successful. RequestId = " + requestId );
            txtRequestId.Text = requestId;
        }

    }

}
