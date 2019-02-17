using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Record_Project
{
    class RecordQuestion
    {
        public int questionId;
        public String questions;
        public String qOpa;
        public String qOpb;
        public String qOpc;
        public String qOpANS;

        public override string ToString()
        {
            return questions;
        }
    }
}
