using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditorLibrary;
using TextEditor_Project;

namespace TextEditor
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// 
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();
            FileManager fileManager = new FileManager();
            MessageService messageService = new MessageService();

            MainPresenter presenter = new MainPresenter(mainForm, fileManager, messageService);

            Application.Run(mainForm);
        }
    }
}
