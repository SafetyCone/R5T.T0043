using System;

using R5T.T0043.T001;
using R5T.T0043.T002;


namespace System
{
    public static class IProjectIndexEntryOperatorExtensions
    {
        public static bool Equal(this IProjectIndexEntryOperator _,
            ProjectIndexEntry a,
            ProjectIndexEntry b)
        {
            var output = a == b;
            return output;
        }

        public static bool Equal(this IProjectIndexEntryOperator _,
            ProjectIndexEntry a,
            string projectName,
            string projectFilePath)
        {
            var output = a is not null
                && a.FilePath == projectFilePath
                && a.Name == projectName
                ;

            return output;
        }

        public static ProjectIndexEntry From(this IProjectIndexEntryOperator _,
            string projectName,
            string projectFilePath)
        {
            var output = new ProjectIndexEntry
            {
                FilePath = projectFilePath,
                Name = projectName
            };

            return output;
        }

        public static string GetDescription(this IProjectIndexEntryOperator _,
            ProjectIndexEntry entry)
        {
            var output = entry.ToString();
            return output;
        }

        public static bool HasProjectFilePath(this IProjectIndexEntryOperator _,
            ProjectIndexEntry entry,
            string projectFilePath)
        {
            var output = entry.FilePath == projectFilePath;
            return output;
        }

        public static bool HasProjectName(this IProjectIndexEntryOperator _,
            ProjectIndexEntry entry,
            string projectName)
        {
            var output = entry.Name == projectName;
            return output;
        }
    }
}
