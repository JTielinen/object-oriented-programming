using System;
using System.IO;
using System.Text;

namespace Example
{
    public class WordListNotFoundException : Exception
    {
        public WordListNotFoundException(string message) : base(message)
        {
        }
    }

    class FileManager
    {
        private string filePath;
        public FileManager()
        {
            this.filePath = string.Empty;
        }
        public FileManager(string filePath)
        {
            this.filePath = filePath;
        }

        public string ReadWords()
        {
            try
            {
                return ReadFile();
            }
            catch (WordListNotFoundException ex)
            {
                Console.WriteLine($"Virhe: {ex.Message}");
                return string.Empty;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Virhe: {ex.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tuntematon virhe: {ex.Message}");
                return string.Empty;
            }
        }
        private string ReadFile()
        {
            if (!File.Exists(filePath))
            {
                throw new WordListNotFoundException("Tiedostoa ei löytynyt!");
            }

            string directoryName = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            string fileExtension = Path.GetExtension(filePath);

            Console.WriteLine("directoryName: " + directoryName);
            Console.WriteLine("fileName: " + fileName);
            Console.WriteLine("fileExtension: " + fileExtension);

            string fileContent = File.ReadAllText(filePath, Encoding.UTF8);
            return fileContent;
        }
    }
}
