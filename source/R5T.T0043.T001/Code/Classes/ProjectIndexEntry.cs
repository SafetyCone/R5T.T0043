using System;


namespace R5T.T0043.T001
{
    public sealed class ProjectIndexEntry : IEquatable<ProjectIndexEntry>
    {
        #region Static

        public static bool operator ==(ProjectIndexEntry lhs, ProjectIndexEntry rhs)
        {
            var output = lhs is null
                ? rhs is null
                : lhs.Equals(rhs)
                ;

            return output;
        }

        public static bool operator !=(ProjectIndexEntry lhs, ProjectIndexEntry rhs)
        {
            var output = !(lhs == rhs);
            return output;
        }

        #endregion


        public string Name { get; set; }
        public string FilePath { get; set; }


        public bool Equals(ProjectIndexEntry other)
        {
            // This cannot be null, so check the other.
            if (other is null)
            {
                return false;
            }

            // Now check property equality.
            var output = true
                && this.FilePath == other.FilePath
                && this.Name == other.Name
                ;

            return output;
        }

        public override bool Equals(object obj)
        {
            // Sealed reference type, so very simple.
            var objAsProjectIndexEntry = obj as ProjectIndexEntry;

            var output = this.Equals(objAsProjectIndexEntry);
            return output;
        }

        public override int GetHashCode()
        {
            var output = HashCode.Combine(
                this.FilePath,
                this.Name);

            return output;
        }

        public override string ToString()
        {
            var representation = $"{this.Name}: {this.FilePath}";
            return representation;
        }
    }
}
