using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bliss_recruitment_api.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for the Question object
    /// </summary>
    public class QuestionDTO
    {
        /// <summary>
        /// Question ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Question
        /// </summary>
        public string question { get; set; }
        /// <summary>
        /// Image Url
        /// </summary>
        public string image_url { get; set; }
        /// <summary>
        /// Thumb Url
        /// </summary>
        public string thumb_url { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime published_at { get; set; }
        /// <summary>
        /// List of Choices
        /// </summary>
        public List<ChoiceDTO> choices { get; set; }
        public QuestionDTO()
        {
            choices = new List<ChoiceDTO>();
        }
    }
}