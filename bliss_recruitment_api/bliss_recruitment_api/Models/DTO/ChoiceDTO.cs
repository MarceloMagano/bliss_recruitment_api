using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bliss_recruitment_api.Models.DTO
{
    public class ChoiceDTO
    {
        public string choice { get; set; }
        public int votes { get; set; }

        public ChoiceDTO()
        {

        }
    }
}