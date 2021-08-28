using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;

using R5T.T0043.T001;
using R5T.T0043.T002;

using Instances = R5T.T0043.T002.X001.Instances;


namespace System
{
    public static class IProjectIndexOperatorExtensions
    {
        public static void AddEntryUnconstrained(this IProjectIndexOperator _,
            ProjectIndex index,
            ProjectIndexEntry entry)
        {
            index.Entries.Add(entry);
        }

        public static void AddEntryIdempotent(this IProjectIndexOperator _,
            ProjectIndex index,
            ProjectIndexEntry entry)
        {
            var wasFound = _.HasEntry(index, entry);
            if (!wasFound)
            {
                // Only if not found, add the entry.
                _.AddEntryUnconstrained(index, entry);
            }
        }

        public static void AddEntryNonIdempotent(this IProjectIndexOperator _,
            ProjectIndex index,
            ProjectIndexEntry entry)
        {
            var wasFound = _.HasEntry(index, entry);
            if (!wasFound)
            {
                var message = Instances.ExceptionMessageGenerator.EntryAlreadyExists(entry);

                throw new InvalidOperationException(message);
            }

            _.AddEntryUnconstrained(index, entry);
        }

        /// <summary>
        /// Selects <see cref="AddEntryIdempotent(IProjectIndexOperator, ProjectIndex, ProjectIndexEntry)"/> as the default.
        /// </summary>
        public static void AddEntry(this IProjectIndexOperator _,
            ProjectIndex index,
            ProjectIndexEntry entry)
        {
            _.AddEntryIdempotent(index, entry);
        }

        public static void AddEntry(this IProjectIndexOperator _,
            ProjectIndex index,
            string projectName,
            string projectFileName)
        {
            var entry = Instances.ProjectIndexEntryOperator.From(
                projectName,
                projectFileName);

            _.AddEntry(index, entry);
        }

        public static void ClearEntries(this IProjectIndexOperator _,
            ProjectIndex index)
        {
            index.Entries.Clear();
        }

        public static ProjectIndex From(this IProjectIndexOperator _,
            IEnumerable<ProjectIndexEntry> entries)
        {
            var output = _.New();

            output.Entries.AddRange(entries);

            return output;
        }

        public static WasFound<ProjectIndexEntry> HasEntry(this IProjectIndexOperator _,
            ProjectIndex index,
            ProjectIndexEntry entry)
        {
            var entryOrDefault = index.Entries
                .Where(xEntry => Instances.ProjectIndexEntryOperator.Equal(xEntry, entry))
                .FirstOrDefault(); // Use less-robust but perhaps speedier First().

            var output = WasFound.From(entryOrDefault);
            return output;
        }

        public static WasFound<ProjectIndexEntry> HasEntry(this IProjectIndexOperator _,
            ProjectIndex index,
            string projectName,
            string projectFilePath)
        {
            var entryOrDefault = index.Entries
                .Where(xEntry => Instances.ProjectIndexEntryOperator.Equal(xEntry, projectName, projectFilePath))
                .FirstOrDefault(); // Use less-robust but perhaps speedier First().

            var output = WasFound.From(entryOrDefault);
            return output;
        }

        public static WasFound<ProjectIndexEntry> HasEntry(this IProjectIndexOperator _,
            ProjectIndex index,
            string projectFilePath)
        {
            var entryOrDefault = index.Entries
                .Where(xEntry => Instances.ProjectIndexEntryOperator.HasProjectFilePath(xEntry, projectFilePath))
                .FirstOrDefault(); // Use less-robust but perhaps speedier First().

            var output = WasFound.From(entryOrDefault);
            return output;
        }

        public static ProjectIndex New(this IProjectIndexOperator _)
        {
            var output = new ProjectIndex();
            return output;
        }

        public static void OrderEntriesAlphabeticallyByName(this IProjectIndexOperator _,
            ProjectIndex index)
        {
            var orderedEntries = index.Entries
                .OrderAlphabetically(xEntry => xEntry.Name)
                .ToArray();

            _.ReplaceEntries(index, orderedEntries);
        }

        public static void ReplaceEntries(this IProjectIndexOperator _,
            ProjectIndex index,
            ICollection<ProjectIndexEntry> collection)
        {
            _.ClearEntries(index);

            index.Entries.AddRange(collection);
        }
    }
}
