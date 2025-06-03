using BatchStudio.Infrastructures;
using BatchStudio.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace BatchStudio.ViewModels
{
    public class BatchStudioViewModel : ViewModelBase
    {
        private static BatchStudioViewModel m_instance;
        internal static BatchStudioViewModel Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new BatchStudioViewModel();
                return m_instance;
            }
        }

        private BatchStudioViewModel()
        {
            Commands = new ObservableCollection<ScriptCommand>
            {
                new ScriptCommand { CommandText = "@echo off" }
            };

            NewCommandText = string.Empty;
            UpdateGeneratedScript();
        }

        public ObservableCollection<ScriptCommand> Commands { get; set; }

        private string m_NewCommandText;
        public string NewCommandText
        {
            get { return m_NewCommandText; }
            set { SetProperty(ref m_NewCommandText, value); }
        }

        private string m_GeneratedScript;
        public string GeneratedScript
        {
            get { return m_GeneratedScript; }
            set
            {
                if (SetProperty(ref m_GeneratedScript, value))
                {
                    var lines = value.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                    Commands.Clear();
                    foreach (var line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            Commands.Add(new ScriptCommand { CommandText = line });
                    }
                }
            }
        }

        private RelayCommand m_AddCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (m_AddCommand == null)
                {
                    m_AddCommand = new RelayCommand((obj) =>
                    {
                        if (!string.IsNullOrWhiteSpace(NewCommandText))
                        {
                            Commands.Add(new ScriptCommand { CommandText = NewCommandText });
                            NewCommandText = string.Empty;
                            UpdateGeneratedScript();
                        }
                    });
                }
                return m_AddCommand;
            }
        }

        private RelayCommand m_ExportCommand;
        public RelayCommand ExportCommand
        {
            get
            {
                if (m_ExportCommand == null)
                {
                    m_ExportCommand = new RelayCommand((obj) =>
                    {
                        var dialog = new Microsoft.Win32.SaveFileDialog
                        {
                            Filter = "Batch files (*.bat)|*.bat",
                            FileName = "GeneratedScript.bat"
                        };

                        if (dialog.ShowDialog() == true)
                        {
                            File.WriteAllText(dialog.FileName, GeneratedScript);

                            // Compatible with older .NET Framework
                            var psi = new System.Diagnostics.ProcessStartInfo("explorer.exe", "/select,\"" + dialog.FileName + "\"");
                            psi.UseShellExecute = true;
                            System.Diagnostics.Process.Start(psi);
                        }
                    });
                }
                return m_ExportCommand;
            }
        }

        private RelayCommand m_ClearAllCommand;
        public RelayCommand ClearAllCommand
        {
            get
            {
                if (m_ClearAllCommand == null)
                {
                    m_ClearAllCommand = new RelayCommand((obj) =>
                    {
                        Commands.Clear();
                        Commands.Add(new ScriptCommand { CommandText = "@echo off" });
                        UpdateGeneratedScript();
                    });
                }
                return m_ClearAllCommand;
            }
        }

        private void UpdateGeneratedScript()
        {
            var sb = new StringBuilder();
            foreach (var cmd in Commands)
            {
                sb.AppendLine(cmd.CommandText);
            }
            GeneratedScript = sb.ToString();
        }
    }
}
