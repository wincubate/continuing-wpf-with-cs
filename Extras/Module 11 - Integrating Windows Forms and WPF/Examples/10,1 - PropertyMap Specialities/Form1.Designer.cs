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
         this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
         this.btnChange = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // elementHost1
         // 
         this.elementHost1.Dock = System.Windows.Forms.DockStyle.Top;
         this.elementHost1.Location = new System.Drawing.Point( 0, 0 );
         this.elementHost1.Name = "elementHost1";
         this.elementHost1.Size = new System.Drawing.Size( 284, 225 );
         this.elementHost1.TabIndex = 0;
         this.elementHost1.Text = "elementHost1";
         this.elementHost1.Child = null;
         // 
         // btnChange
         // 
         this.btnChange.Location = new System.Drawing.Point( 12, 231 );
         this.btnChange.Name = "btnChange";
         this.btnChange.Size = new System.Drawing.Size( 75, 23 );
         this.btnChange.TabIndex = 1;
         this.btnChange.Text = "Change BackColor";
         this.btnChange.UseVisualStyleBackColor = true;
         this.btnChange.Click += new System.EventHandler( this.btnChange_Click );
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size( 284, 262 );
         this.Controls.Add( this.btnChange );
         this.Controls.Add( this.elementHost1 );
         this.Name = "Form1";
         this.Text = "WPF in WinForms";
         this.ResumeLayout( false );

      }

      #endregion

      private System.Windows.Forms.Integration.ElementHost elementHost1;
      private System.Windows.Forms.Button btnChange;
   }
}

