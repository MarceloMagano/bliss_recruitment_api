using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bliss_recruitment_api.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for the Choice object
    /// </summary>
    public class ChoiceDTO
    {
        /// <summary>
        /// Choice
        /// </summary>
        public string choice { get; set; }
        /// <summary>
        /// Number of votes the Choice
        /// </summary>
        public int votes { get; set; }

        public ChoiceDTO()
        {

        }
    }
}