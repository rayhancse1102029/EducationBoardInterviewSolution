using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationBoardInterviewSolution.Data.Entity.EducationBoard
{
    public class Student : Base
    {
        public int? schoolId { get; set; }
        public School school { get; set; }
        public int? deptId { get; set; }
        public Dept dept { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
