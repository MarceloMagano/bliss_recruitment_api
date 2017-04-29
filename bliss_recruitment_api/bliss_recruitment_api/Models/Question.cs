using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bliss_recruitment_api.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string question { get; set; }
        public string image_url { get; set; }
        public string thumb_url { get; set; }
        public DateTime published_at { get; set; }

        public virtual List<Choice> choices { get; set; }
    }
}