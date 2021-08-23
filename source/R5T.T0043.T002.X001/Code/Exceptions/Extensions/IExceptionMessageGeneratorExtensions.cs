using System;

using R5T.Magyar.T002;

using R5T.T0043.T001;

using Instances = R5T.T0043.T002.X001.Instances;


namespace System
{
    public static class IExceptionMessageGeneratorExtensions
    {
        public static string EntryAlreadyExists(this IExceptionMessageGenerator _,
            ProjectIndexEntry entry)
        {
            var output = $"Entry already exists:\n{Instances.ProjectIndexEntryOperator.GetDescription(entry)}";
            return output;
        }
    }
}
