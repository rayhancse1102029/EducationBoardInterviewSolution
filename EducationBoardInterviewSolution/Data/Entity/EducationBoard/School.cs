using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationBoardInterviewSolution.Data.Entity.EducationBoard
{
    public class School : Base
    {
        public int? districtId { get; set; }
        public District district { get; set; }
        public string name { get; set; }
    }
}
