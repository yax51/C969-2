namespace C969_Software_2
{
    partial class CreateCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerPhoneLabel = new System.Windows.Forms.Label();
            this.customerAddressLabel = new System.Windows.Forms.Label();
            this.customerCityLabel = new System.Windows.Forms.Label();
            this.customerCountryLabel = new System.Windows.Forms.Label();
            this.customerZipLabel = new System.Windows.Forms.Label();
            this.customerActiveLabel = new System.Windows.Forms.Label();
            this.activeYes = new System.Windows.Forms.RadioButton();
            this.activeNo = new System.Windows.Forms.RadioButton();
            this.customerCreateButton = new System.Windows.Forms.Button();
            this.customerCancelButton = new System.Windows.Forms.Button();
            this.customerNameText = new System.Windows.Forms.TextBox();
            this.customerPhoneText = new System.Windows.Forms.TextBox();
            this.customerAddressText = new System.Windows.Forms.TextBox();
            this.customerCityText = new System.Windows.Forms.TextBox();
            this.customerCountryText = new System.Windows.Forms.TextBox();
            this.customerZipText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create New Customer";
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(17, 82);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(38, 13);
            this.customerNameLabel.TabIndex = 1;
            this.customerNameLabel.Text = "Name:";
            // 
            // customerPhoneLabel
            // 
            this.customerPhoneLabel.AutoSize = true;
            this.customerPhoneLabel.Location = new System.Drawing.Point(17, 119);
            this.customerPhoneLabel.Name = "customerPhoneLabel";
            this.customerPhoneLabel.Size = new System.Drawing.Size(41, 13);
            this.customerPhoneLabel.TabIndex = 2;
            this.customerPhoneLabel.Text = "Phone:";
            // 
            // customerAddressLabel
            // 
            this.customerAddressLabel.AutoSize = true;
            this.customerAddressLabel.Location = new System.Drawing.Point(17, 157);
            this.customerAddressLabel.Name = "customerAddressLabel";
            this.customerAddressLabel.Size = new System.Drawing.Size(48, 13);
            this.customerAddressLabel.TabIndex = 3;
            this.customerAddressLabel.Text = "Address:";
            // 
            // customerCityLabel
            // 
            this.customerCityLabel.AutoSize = true;
            this.customerCityLabel.Location = new System.Drawing.Point(17, 192);
            this.customerCityLabel.Name = "customerCityLabel";
            this.customerCityLabel.Size = new System.Drawing.Size(27, 13);
            this.customerCityLabel.TabIndex = 4;
            this.customerCityLabel.Text = "City:";
            // 
            // customerCountryLabel
            // 
            this.customerCountryLabel.AutoSize = true;
            this.customerCountryLabel.Location = new System.Drawing.Point(17, 228);
            this.customerCountryLabel.Name = "customerCountryLabel";
            this.customerCountryLabel.Size = new System.Drawing.Size(46, 13);
            this.customerCountryLabel.TabIndex = 5;
            this.customerCountryLabel.Text = "Country:";
            // 
            // customerZipLabel
            // 
            this.customerZipLabel.AutoSize = true;
            this.customerZipLabel.Location = new System.Drawing.Point(17, 273);
            this.customerZipLabel.Name = "customerZipLabel";
            this.customerZipLabel.Size = new System.Drawing.Size(58, 13);
            this.customerZipLabel.TabIndex = 6;
            this.customerZipLabel.Text = "ZIP Code: ";
            // 
            // customerActiveLabel
            // 
            this.customerActiveLabel.AutoSize = true;
            this.customerActiveLabel.Location = new System.Drawing.Point(33, 345);
            this.customerActiveLabel.Name = "customerActiveLabel";
            this.customerActiveLabel.Size = new System.Drawing.Size(40, 13);
            this.customerActiveLabel.TabIndex = 7;
            this.customerActiveLabel.Text = "Active:";
            // 
            // activeYes
            // 
            this.activeYes.AutoSize = true;
            this.activeYes.Location = new System.Drawing.Point(117, 345);
            this.activeYes.Name = "activeYes";
            this.activeYes.Size = new System.Drawing.Size(43, 17);
            this.activeYes.TabIndex = 8;
            this.activeYes.TabStop = true;
            this.activeYes.Text = "Yes";
            this.activeYes.UseVisualStyleBackColor = true;
            // 
            // activeNo
            // 
            this.activeNo.AutoSize = true;
            this.activeNo.Location = new System.Drawing.Point(199, 345);
            this.activeNo.Name = "activeNo";
            this.activeNo.Size = new System.Drawing.Size(39, 17);
            this.activeNo.TabIndex = 9;
            this.activeNo.TabStop = true;
            this.activeNo.Text = "No";
            this.activeNo.UseVisualStyleBackColor = true;
            // 
            // customerCreateButton
            // 
            this.customerCreateButton.Location = new System.Drawing.Point(33, 405);
            this.customerCreateButton.Name = "customerCreateButton";
            this.customerCreateButton.Size = new System.Drawing.Size(75, 23);
            this.customerCreateButton.TabIndex = 10;
            this.customerCreateButton.Text = "Create";
            this.customerCreateButton.UseVisualStyleBackColor = true;
            this.customerCreateButton.Click += new System.EventHandler(this.customerCreateButton_Click);
            // 
            // customerCancelButton
            // 
            this.customerCancelButton.Location = new System.Drawing.Point(179, 405);
            this.customerCancelButton.Name = "customerCancelButton";
            this.customerCancelButton.Size = new System.Drawing.Size(75, 23);
            this.customerCancelButton.TabIndex = 11;
            this.customerCancelButton.Text = "Cancel";
            this.customerCancelButton.UseVisualStyleBackColor = true;
            this.customerCancelButton.Click += new System.EventHandler(this.customerCancelButton_Click);
            // 
            // customerNameText
            // 
            this.customerNameText.Location = new System.Drawing.Point(117, 75);
            this.customerNameText.Name = "customerNameText";
            this.customerNameText.Size = new System.Drawing.Size(166, 20);
            this.customerNameText.TabIndex = 12;
            // 
            // customerPhoneText
            // 
            this.customerPhoneText.Location = new System.Drawing.Point(117, 111);
            this.customerPhoneText.Name = "customerPhoneText";
            this.customerPhoneText.Size = new System.Drawing.Size(166, 20);
            this.customerPhoneText.TabIndex = 13;
            // 
            // customerAddressText
            // 
            this.customerAddressText.Location = new System.Drawing.Point(117, 149);
            this.customerAddressText.Name = "customerAddressText";
            this.customerAddressText.Size = new System.Drawing.Size(166, 20);
            this.customerAddressText.TabIndex = 14;
            // 
            // customerCityText
            // 
            this.customerCityText.Location = new System.Drawing.Point(117, 184);
            this.customerCityText.Name = "customerCityText";
            this.customerCityText.Size = new System.Drawing.Size(166, 20);
            this.customerCityText.TabIndex = 15;
            // 
            // customerCountryText
            // 
            this.customerCountryText.Location = new System.Drawing.Point(117, 220);
            this.customerCountryText.Name = "customerCountryText";
            this.customerCountryText.Size = new System.Drawing.Size(166, 20);
            this.customerCountryText.TabIndex = 16;
            // 
            // customerZipText
            // 
            this.customerZipText.Location = new System.Drawing.Point(117, 266);
            this.customerZipText.Name = "customerZipText";
            this.customerZipText.Size = new System.Drawing.Size(166, 20);
            this.customerZipText.TabIndex = 17;
            // 
            // CreateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 450);
            this.Controls.Add(this.customerZipText);
            this.Controls.Add(this.customerCountryText);
            this.Controls.Add(this.customerCityText);
            this.Controls.Add(this.customerAddressText);
            this.Controls.Add(this.customerPhoneText);
            this.Controls.Add(this.customerNameText);
            this.Controls.Add(this.customerCancelButton);
            this.Controls.Add(this.customerCreateButton);
            this.Controls.Add(this.activeNo);
            this.Controls.Add(this.activeYes);
            this.Controls.Add(this.customerActiveLabel);
            this.Controls.Add(this.customerZipLabel);
            this.Controls.Add(this.customerCountryLabel);
            this.Controls.Add(this.customerCityLabel);
            this.Controls.Add(this.customerAddressLabel);
            this.Controls.Add(this.customerPhoneLabel);
            this.Controls.Add(this.customerNameLabel);
            this.Controls.Add(this.label1);
            this.Name = "CreateCustomer";
            this.Text = "CreateCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label customerPhoneLabel;
        private System.Windows.Forms.Label customerAddressLabel;
        private System.Windows.Forms.Label customerCityLabel;
        private System.Windows.Forms.Label customerCountryLabel;
        private System.Windows.Forms.Label customerZipLabel;
        private System.Windows.Forms.Label customerActiveLabel;
        private System.Windows.Forms.RadioButton activeYes;
        private System.Windows.Forms.RadioButton activeNo;
        private System.Windows.Forms.Button customerCreateButton;
        private System.Windows.Forms.Button customerCancelButton;
        private System.Windows.Forms.TextBox customerNameText;
        private System.Windows.Forms.TextBox customerPhoneText;
        private System.Windows.Forms.TextBox customerAddressText;
        private System.Windows.Forms.TextBox customerCityText;
        private System.Windows.Forms.TextBox customerCountryText;
        private System.Windows.Forms.TextBox customerZipText;
    }
}