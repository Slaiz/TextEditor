using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public interface IFileManager
    {
        bool IsExist(string filepath);
        string GetContent(string filepath);
        string GetContent(string filepath, Encoding encoding);
        void SaveContent(string contetn, string filepath);
        void SaveContent(string contetn, string filepath, Encoding encoding);
        int GetSymbolCount(string content);

    }
    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultendEncoding = Encoding.GetEncoding(1251);

        public bool IsExist(string filepath)
        {
            bool isExist = File.Exists(filepath);
            return isExist;
        }

        public string GetContent(string filepath)
        {
            return GetContent(filepath, _defaultendEncoding);
        }

        public string GetContent(string filepath, Encoding encoding)
        {
            string content = File.ReadAllText(filepath, encoding);
            return content;
        }

        public void SaveContent(string content, string filepath)
        {
            SaveContent(content, filepath, _defaultendEncoding);
        }

        public void SaveContent(string content, string filepath, Encoding encoding)
        {
            File.WriteAllText(filepath, content, encoding);
        }

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }
    }
}
