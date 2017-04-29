using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using bliss_recruitment_api.Models;
using bliss_recruitment_api.Models.DTO;
using bliss_recruitment_api.DAL;
using System;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace bliss_recruitment_api.Controllers
{
    public class QuestionsController : ApiController
    {
        private ApiContext db = new ApiContext();

        /// <summary>
        /// List All Questions limited by the parameters
        /// </summary>
        /// <param name="limit">The number of records to retrieve</param>
        /// <param name="offset">0 based starting index of the first retrieved record. If you invoked with limit=5 then you should use offset=5 to obtain the next records. If you asked for 5 but only got 4, e.g., that means there are no more records to show.</param>
        /// <param name="filter">Use this field to search for the filter pattern on "question" and "choice" properties. The search will perform a "lowercase contains" strategy on those fields to retrieve results.</param>
        /// <returns>Lists all records found as JSON</returns>
        // GET: api/Questions?limit={limit}&offset={offset}&filter={filter}
        [ResponseType(typeof(IList<QuestionDTO>))]
        public IHttpActionResult GetQuestions(int limit, int offset, string filter = "")
        {
            //validation of limit and offset
            //limit should be positive and offset should 0 or bigger
            if (limit > 0 && offset > -1)
            {
                //no filter was passed as parameter
                if (filter == "")
                {
                    var ls = db.Question.OrderBy(o => o.Id).Skip(offset).Take(limit);
                    List<QuestionDTO> list = new List<QuestionDTO>();
                    foreach (Question x in ls)
                    {
                        QuestionDTO q = new QuestionDTO() { Id = x.Id, question = x.question, image_url = x.image_url, thumb_url = x.thumb_url, published_at = x.published_at, choices = new List<ChoiceDTO>() };
                        x.choices.ForEach(c => q.choices.Add(new ChoiceDTO() { choice = c.choice, votes = c.votes }));
                        list.Add(q);
                    }
                    return Ok(list);
                }
                //with filter
                else
                {
                    var ls = db.Question.OrderBy(o => o.Id).Skip(offset).Take(limit).Where(q => q.question.ToLower().Contains(filter.ToLower()) || q.choices.Any(c => c.choice.ToLower().Contains(filter.ToLower())));
                    List<QuestionDTO> list = new List<QuestionDTO>();
                    foreach (Question x in ls)
                    {
                        QuestionDTO q = new QuestionDTO() { Id = x.Id, question = x.question, image_url = x.image_url, thumb_url = x.thumb_url, published_at = x.published_at, choices = new List<ChoiceDTO>() };
                        x.choices.ForEach(c => q.choices.Add(new ChoiceDTO() { choice = c.choice, votes = c.votes }));
                        list.Add(q);
                    }
                    return Ok(list);
                }
            }
            //return 404 when parameters are not corret
            else
                return NotFound();


        }

        /// <summary>
        /// Retrieve a Question
        /// </summary>
        /// <param name="id">ID of the question to retrieve</param>
        /// <returns>Object found as JSON</returns>
        // GET: api/Questions/:id
        [ResponseType(typeof(QuestionDTO))]
        public IHttpActionResult GetQuestion(int id)
        {
            //try to retrieve Question from DB
            Question question = db.Question.Find(id);
            if (question == null)
                return NotFound();

            //transforms Question in QuestionDTO
            QuestionDTO qdto = new QuestionDTO { Id = question.Id, question = question.question, image_url = question.image_url, thumb_url = question.thumb_url, published_at = question.published_at, choices = new List<ChoiceDTO>() };
            question.choices.ForEach(c => qdto.choices.Add(new ChoiceDTO() { choice = c.choice, votes = c.votes }));

            return Ok(qdto);
        }
        /// <summary>
        /// Create new Question
        /// </summary>
        /// <param name="questionDTO">JSON object to be created</param>
        /// <returns></returns>
        // POST: api/Questions
        [ResponseType(typeof(QuestionDTO))]
        public IHttpActionResult PostQuestion(QuestionDTO questionDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //transform QuestionDTO in Question
            Question q = new Question() { question = questionDTO.question, image_url = questionDTO.image_url, thumb_url = questionDTO.thumb_url, published_at = DateTime.Now };
            //create new Question on DB
            db.Question.Add(q);
            db.SaveChanges();

            //create new Choices for the new Question on DB
            questionDTO.choices.ForEach(c => db.Choice.Add(new Choice() { choice = c.choice, votes = c.votes, QuestionID = q.Id, question = q }));
            db.SaveChanges();

            //transform Question in QuestionDTO
            QuestionDTO qdto = new QuestionDTO { Id = q.Id, question = q.question, image_url = q.image_url, thumb_url = q.thumb_url, published_at = q.published_at, choices = new List<ChoiceDTO>() };
            q.choices.ForEach(c => qdto.choices.Add(new ChoiceDTO() { choice = c.choice, votes = c.votes }));

            return CreatedAtRoute("DefaultApi", new { id = qdto.Id }, qdto);
        }

        /// <summary>
        /// Update Question
        /// </summary>
        /// <param name="id">Question ID</param>
        /// <param name="questionDTO">JSON Object updated</param>
        /// <returns></returns>
        // PUT: api/Questions/5
        [ResponseType(typeof(QuestionDTO))]
        public IHttpActionResult PutQuestion(int id, QuestionDTO questionDTO)
        {
            // !!!!! - IMPORTANT LIMITATION - !!!!!
            // only works for the same number of Choices
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != questionDTO.Id)
            {
                return BadRequest();
            }

            //transform QuestionDTO in Question
            Question q = new Question() { Id = questionDTO.Id, question = questionDTO.question, image_url = questionDTO.image_url, thumb_url = questionDTO.thumb_url, published_at = questionDTO.published_at, choices = new List<Choice>() };
            questionDTO.choices.ForEach(c => q.choices.Add(new Choice() { choice = c.choice, votes = c.votes, QuestionID = q.Id, question = q }));

            //get current object from DB
            Question unchangeQuestion = db.Question.AsNoTracking().Where(x => x.Id == id).First();

            if (q.choices.Count== unchangeQuestion.choices.Count)
            {
                //the ChoiceID from DB to edited Object
                for (int i = 0; i < unchangeQuestion.choices.Count; i++)
                {
                    q.choices[i].ChoiceID = unchangeQuestion.choices[i].ChoiceID;
                }
            }
            else
                return BadRequest("Number of choices are diferent");

            //update question
            db.Entry(q).State = EntityState.Modified;
            //update choices
            q.choices.ForEach(c => db.Entry(c).State = EntityState.Modified);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //transform Question in QuestionDTO
            Question changeQuestion = db.Question.AsNoTracking().Where(x => x.Id == id).First();
            QuestionDTO qdto = new QuestionDTO { Id = changeQuestion.Id, question = changeQuestion.question, image_url = changeQuestion.image_url, thumb_url = changeQuestion.thumb_url, published_at = changeQuestion.published_at, choices = new List<ChoiceDTO>() };
            changeQuestion.choices.ForEach(c => qdto.choices.Add(new ChoiceDTO() { choice = c.choice, votes = c.votes }));

            return CreatedAtRoute("DefaultApi", new { id = qdto.Id }, qdto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionExists(int id)
        {
            return db.Question.Count(e => e.Id == id) > 0;
        }
        #region not used
        //// PUT: api/Questions/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutQuestion(int id, Question question)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != question.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(question).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuestionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Questions
        //[ResponseType(typeof(Question))]
        //public IHttpActionResult PostQuestion(Question question)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Questions.Add(question);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = question.Id }, question);
        //}

        //// DELETE: api/Questions/5
        //[ResponseType(typeof(Question))]
        //public IHttpActionResult DeleteQuestion(int id)
        //{
        //    Question question = db.Questions.Find(id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Questions.Remove(question);
        //    db.SaveChanges();

        //    return Ok(question);
        //}
        #endregion
    }
}