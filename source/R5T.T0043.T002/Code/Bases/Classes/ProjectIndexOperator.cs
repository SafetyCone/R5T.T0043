using System;


namespace R5T.T0043.T002
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class ProjectIndexOperator : IProjectIndexOperator
    {
        #region Static

        public static ProjectIndexOperator Instance { get; } = new();

        #endregion
    }
}