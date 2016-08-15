using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor_Project;
using TextEditorLibrary;

namespace TextEditor
{

    class MainPresenter
    {
        private readonly IMainForm _mainForm;
        private readonly IFileManager _fileManager;
        private readonly IMessageService _messageService;

        private string _currentFilePath;

        public MainPresenter(IMainForm mainForm, IFileManager fileManager, IMessageService messageService)
        {
            _mainForm = mainForm;
            _fileManager = fileManager;
            _messageService = messageService;

            _mainForm.SetSymbolCount(0);

            _mainForm.ContentChanged += MainFormOnContentChanged;
            _mainForm.FileOpenClick += MainFormOnFileOpenClick;
            _mainForm.FileSaveClick += MainFormOnFileSaveClick;
        }

        private void MainFormOnFileSaveClick(object sender, EventArgs eventArgs)
        {
            try
            {
                string content = _mainForm.Content;

                _fileManager.SaveContent(content, _currentFilePath);

                _messageService.ShowMessage("File Save");
            }
            catch (Exception ex)
            {
                _messageService.ShowMessage(ex.Message);
            }
        }

        private void MainFormOnFileOpenClick(object sender, EventArgs eventArgs)
        {
            try
            {
                string filePath = _mainForm.FilePath;

                bool isExist = _fileManager.IsExist(filePath);

                if (!isExist)
                {
                    _messageService.ShowExclamenation("Choose file not exist");
                    return;
                }

                _currentFilePath = filePath;

                string content = _fileManager.GetContent(filePath);
                int count = _fileManager.GetSymbolCount(content);

                _mainForm.Content = content;
                _mainForm.SetSymbolCount(count);

            }
            catch (Exception ex)
            {
                _messageService.ShowMessage(ex.Message);
            }
        }

        private void MainFormOnContentChanged(object sender, EventArgs eventArgs)
        {
            string content = _mainForm.Content;

            int count = _fileManager.GetSymbolCount(content);

            _mainForm.SetSymbolCount(count);
        }
    }
}
