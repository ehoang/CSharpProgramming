namespace NmcServiceClientTest
{
    partial class OnDemandPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboQueryType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPrimaryField = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrimaryValues = new System.Windows.Forms.TextBox();
            this.txtSecondaryValues = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSecondaryField = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtRequestId = new System.Windows.Forms.TextBox();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboQueryType
            // 
            this.cboQueryType.FormattingEnabled = true;
            this.cboQueryType.Items.AddRange( new object[] {
            "Ammunition",
            "Blood Inventory",
            "Requisition Summary",
            "Unit Equipment",
            "War Reserves",
            "Wholesale Inventory"} );
            this.cboQueryType.Location = new System.Drawing.Point( 112, 23 );
            this.cboQueryType.Name = "cboQueryType";
            this.cboQueryType.Size = new System.Drawing.Size( 181, 21 );
            this.cboQueryType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 15, 26 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 62, 13 );
            this.label1.TabIndex = 2;
            this.label1.Text = "Query Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 15, 64 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 66, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Primary Field";
            // 
            // cboPrimaryField
            // 
            this.cboPrimaryField.FormattingEnabled = true;
            this.cboPrimaryField.Items.AddRange( new object[] {
            "Material Asset ID"} );
            this.cboPrimaryField.Location = new System.Drawing.Point( 112, 61 );
            this.cboPrimaryField.Name = "cboPrimaryField";
            this.cboPrimaryField.Size = new System.Drawing.Size( 181, 21 );
            this.cboPrimaryField.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 15, 89 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 76, 13 );
            this.label3.TabIndex = 6;
            this.label3.Text = "Primary Values";
            // 
            // txtPrimaryValues
            // 
            this.txtPrimaryValues.Location = new System.Drawing.Point( 112, 86 );
            this.txtPrimaryValues.Name = "txtPrimaryValues";
            this.txtPrimaryValues.Size = new System.Drawing.Size( 181, 20 );
            this.txtPrimaryValues.TabIndex = 7;
            // 
            // txtSecondaryValues
            // 
            this.txtSecondaryValues.Location = new System.Drawing.Point( 112, 143 );
            this.txtSecondaryValues.Name = "txtSecondaryValues";
            this.txtSecondaryValues.Size = new System.Drawing.Size( 181, 20 );
            this.txtSecondaryValues.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 15, 146 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 93, 13 );
            this.label4.TabIndex = 10;
            this.label4.Text = "Secondary Values";
            // 
            // cboSecondaryField
            // 
            this.cboSecondaryField.FormattingEnabled = true;
            this.cboSecondaryField.Items.AddRange( new object[] {
            "Node"} );
            this.cboSecondaryField.Location = new System.Drawing.Point( 112, 118 );
            this.cboSecondaryField.Name = "cboSecondaryField";
            this.cboSecondaryField.Size = new System.Drawing.Size( 181, 21 );
            this.cboSecondaryField.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 15, 121 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 83, 13 );
            this.label5.TabIndex = 8;
            this.label5.Text = "Secondary Field";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.btnCreate );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Controls.Add( this.txtSecondaryValues );
            this.groupBox1.Controls.Add( this.cboQueryType );
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.cboSecondaryField );
            this.groupBox1.Controls.Add( this.cboPrimaryField );
            this.groupBox1.Controls.Add( this.label5 );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.txtPrimaryValues );
            this.groupBox1.Location = new System.Drawing.Point( 16, 13 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 400, 192 );
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Request";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.btnGetData );
            this.groupBox2.Controls.Add( this.txtRequestId );
            this.groupBox2.Controls.Add( this.lblRequestId );
            this.groupBox2.Location = new System.Drawing.Point( 16, 211 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 400, 64 );
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point( 313, 23 );
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size( 75, 23 );
            this.btnGetData.TabIndex = 2;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler( this.btnGetData_Click );
            // 
            // txtRequestId
            // 
            this.txtRequestId.Location = new System.Drawing.Point( 113, 26 );
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Size = new System.Drawing.Size( 180, 20 );
            this.txtRequestId.TabIndex = 1;
            // 
            // lblRequestId
            // 
            this.lblRequestId.AutoSize = true;
            this.lblRequestId.Location = new System.Drawing.Point( 19, 29 );
            this.lblRequestId.Name = "lblRequestId";
            this.lblRequestId.Size = new System.Drawing.Size( 61, 13 );
            this.lblRequestId.TabIndex = 0;
            this.lblRequestId.Text = "Request ID";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point( 313, 159 );
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size( 75, 23 );
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler( this.btnCreate_Click );
            // 
            // OnDemandPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.Name = "OnDemandPanel";
            this.Size = new System.Drawing.Size( 430, 290 );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ComboBox cboQueryType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPrimaryField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrimaryValues;
        private System.Windows.Forms.TextBox txtSecondaryValues;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSecondaryField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox txtRequestId;
        private System.Windows.Forms.Label lblRequestId;
    }
}
