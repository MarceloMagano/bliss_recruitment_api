namespace bliss_recruitment_api.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<bliss_recruitment_api.DAL.ApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bliss_recruitment_api.DAL.ApiContext context)
        {
            var questions = new List<Question>()
            {
                new Question() {  question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now },
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now },
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now},
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now},
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now},
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now},
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now},
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now},
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now},
                new Question() { question = "Favourite programming language?",
                    image_url = "https://dummyimage.com/600x400/000/fff.png",
                    thumb_url = "https://dummyimage.com/120x120/000/fff.png", published_at = DateTime.Now},
            };
            questions.ForEach(q => context.Question.AddOrUpdate(a => a.question, q));
            context.SaveChanges();
            var choices = new List<Choice>()
            {
                new Choice() {ChoiceID=1, choice = "Swift", votes = 2048, QuestionID=questions[0].Id },
                new Choice() {ChoiceID=2, choice = "Python", votes = 1024,QuestionID=questions[0].Id },
                new Choice() {ChoiceID=3, choice = "Objective-C", votes = 512,QuestionID=questions[0].Id },
                new Choice() {ChoiceID=4, choice = "Ruby", votes = 256,QuestionID=questions[0].Id },
                new Choice() {ChoiceID=5, choice = "Swift_2", votes = 2048,QuestionID=questions[1].Id },
                new Choice() {ChoiceID=6, choice = "Python_2", votes = 1024,QuestionID=questions[1].Id },
                new Choice() {ChoiceID=7, choice = "Objective-C_2", votes = 512,QuestionID=questions[1].Id },
                new Choice() {ChoiceID=8, choice = "Ruby_2", votes = 256,QuestionID=questions[1].Id },
                new Choice() {ChoiceID=9, choice = "Swift_3", votes = 2048,QuestionID=questions[2].Id },
                new Choice() {ChoiceID=10, choice = "Python_3", votes = 1024,QuestionID=questions[2].Id },
                new Choice() {ChoiceID=11, choice = "Objective-C_3", votes = 512,QuestionID=questions[2].Id },
                new Choice() {ChoiceID=12, choice = "Ruby_3", votes = 256,QuestionID=questions[2].Id },
                new Choice() {ChoiceID=13,choice = "Swift_4", votes = 2048 ,QuestionID=questions[3].Id},
                new Choice() {ChoiceID=14,choice = "Python_4", votes = 1024 ,QuestionID=questions[3].Id},
                new Choice() {ChoiceID=15,choice = "Objective-C_4", votes = 512 ,QuestionID=questions[3].Id},
                new Choice() {ChoiceID=16,choice = "Ruby_4", votes = 256 ,QuestionID=questions[3].Id},
                new Choice() {ChoiceID=17,choice = "Swift_5", votes = 2048 ,QuestionID=questions[4].Id},
                new Choice() {ChoiceID=18,choice = "Python_5", votes = 1024 ,QuestionID=questions[4].Id},
                new Choice() {ChoiceID=19,choice = "Objective-C_5", votes = 512,QuestionID=questions[4].Id},
                new Choice() {ChoiceID=20,choice = "Ruby_5", votes = 256 ,QuestionID=questions[4].Id},
                new Choice() {ChoiceID=21,choice = "Swift_6", votes = 2048 ,QuestionID=questions[5].Id},
                new Choice() {ChoiceID=22,choice = "Python_6", votes = 1024 ,QuestionID=questions[5].Id},
                new Choice() {ChoiceID=23,choice = "Objective-C_6", votes = 512 ,QuestionID=questions[5].Id},
                new Choice() {ChoiceID=24,choice = "Ruby_6", votes = 256 ,QuestionID=questions[5].Id},
                new Choice() {ChoiceID=25,choice = "Swift_7", votes = 2048 ,QuestionID=questions[6].Id},
                new Choice() {ChoiceID=26,choice = "Python_7", votes = 1024,QuestionID=questions[6].Id },
                new Choice() {ChoiceID=27,choice = "Objective-C_7", votes = 512 ,QuestionID=questions[6].Id},
                new Choice() {ChoiceID=28,choice = "Ruby_7", votes = 256 ,QuestionID=questions[6].Id},
                new Choice() {ChoiceID=29,choice = "Swift_8", votes = 2048 ,QuestionID=questions[7].Id},
                new Choice() {ChoiceID=30,choice = "Python_8", votes = 1024 ,QuestionID=questions[7].Id},
                new Choice() {ChoiceID=31,choice = "Objective-C_8", votes = 512 ,QuestionID=questions[7].Id},
                new Choice() {ChoiceID=32,choice = "Ruby_8", votes = 256,QuestionID=questions[7].Id},
                new Choice() {ChoiceID=33,choice = "Swift_9", votes = 2048 ,QuestionID=questions[8].Id},
                new Choice() {ChoiceID=34,choice = "Python_9", votes = 1024 ,QuestionID=questions[8].Id},
                new Choice() {ChoiceID=35,choice = "Objective-C_9", votes = 512 ,QuestionID=questions[8].Id},
                new Choice() {ChoiceID=36,choice = "Ruby_9", votes = 256 ,QuestionID=questions[8].Id},
                new Choice() {ChoiceID=37,choice = "Swift_10", votes = 2048 ,QuestionID=questions[9].Id},
                new Choice() {ChoiceID=38,choice = "Python_10", votes = 1024 ,QuestionID=questions[9].Id},
                new Choice() {ChoiceID=39,choice = "Objective-C_10", votes = 512 ,QuestionID=questions[9].Id},
                new Choice() {ChoiceID=40,choice = "Ruby_10", votes = 256,QuestionID=questions[9].Id}
            };
            choices.ForEach(c => context.Choice.AddOrUpdate(a => a.choice, c));

            context.SaveChanges();

        }
    }
}
