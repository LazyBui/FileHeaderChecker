namespace FileHeaderChecker.Forms {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnPath = new System.Windows.Forms.Button();
			this.txtPreamble = new System.Windows.Forms.TextBox();
			this.listFiles = new System.Windows.Forms.ListBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.lblDeviants = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.txtFilter = new Extensions.System.Windows.Forms.TextBoxExtended();
			this.txtPath = new Extensions.System.Windows.Forms.TextBoxExtended();
			this.SuspendLayout();
			// 
			// btnPath
			// 
			this.btnPath.Location = new System.Drawing.Point(541, 6);
			this.btnPath.Name = "btnPath";
			this.btnPath.Size = new System.Drawing.Size(27, 21);
			this.btnPath.TabIndex = 1;
			this.btnPath.Text = "...";
			this.btnPath.UseVisualStyleBackColor = true;
			this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// txtPreamble
			// 
			this.txtPreamble.Location = new System.Drawing.Point(3, 61);
			this.txtPreamble.Multiline = true;
			this.txtPreamble.Name = "txtPreamble";
			this.txtPreamble.Size = new System.Drawing.Size(565, 261);
			this.txtPreamble.TabIndex = 4;
			// 
			// listFiles
			// 
			this.listFiles.FormattingEnabled = true;
			this.listFiles.Location = new System.Drawing.Point(3, 342);
			this.listFiles.Name = "listFiles";
			this.listFiles.Size = new System.Drawing.Size(565, 121);
			this.listFiles.TabIndex = 5;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(3, 469);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 6;
			this.btnSearch.Text = "&Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// lblDeviants
			// 
			this.lblDeviants.AutoSize = true;
			this.lblDeviants.Location = new System.Drawing.Point(0, 325);
			this.lblDeviants.Name = "lblDeviants";
			this.lblDeviants.Size = new System.Drawing.Size(120, 13);
			this.lblDeviants.TabIndex = 7;
			this.lblDeviants.Text = "Deviant Files (0 found):";
			// 
			// btnExit
			// 
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnExit.Location = new System.Drawing.Point(493, 469);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 8;
			this.btnExit.Text = "E&xit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// txtFilter
			// 
			this.txtFilter.ForeColor = System.Drawing.Color.Black;
			this.txtFilter.Location = new System.Drawing.Point(3, 34);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Placeholder = "File Type Filter (ex: .cpp .h)";
			this.txtFilter.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.txtFilter.Size = new System.Drawing.Size(565, 21);
			this.txtFilter.TabIndex = 3;
			this.txtFilter.UsePlaceholder = true;
			// 
			// txtPath
			// 
			this.txtPath.ForeColor = System.Drawing.Color.Black;
			this.txtPath.Location = new System.Drawing.Point(3, 7);
			this.txtPath.Name = "txtPath";
			this.txtPath.Placeholder = "Root Directory";
			this.txtPath.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.txtPath.Size = new System.Drawing.Size(532, 21);
			this.txtPath.TabIndex = 2;
			this.txtPath.UsePlaceholder = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(572, 496);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.lblDeviants);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.listFiles);
			this.Controls.Add(this.txtPreamble);
			this.Controls.Add(this.txtFilter);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.btnPath);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "File Header Checker";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPath;
		private Extensions.System.Windows.Forms.TextBoxExtended txtPath;
		private Extensions.System.Windows.Forms.TextBoxExtended txtFilter;
		private System.Windows.Forms.TextBox txtPreamble;
		private System.Windows.Forms.ListBox listFiles;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label lblDeviants;
		private System.Windows.Forms.Button btnExit;
	}
}

