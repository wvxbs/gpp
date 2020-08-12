using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using gpp.src.qanda;

namespace gpp.src.quizactions
{
    public class Quiz
    {   
        public List<string> Questions; 
        List<string> Answers; 
        List<string> RightAnswers;  
        List<string> CorrectAnswers = new List<string>();
        string LinesToBePrint = "";

        public Quiz (ProcessQuestions _Questions, ProcessAnswers _Answers, ProcessRightAnswer _RightAnswers)
        {
            Questions = _Questions.GetQuestions();
            Answers = _Answers.GetAnswers();
            RightAnswers = _RightAnswers.GetRightAnswers();
        }

        public string PrintAnswers(int i)
        {
            string [] AnswerArray = Answers.ToArray();

            if(BreakArrayPositionContentToMultipleLines(AnswerArray[i]).Contains(","))
            {
                return CleanCommasOfString(BreakArrayPositionContentToMultipleLines(AnswerArray[i]));
            }
            else
            {
                return BreakArrayPositionContentToMultipleLines(AnswerArray[i]);
            }
        }

        public List<string> GetAnswerList()
        {
            return Answers;
        }

        private string GetRightAnswerForEspecificQuestion(int i)
        {
            string [] RightAnswerArray = RightAnswers.ToArray();
            
            return RightAnswerArray[i];
        }

        private string BreakArrayPositionContentToMultipleLines (string Answer)
        {
            return String.Join("\n" ,Answer.Split(' '));
        }

        private string CleanCommasOfString(string Answer)
        {
            return String.Join(" ", Answer.Split(','));
        }

        public void GetUserInput(string Input, int i)
        {
            if(Input.Length == 1)
            {
                if(Input == GetRightAnswerForEspecificQuestion(i))
                {
                    CorrectAnswers.Add(Input);
                }
            }
        }

        public List<string> GetCorrectAnswers ()
        {
            return CorrectAnswers;
        }
    }
}