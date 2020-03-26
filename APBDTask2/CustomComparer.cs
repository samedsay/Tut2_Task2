using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tutorial2.Models;

namespace Tutorial2
{
    public class CustomComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.Name}{x.Surname}{x.StudentNumber}",
                $"{y.Name}{y.Surname}{y.StudentNumber}");
        }    
        public int GetHashCode( Student obj)
        {
            return StringComparer.
                 CurrentCultureIgnoreCase
                 .GetHashCode($"{obj.Name}{obj.Surname}{obj.StudentNumber}");
        }
    }
}
