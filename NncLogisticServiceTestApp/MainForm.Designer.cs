namespace NmcServiceClientTest
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.rdoSubscription = new System.Windows.Forms.RadioButton();
            this.rdoOnDemand = new System.Windows.Forms.RadioButton();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.Location = new System.Drawing.Point( 467, 315 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnSubmit_Click );
            // 
            // rdoSubscription
            // 
            this.rdoSubscription.AutoSize = true;
            this.rdoSubscription.Location = new System.Drawing.Point( 12, 15 );
            this.rdoSubscription.Name = "rdoSubscription";
            this.rdoSubscription.Size = new System.Drawing.Size( 83, 17 );
            this.rdoSubscription.TabIndex = 2;
            this.rdoSubscription.TabStop = true;
            this.rdoSubscription.Text = "Subscription";
            this.rdoSubscription.UseVisualStyleBackColor = true;
            this.rdoSubscription.CheckedChanged += new System.EventHandler( this.rdoSubscription_CheckedChanged );
            // 
            // rdoOnDemand
            // 
            this.rdoOnDemand.AutoSize = true;
            this.rdoOnDemand.Location = new System.Drawing.Point( 12, 38 );
            this.rdoOnDemand.Name = "rdoOnDemand";
            this.rdoOnDemand.Size = new System.Drawing.Size( 82, 17 );
            this.rdoOnDemand.TabIndex = 3;
            this.rdoOnDemand.TabStop = true;
            this.rdoOnDemand.Text = "On Demand";
            this.rdoOnDemand.UseVisualStyleBackColor = true;
            this.rdoOnDemand.CheckedChanged += new System.EventHandler( this.rdoOnDemand_CheckedChanged );
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlContainer.Location = new System.Drawing.Point( 111, 15 );
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size( 430, 290 );
            this.pnlContainer.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 554, 350 );
            this.Controls.Add( this.pnlContainer );
            this.Controls.Add( this.rdoOnDemand );
            this.Controls.Add( this.rdoSubscription );
            this.Controls.Add( this.btnClose );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "NMC Service Test App";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rdoSubscription;
        private System.Windows.Forms.RadioButton rdoOnDemand;
        private System.Windows.Forms.Panel pnlContainer;
    }
}

