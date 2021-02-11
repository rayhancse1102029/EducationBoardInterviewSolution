using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationBoardInterviewSolution.Data.Entity.EducationBoard
{
    public class District : Base
    {
        public int? divisionId { get; set; }
        public Division division { get; set; }
        public string name { get; set; }
    }
}
