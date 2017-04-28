using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bliss_recruitment_api.Models.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string question { get; set; }
        public string image_url { get; set; }
        public string thumb_url { get; set; }
        public DateTime published_at { get; set; }

        public List<ChoiceDTO> choices { get; set; }
        public QuestionDTO()
        {
            choices = new List<ChoiceDTO>();
        }
    }
}