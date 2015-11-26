using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace FileHeaderChecker.Forms {
	public partial class MainForm : Form {
		private struct CheckerOptions {
			public string[] Extensions;
			public bool AllExtensions;
			public string Root;
		}

		public MainForm() {
			InitializeComponent();
		}

		private void btnPath_Click(object sender, EventArgs e) {
			FolderBrowserDialog dialog = new FolderBrowserDialog() { SelectedPath = txtPath.Text };
			dialog.SelectedPath = txtPath.Text;
			if (dialog.ShowDialog() == DialogResult.OK) {
				txtPath.Text = dialog.SelectedPath;
			}
		}

		private void btnSearch_Click(object sender, EventArgs e) {
			if (Directory.Exists(txtPath.Text)) {
				CheckerOptions options = new CheckerOptions();
				options.Extensions = txtFilter.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				options.AllExtensions = options.Extensions == null || options.Extensions.Length == 0 || options.Extensions[0] == "." || options.Extensions[0] == ".*";
				options.Root = txtPath.Text;

				var files = new List<string>();
				listFiles.Items.Clear();
				IterateDirs(new DirectoryInfo(txtPath.Text), options, ref files);
				listFiles.Items.AddRange(files.ToArray());
				lblDeviants.Text = $"Deviant Files ({files.Count} found):";
				if (files.Count == 0) {
					MessageBox.Show("No deviants found");
				}
			}
		}

		private void IterateDirs(DirectoryInfo dir, CheckerOptions options, ref List<string> files) {
			foreach (DirectoryInfo i in dir.GetDirectories()) {
				// Common SVN/git/conf directories
				if (i.Name.StartsWith(".") || i.Name.StartsWith("_")) continue;
				IterateDirs(i, options, ref files);
			}
			foreach (FileInfo i in dir.GetFiles()) {
				TestFile(i, options, ref files);
			}
		}

		private void TestFile(FileInfo file, CheckerOptions options, ref List<string> files) {
			bool valid = options.AllExtensions;
			foreach (string ext in options.Extensions) {
				if (file.Extension == ext) {
					valid = true;
					break;
				}
			}
			if (!valid) return;
			using (FileStream fs = new FileStream(file.FullName, FileMode.Open)) {
				using (StreamReader sr = new StreamReader(fs)) {
					int textBytes = txtPreamble.TextLength;
					char[] bytes = new char[textBytes];
					sr.ReadBlock(bytes, 0, textBytes);
					string content = new string(bytes);
					if (string.Compare(content, txtPreamble.Text) != 0) {
						files.Add(file.FullName.Replace(options.Root, string.Empty));
					}
				}
			}
		}

		private void btnExit_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
