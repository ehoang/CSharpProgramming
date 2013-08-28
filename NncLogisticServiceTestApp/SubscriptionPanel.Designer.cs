namespace NncServiceClientTest
{
    partial class SubscriptionPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboQueryType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoClassOfSupply = new System.Windows.Forms.RadioButton();
            this.rdoNode = new System.Windows.Forms.RadioButton();
            this.cboClassOfSupply = new System.Windows.Forms.ComboBox();
            this.txtNode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheckData = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtRequestId = new System.Windows.Forms.TextBox();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 16, 26 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 62, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Query Type";
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
            this.cboQueryType.Location = new System.Drawing.Point( 113, 23 );
            this.cboQueryType.Name = "cboQueryType";
            this.cboQueryType.Size = new System.Drawing.Size( 181, 21 );
            this.cboQueryType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 16, 58 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 92, 13 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Subscription Type";
            // 
            // rdoClassOfSupply
            // 
            this.rdoClassOfSupply.AutoSize = true;
            this.rdoClassOfSupply.Location = new System.Drawing.Point( 131, 58 );
            this.rdoClassOfSupply.Name = "rdoClassOfSupply";
            this.rdoClassOfSupply.Size = new System.Drawing.Size( 97, 17 );
            this.rdoClassOfSupply.TabIndex = 3;
            this.rdoClassOfSupply.TabStop = true;
            this.rdoClassOfSupply.Text = "Class of Supply";
            this.rdoClassOfSupply.UseVisualStyleBackColor = true;
            this.rdoClassOfSupply.CheckedChanged += new System.EventHandler( this.rdoClassOfSupply_CheckedChanged );
            // 
            // rdoNode
            // 
            this.rdoNode.AutoSize = true;
            this.rdoNode.Location = new System.Drawing.Point( 131, 81 );
            this.rdoNode.Name = "rdoNode";
            this.rdoNode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdoNode.Size = new System.Drawing.Size( 51, 17 );
            this.rdoNode.TabIndex = 4;
            this.rdoNode.TabStop = true;
            this.rdoNode.Text = "Node";
            this.rdoNode.UseVisualStyleBackColor = true;
            this.rdoNode.CheckedChanged += new System.EventHandler( this.rdoNode_CheckedChanged );
            // 
            // cboClassOfSupply
            // 
            this.cboClassOfSupply.FormattingEnabled = true;
            this.cboClassOfSupply.Items.AddRange( new object[] {
            "ClassI",
            "ClassIII",
            "ClassIV",
            "ClassV",
            "ClassVI",
            "ClassVII",
            "ClassVIII",
            "ClassX"} );
            this.cboClassOfSupply.Location = new System.Drawing.Point( 234, 55 );
            this.cboClassOfSupply.Name = "cboClassOfSupply";
            this.cboClassOfSupply.Size = new System.Drawing.Size( 138, 21 );
            this.cboClassOfSupply.TabIndex = 6;
            this.cboClassOfSupply.SelectedIndexChanged += new System.EventHandler( this.cboClassOfSupply_SelectedIndexChanged );
            // 
            // txtNode
            // 
            this.txtNode.Location = new System.Drawing.Point( 234, 83 );
            this.txtNode.Name = "txtNode";
            this.txtNode.Size = new System.Drawing.Size( 138, 20 );
            this.txtNode.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.btnCheckData );
            this.groupBox1.Controls.Add( this.btnCreate );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Controls.Add( this.txtNode );
            this.groupBox1.Controls.Add( this.cboQueryType );
            this.groupBox1.Controls.Add( this.cboClassOfSupply );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.rdoNode );
            this.groupBox1.Controls.Add( this.rdoClassOfSupply );
            this.groupBox1.Location = new System.Drawing.Point( 12, 12 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 400, 148 );
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Request";
            // 
            // btnCheckData
            // 
            this.btnCheckData.Location = new System.Drawing.Point( 170, 114 );
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.Size = new System.Drawing.Size( 100, 23 );
            this.btnCheckData.TabIndex = 10;
            this.btnCheckData.Text = "Check New Data";
            this.btnCheckData.UseVisualStyleBackColor = true;
            this.btnCheckData.Click += new System.EventHandler( this.btnCheckData_Click );
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point( 276, 114 );
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size( 96, 23 );
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler( this.btnCreate_Click );
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.btnGetData );
            this.groupBox2.Controls.Add( this.txtRequestId );
            this.groupBox2.Controls.Add( this.lblRequestId );
            this.groupBox2.Location = new System.Drawing.Point( 12, 166 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 400, 106 );
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point( 276, 66 );
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size( 95, 23 );
            this.btnGetData.TabIndex = 2;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler( this.btnGetData_Click );
            // 
            // txtRequestId
            // 
            this.txtRequestId.Location = new System.Drawing.Point( 113, 26 );
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Size = new System.Drawing.Size( 259, 20 );
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
            // SubscriptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.Name = "SubscriptionPanel";
            this.Size = new System.Drawing.Size( 430, 290 );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboQueryType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoClassOfSupply;
        private System.Windows.Forms.RadioButton rdoNode;
        private System.Windows.Forms.ComboBox cboClassOfSupply;
        private System.Windows.Forms.TextBox txtNode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRequestId;
        private System.Windows.Forms.Label lblRequestId;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnCheckData;
    }
}
