using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    /// <summary>
    /// Generate message 
    /// </summary>
    /// 
    /// 
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamenation(string exclamenation);
        void ShowError(string error);
    }

    class MessageService : IMessageService
    {

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowExclamenation(string exclamenation)
        {
            MessageBox.Show(exclamenation, "Exclamenation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void ShowError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
