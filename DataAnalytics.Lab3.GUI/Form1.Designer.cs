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
            this._filterByLastNameTextBox = new System.Windows.Forms.TextBox();
            this._filterByLastNameLabel = new System.Windows.Forms.Label();
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
            // _filterByLastNameTextBox
            // 
            this._filterByLastNameTextBox.Location = new System.Drawing.Point(199, 100);
            this._filterByLastNameTextBox.Name = "_filterByLastNameTextBox";
            this._filterByLastNameTextBox.Size = new System.Drawing.Size(199, 23);
            this._filterByLastNameTextBox.TabIndex = 2;
            this._filterByLastNameTextBox.TextChanged += new System.EventHandler(this._filterByLastNameTextBox_TextChanged);
            // 
            // _filterByLastNameLabel
            // 
            this._filterByLastNameLabel.AutoSize = true;
            this._filterByLastNameLabel.Location = new System.Drawing.Point(199, 82);
            this._filterByLastNameLabel.Name = "_filterByLastNameLabel";
            this._filterByLastNameLabel.Size = new System.Drawing.Size(114, 15);
            this._filterByLastNameLabel.TabIndex = 3;
            this._filterByLastNameLabel.Text = "Filter by Last Name..";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 443);
            this.Controls.Add(this._filterByLastNameLabel);
            this.Controls.Add(this._filterByLastNameTextBox);
            this.Controls.Add(this._selectedCustomerPictureBox);
            this.Controls.Add(this._customersListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._selectedCustomerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ListBox _customersListBox;
    private PictureBox _selectedCustomerPictureBox;
    private TextBox _filterByLastNameTextBox;
    private Label _filterByLastNameLabel;
}
