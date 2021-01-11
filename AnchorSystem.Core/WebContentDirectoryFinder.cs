using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AnchorSystem.Core
{
    public static class WebContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            var coreAssemblyDirectoryPath = Path.GetDirectoryName(typeof(WebContentDirectoryFinder).GetTypeInfo().Assembly.Location);
            if (coreAssemblyDirectoryPath == null)
            {
                throw new Exception("Could not find location of Vip.Core assembly!");
            }

            var directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);
            while (!DirectoryContains(directoryInfo.FullName, "AnchorSystem.sln"))
            {
                directoryInfo = directoryInfo.Parent ?? throw new Exception("Could not find content root folder!");
            }

            var webHostFolder = Path.Combine(directoryInfo.FullName, "AnchorSystem.WebHost");
            if (Directory.Exists(webHostFolder))
            {
                return webHostFolder;
            }

            throw new Exception("Could not find root folder of the web project!");
        }

        private static bool DirectoryContains(string directory, string fileName)
        {
            return Directory.GetFiles(directory).Any(filePath => string.Equals(Path.GetFileName(filePath), fileName));
        }
    }
}
