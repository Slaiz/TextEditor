using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);

        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            btnOpen.Click += BtnOpenOnClick;
            btnSave.Click += BtnSaveOnClick;
            fldContent.TextChanged += FldContentOnTextChanged;
            btnSelect.Click += btnSelectFile_Click;
            numbFont.ValueChanged += NumbFontOnValueChanged;
        }

        #region Release event
        private void FldContentOnTextChanged(object sender, EventArgs eventArgs)
        {
            ContentChanged?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSaveOnClick(object sender, EventArgs eventArgs)
        {
            FileSaveClick?.Invoke(this, EventArgs.Empty);
        }

        private void BtnOpenOnClick(object sender, EventArgs eventArgs)
        {
            FileOpenClick?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Realease interface IMainForm 
        public string Content
        {
            get { return fldContent.Text; }

            set { fldContent.Text = Content; }
        }

        public string FilePath
        {
            get { return fldFilePath.Text; }
        }

        public void SetSymbolCount(int count)
        {
            fldsymbolCount.Text = count.ToString();
        }

        public event EventHandler ContentChanged;
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        #endregion

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "TextFile|*.txt|AllFile|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        private void NumbFontOnValueChanged(object sender, EventArgs eventArgs)
        {
            fldContent.Font = new Font("TimesNewRoman", (float)numbFont.Value);
        }
    }
}
