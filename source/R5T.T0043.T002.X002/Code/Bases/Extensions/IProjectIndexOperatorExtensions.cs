using System;

using Newtonsoft.Json;

using R5T.Magyar.IO;

using R5T.T0043.T001;
using R5T.T0043.T002;


namespace System
{
    public static class ITypeCodeLocationIndexOperatorExtensions
    {
        public static ProjectIndex LoadFromJsonFile(this IProjectIndexOperator _,
            string jsonFilePath)
        {
            var entriesArray = JsonFileHelper.LoadFromFile<ProjectIndexEntry[]>(jsonFilePath);

            var output = _.From(entriesArray);
            return output;
        }

        public static void WriteToJsonFile(this IProjectIndexOperator _,
            string jsonFilePath,
            ProjectIndex index,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            _.OrderEntriesAlphabeticallyByName(index);

            _.WriteToJsonFileWithoutAlphabetization(jsonFilePath, index, overwrite);
        }

        public static void WriteToJsonFileWithoutAlphabetization(this IProjectIndexOperator _,
            string jsonFilePath,
            ProjectIndex index,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            JsonFileHelper.WriteToFile(jsonFilePath, index.Entries, overwrite: overwrite);
        }
    }
}
