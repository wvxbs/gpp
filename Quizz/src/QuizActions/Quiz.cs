using System;
using System.Collections.Generic;
using gpp.src.qanda;

namespace gpp.src.quizactions
{
    class Quiz
    {   
        List<string> Questions; 
        List<string> Answers; 
        List<string> RightAnswers;  
        List<string> CorrectAnswers = new List<string>();     

        public Quiz (ProcessQuestions _Questions, ProcessAnswers _Answers, ProcessRightAnswer _RightAnswers)
        {
            Questions = _Questions.GetQuestions();
            Answers = _Answers.GetAnswers();
            RightAnswers = _RightAnswers.GetRightAnswers();
            
            RunQuiz();
        }

        private void RunQuiz ()
        {
            PrintQuestions();
        }

        private void PrintQuestions()
        {
            string [] QuestionArray = Questions.ToArray();
            string Input = "";

            for (int i = 0; i < QuestionArray.Length; i++)
            {
                Console.WriteLine(QuestionArray[i]);
                Console.WriteLine(PrintAnswers(i));
                Input = Console.ReadLine();
                GetUserInput(Input,i);
            }
        }

        private string PrintAnswers(int i)
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

        private string GetRightAnswerForEspecificQuestion(int i)
        {
            string [] RightAnswerArray = RightAnswers.ToArray();
            
            return RightAnswerArray[i];
        }

        private string BreakArrayPositionContentToMultipleLines (string Answer)
        {
            return String.Join("\n" ,Answer.Split(" "));
        }

        private string CleanCommasOfString(string Answer)
        {
            return String.Join(" ", Answer.Split(","));
        }

        private void GetUserInput(string Input, int i)
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
