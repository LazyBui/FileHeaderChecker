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

		private void IterateDirs(DirectoryInfo pDir, CheckerOptions pOptions, ref List<string> pFiles) {
			foreach (DirectoryInfo i in pDir.GetDirectories()) {
				// Common SVN/git/conf directories
				if (i.Name.StartsWith(".") || i.Name.StartsWith("_")) continue;
				IterateDirs(i, pOptions, ref pFiles);
			}
			foreach (FileInfo i in pDir.GetFiles()) {
				TestFile(i, pOptions, ref pFiles);
			}
		}

		private void TestFile(FileInfo pFile, CheckerOptions pOptions, ref List<string> pFiles) {
			bool valid = pOptions.AllExtensions;
			foreach (string ext in pOptions.Extensions) {
				if (pFile.Extension == ext) {
					valid = true;
					break;
				}
			}
			if (!valid) return;
			using (FileStream fs = new FileStream(pFile.FullName, FileMode.Open)) {
				using (StreamReader sr = new StreamReader(fs)) {
					int textBytes = txtPreamble.TextLength;
					char[] bytes = new char[textBytes];
					sr.ReadBlock(bytes, 0, textBytes);
					string content = new string(bytes);
					if (string.Compare(content, txtPreamble.Text) != 0) {
						pFiles.Add(pFile.FullName.Replace(pOptions.Root, string.Empty));
					}
				}
			}
		}

		private void btnExit_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
