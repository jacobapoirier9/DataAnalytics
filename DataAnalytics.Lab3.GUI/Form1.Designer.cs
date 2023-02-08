namespace DataAnalytics.Lab3.GUI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this._customersListBox = new System.Windows.Forms.ListBox();
            this._selectedCustomerPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._selectedCustomerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _customersListBox
            // 
            this._customersListBox.FormattingEnabled = true;
            this._customersListBox.ItemHeight = 15;
            this._customersListBox.Location = new System.Drawing.Point(12, 164);
            this._customersListBox.Name = "_customersListBox";
            this._customersListBox.Size = new System.Drawing.Size(954, 259);
            this._customersListBox.TabIndex = 0;
            // 
            // _selectedCustomerPictureBox
            // 
            this._selectedCustomerPictureBox.Location = new System.Drawing.Point(12, 12);
            this._selectedCustomerPictureBox.Name = "_selectedCustomerPictureBox";
            this._selectedCustomerPictureBox.Size = new System.Drawing.Size(139, 127);
            this._selectedCustomerPictureBox.TabIndex = 1;
            this._selectedCustomerPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 443);
            this.Controls.Add(this._selectedCustomerPictureBox);
            this.Controls.Add(this._customersListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._selectedCustomerPictureBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private ListBox _customersListBox;
    private PictureBox _selectedCustomerPictureBox;
}
