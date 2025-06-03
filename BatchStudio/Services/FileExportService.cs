using BatchStudio.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace BatchStudio.Services
{
    internal static class FileExportService
    {
        internal static void ExportAsBatchFile(string filePath, ObservableCollection<ScriptCommand> commands)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("@echo off"); // Default line
                foreach (var cmd in commands)
                {
                    writer.WriteLine(cmd.CommandText);
                }
            }
        }
    }
}
