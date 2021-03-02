using System;
using System.IO;
using Module2_Task5.Services.Contracts;

namespace Module2_Task5.Services
{
    public class FileService : IFileService
    {
        public void Write(string directoryPath, string text)
        {
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath);

                if (files.Length >= 3)
                {
                    var oldestFileInfo = new FileInfo($"{directoryPath}/{files[0]}");
                    var oldestFileCreationTime = oldestFileInfo.CreationTime;

                    for (var i = 0; i < files.Length; i++)
                    {
                        FileInfo fileInf = new FileInfo($"{directoryPath}/{files[i]}");
                        DateTime currentFileCrationTime = fileInf.CreationTime;

                        if (currentFileCrationTime < oldestFileCreationTime)
                        {
                            oldestFileCreationTime = currentFileCrationTime;
                        }

                        File.Delete($"{directoryPath}/{oldestFileInfo.Name}");
                    }
                }

                var newLogPath = $"{directoryPath}/{DateTime.UtcNow.ToString("hh.mm.ss dd.MM.yyyy")}.txt";
                File.WriteAllText(newLogPath, text);
            }
        }
    }
}
