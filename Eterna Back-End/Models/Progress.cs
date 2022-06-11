using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eterna_Back_End.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectProgress { get; set; }
        public byte ProgressValue { get; set; }
        public byte ProgressValueNow { get; set; }
        public byte ProgressValueMin { get; set; }
        public byte ProgressValueMax { get; set; }
    }
}
