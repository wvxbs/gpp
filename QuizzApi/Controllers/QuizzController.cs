using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using gpp.src.qanda;
using gpp.src.quizactions;
using QuizzApi.Models;

namespace QuizzApi.Controllers
{
    public class QuizzController : ApiController
    {
        static int QuestionIndex = 0;
        static List<QuestionObj> QuestionList = new List<QuestionObj>();

        string UserInput = "";
        static int NumberOfQuestions = 0;

        static Quiz Quiz;

        [Route("Quizz/StartQuizz")]
        [HttpGet]
        public string StartQuizz ()
        {
            string QuestionsFilePath = @"C:\Users\GabrielFerreira\Documents\repos\gpp\ConsoleQuizz\Questions.txt";

            RetrieveQandAFromFile RetrieveData = new RetrieveQandAFromFile(QuestionsFilePath);
            List<string> RawFileData = RetrieveData.GetRawFileData();

            ProcessQuestions Questions = new ProcessQuestions(RawFileData);
            ProcessAnswers Answers = new ProcessAnswers(RawFileData);
            ProcessRightAnswer RightAnswers = new ProcessRightAnswer(RawFileData);

            Quiz = new Quiz(Questions, Answers, RightAnswers);
            NumberOfQuestions = Questions.GetQuestions().Count();

            return "Quizz Iniciado";
        }

        [Route("Quizz/GetCurrentQuestion")]
        [HttpGet]
        public string GetCurrentQuestion()
        {
            return "Quizz Iniciado";
        }

        [Route("Quizz/SendAnswer")]
        [HttpPost]
        public string SendAnswer([FromBody] string Input)
        {
            if(QuestionIndex < NumberOfQuestions)
            {
                HandleUserInput(Input);
                CreateQuestionsList();
                IncrementState();
                return "Resposta Enviada";
            }
            else
            {
                return "Todas as perguntas foram respondidas";
            }
        }

        private void CreateQuestionsList()
        {
            string[] QuestionArray = Quiz.Questions.ToArray();
            string[] AnswersArray = Quiz.PrintAnswers(QuestionIndex).Split('\n');

            QuestionObj q = new QuestionObj();

            q.QuestionTitle = QuestionArray[QuestionIndex];
            q.Answers.AddRange(AnswersArray);
            q.UserInput = UserInput;

            QuestionList.Add(q);
        }

        private void IncrementState()
        {
            QuestionIndex = QuestionIndex + 1;
        }

        private void HandleUserInput(string Input)
        {
            UserInput = Input;
        }
    }
}