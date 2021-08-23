using System;


namespace R5T.T0043.T002
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class ProjectIndexEntryOperator : IProjectIndexEntryOperator
    {
        #region Static

        public static ProjectIndexEntryOperator Instance { get; } = new();

        #endregion
    }
}