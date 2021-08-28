using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis;

using R5T.T0043.T001;
using R5T.T0043.T002;


namespace System
{
    public static class IProjectIndexOperatorExtensions
    {
        public static void AddEntry(this IProjectIndexOperator _,
            ProjectIndex index,
            Project project)
        {
            var projectName = project.AssemblyName;
            var projectFilePath = project.FilePath;

            _.AddEntry(index,
                projectName,
                projectFilePath);
        }

        public static void AddEntries(this IProjectIndexOperator _,
            ProjectIndex index,
            IEnumerable<Project> projects)
        {
            foreach (var project in projects)
            {
                _.AddEntry(index, project);
            }
        }
    }
}
