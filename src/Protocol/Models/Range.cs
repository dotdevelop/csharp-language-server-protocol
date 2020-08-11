using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OmniSharp.Extensions.LanguageServer.Protocol.Models
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Range : IEquatable<Range>
    {
        public Range()
        {
        }

        public Range(Position start, Position end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// The range's start position.
        /// </summary>
        public Position Start { get; set; }

        /// <summary>
        /// The range's end position.
        /// </summary>
        public Position End { get; set; }

        public override bool Equals(object obj) => Equals(obj as Range);

        public bool Equals(Range other) =>
            other != null &&
            EqualityComparer<Position>.Default.Equals(Start, other.Start) &&
            EqualityComparer<Position>.Default.Equals(End, other.End);

        public override int GetHashCode()
        {
            var hashCode = -1676728671;
            hashCode = hashCode * -1521134295 + EqualityComparer<Position>.Default.GetHashCode(Start);
            hashCode = hashCode * -1521134295 + EqualityComparer<Position>.Default.GetHashCode(End);
            return hashCode;
        }

        public static bool operator ==(Range range1, Range range2) => EqualityComparer<Range>.Default.Equals(range1, range2);

        public static bool operator !=(Range range1, Range range2) => !( range1 == range2 );

        public static implicit operator Range((Position start, Position end) value) => new Range(value.start, value.end);

        private string DebuggerDisplay => $"[start: {Start}, end: {End}]";

        /// <inheritdoc />
        public override string ToString() => DebuggerDisplay;
    }
}
