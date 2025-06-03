using BatchStudio.Models;
using System.Collections.ObjectModel;

namespace BatchStudio.Services
{
    internal static class ScriptBuilderService
    {
        internal static string BuildScriptText(ObservableCollection<ScriptCommand> commands)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("@echo off");

            foreach (var cmd in commands)
            {
                sb.AppendLine(cmd.CommandText);
            }

            return sb.ToString();
        }
    }
}
