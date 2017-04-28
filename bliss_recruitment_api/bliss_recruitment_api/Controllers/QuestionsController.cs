using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using bliss_recruitment_api.Models;
using bliss_recruitment_api.Models.DTO;
using bliss_recruitment_api.DAL;
using System;
using System.Net;

namespace bliss_recruitment_api.Controllers
{
    public class QuestionsController : ApiController
    {
        private ApiContext db = new ApiContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="limit">Number of records to retrieve</param>
        /// <param name="offset"></param>
        /// <param name="filter">Search on "question" and "choce"</param>
        /// <returns></returns>
        //public IList<QuestionDTO> GetQuestions(int limit, int offset, string filter = "")
        public IList<QuestionDTO> GetQuestions()
        {

            //get all questions from db as a List os Questions
            var ls = db.Question.ToList();
            List<QuestionDTO> list = new List<QuestionDTO>();
            foreach (Question x in ls)
            {
                QuestionDTO q = new QuestionDTO() { Id = x.Id, question = x.question, image_url = x.image_url, thumb_url = x.thumb_url, published_at = x.published_at, choices = new List<ChoiceDTO>() };
                x.choices.ForEach(c => q.choices.Add(new ChoiceDTO() { choice = c.choice, votes = c.votes }));
                list.Add(q);
            }
            return list;

        }

        // GET: api/Questions/5
        [ResponseType(typeof(QuestionDTO))]
        public IHttpActionResult GetQuestion(int id)
        {
            Question question = db.Question.Find(id);
            if (question == null)
                return NotFound();

            QuestionDTO qdto = new QuestionDTO { Id = question.Id, question = question.question, image_url = question.image_url, thumb_url = question.thumb_url, published_at = question.published_at, choices = new List<ChoiceDTO>() };
            question.choices.ForEach(c => qdto.choices.Add(new ChoiceDTO() { choice = c.choice, votes = c.votes }));

            return Ok(qdto);
        }
        // POST: api/Questions
        [ResponseType(typeof(Question))]
        public IHttpActionResult PostQuestion(QuestionDTO questionDTO)
        {
            throw new NotImplementedException();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //Question q = new Question() { question = questionDTO.question, image_url = questionDTO.image_url, thumb_url = questionDTO.thumb_url, published_at = DateTime.Now };
            //db.Question.Add(q);
            //db.SaveChanges();
            //int newID = db.Question.Last().Id;
            //questionDTO.choices.ForEach(c=> db.Choice.Add(new Choice() {choice= c.choice,votes= c.votes, QuestionID=newID, question=q }));
            ////q.Id=newID;
            //db.SaveChanges();


            //return CreatedAtRoute("DefaultApi", new { id = q.Id }, q);
        }

        // PUT: api/Questions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestion(int id, Question question)
        {
            throw new NotImplementedException();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //return StatusCode(HttpStatusCode.NoContent);
            //if (id != question.Id)
            //{
            //    return BadRequest();
            //}

            //db.Entry(question).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!QuestionExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
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