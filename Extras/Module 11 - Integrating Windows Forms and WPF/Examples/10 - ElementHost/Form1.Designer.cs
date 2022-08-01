namespace Wincubate.Module11.Slide10
{
    partial class Form1
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
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.lblExpanded = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // elementHost
            // 
            this.elementHost.BackColor = System.Drawing.Color.White;
            this.elementHost.Location = new System.Drawing.Point( 28, 0 );
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size( 350, 289 );
            this.elementHost.TabIndex = 0;
            this.elementHost.Text = "elementHost1";
            this.elementHost.Child = null;
            // 
            // lblExpanded
            // 
            this.lblExpanded.AutoSize = true;
            this.lblExpanded.Location = new System.Drawing.Point( 25, 321 );
            this.lblExpanded.Name = "lblExpanded";
            this.lblExpanded.Size = new System.Drawing.Size( 0, 13 );
            this.lblExpanded.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 415, 377 );
            this.Controls.Add( this.lblExpanded );
            this.Controls.Add( this.elementHost );
            this.Name = "Form1";
            this.Text = "ElementHost";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost;
        private System.Windows.Forms.Label lblExpanded;
    }
}

