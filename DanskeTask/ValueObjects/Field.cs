using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanskeTask.Components;

namespace DanskeTask.ValueObjects
{
    public class Field
    {
        public object Value { get; set; }
        public Operator Operator { get; set; }
        public string Property { get; set; }
    }
}
