using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bliss_recruitment_api.Models
{
    public class Choice
    {
        public int ChoiceID { get; set; }
        public string choice { get; set; }
        public int votes { get; set; }
        public int QuestionID { get; set; }

        public virtual Question question { get; set; }
        
    }
}