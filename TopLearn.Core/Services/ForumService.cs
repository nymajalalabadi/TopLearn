using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs.Question;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Question;

namespace TopLearn.Core.Services
{
    public class ForumService : IForumService
    {
        private TopLearnContext _context;

        public ForumService(TopLearnContext context)
        {
            _context = context;
        }

        public void AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public int AddQuestion(Question question)
        {
            question.CreateDate = DateTime.Now;
            question.ModifiedDate = DateTime.Now;

            _context.Questions.Add(question);
            _context.SaveChanges();

            return question.QuestionId;
        }

        public void ChangeIsTrueAnswer(int questionId, int answerId)
        {
            var answer = _context.Answers.Where(a => a.AnswerId == answerId);

            foreach (var ans in answer)
            {
                ans.IsTrue = false;

                if(ans.AnswerId==answerId)
                {
                    ans.IsTrue = true;
                }                   
            }
            _context.UpdateRange(answer);
            _context.SaveChanges();
        }

        public IEnumerable<Question> GetQuestions(int? courseId, string filter = "")
        {
            IQueryable<Question> result = _context.Questions.Where(q => EF.Functions.Like(q.Title, $"%{filter}%"));

            if (courseId!=null)
            {
                result = result.Where(q => q.CourseId == courseId);
            }

            return result.Include(q=>q.User).Include(q => q.Course).ToList();
        }

        public ShowQuestionViewModel ShowQuestion(int questionId)
        {
            var question = new ShowQuestionViewModel();

            question.Question = _context.Questions.Include(u => u.User)
                .FirstOrDefault(q => q.QuestionId == questionId);

            question.Answers = _context.Answers.Where(a => a.QuestionId == questionId).Include(a=>a.User)
                .ToList();

            return question;
            
        }
    }
}
