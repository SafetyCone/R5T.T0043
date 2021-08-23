using System;

using R5T.Magyar.T002;


namespace R5T.T0043.T002.X001
{
    public static class Instances
    {
        public static IExceptionMessageGenerator ExceptionMessageGenerator { get; } = Magyar.T002.ExceptionMessageGenerator.Instance;
        public static IProjectIndexEntryOperator ProjectIndexEntryOperator { get; } = T002.ProjectIndexEntryOperator.Instance;
    }
}
