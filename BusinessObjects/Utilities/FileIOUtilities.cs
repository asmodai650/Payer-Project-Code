using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Novus.DTBusinessLogicLayer.Common;
using Novus.DTBusinessObjects.Common;

namespace Novus.Payer1060.BusinessObjects.Utilities
{
    public static class FileIOUtilities
    {
        /// <summary>
        /// Returns path for given type.
        /// </summary>
        public static string GetProjectPath(int projectId, ProjectPathsInfo.PathTypes pathType)
        {
            var projectInfo = new Project().GetProjectPathsByKey(projectId);
            var path = projectInfo.GetProjectPath(DTLobTypes.DataMining, pathType);

            return path.PathName;
        }

        /// <summary>
        /// Returns path for given type with feed directory appended to end.
        /// e.g. work\2
        /// </summary>
        public static string GetProjectPathWithFeedDirectory(int projectId, int feedId, ProjectPathsInfo.PathTypes pathType)
        {
            var path = GetProjectPath(projectId, pathType);
            return $@"{path}\{feedId}";
        }

        public static string CopyFile(string sourceFileName, string targetFileName)
        {
            File.Copy(sourceFileName, targetFileName, true);
            return $"Successfully copied {sourceFileName} to {targetFileName}";
        }

        public static List<string> GetDirectoryFilesWithRegex(string directoryPath, Regex regex)
        {
            return Directory.GetFiles(directoryPath).Where(f => regex.IsMatch(Path.GetFileName(f))).ToList();
        }

        /// <summary>
        /// Flush and Close this StreamWriter.
        /// </summary>
        public static void FlushAndClose(this StreamWriter writer)
        {
            writer?.Flush();
            writer?.Close();
        }

        /// <summary>
        /// Given a feedId, basename and list of projectIds, returns a dictionary of streamwriters that can append to child project files.
        /// <br/>Functions as an extension of the SplitProjectCollection class that allows APPENDING to child project files rather than overwriting them.
        /// </summary>
        /// <returns>StreamWriters indexed by projectId: [projectId,StreamWriter]</returns>
        public static Dictionary<int, StreamWriter> CreateAppendableStreamWriters(int feedId, string baseFileName, ICollection<int> projectIds)
        {
            var writers = new Dictionary<int, StreamWriter>();
            foreach (var id in projectIds)
            {
                writers.Add(id, new StreamWriter(baseFileName.Replace(".txt", $"{id}_{feedId}.txt"), true));
            }

            return writers;
        }

        /// <summary>
        /// This file exists and contains more than just a header line.
        /// </summary>
        public static bool FileContainsData(string file, bool hasHeader = true)
        {
            if (File.Exists(file))
            {
                using (var sr = new StreamReader(file))
                {
                    if (hasHeader)
                        sr.ReadLine();
                    return sr.ReadLine() != null;
                }
            }

            return false;
        }
    }
}
