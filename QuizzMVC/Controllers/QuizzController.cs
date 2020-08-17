using gpp.src.qanda;
using gpp.src.quizactions;
using QuizzMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace QuizzMVC.Controllers
{
    public class QuizzController : Controller
    {
        static int QuestionIndex = 0;
        string UserInput = "";
        List<Question> QuestionsList = new List<Question>();

        static string QuestionsFilePath = @"C:\Users\GabrielFerreira\Documents\repos\gpp\ConsoleQuizz\Questions.txt";

        static RetrieveQandAFromFile RetrieveData = new RetrieveQandAFromFile(QuestionsFilePath);
        static List<string> RawFileData = RetrieveData.GetRawFileData();

        static ProcessQuestions Questions = new ProcessQuestions(RawFileData);
        static ProcessAnswers Answers = new ProcessAnswers(RawFileData);
        static ProcessRightAnswer RightAnswers = new ProcessRightAnswer(RawFileData);
        static Quiz Quiz = new Quiz(Questions, Answers, RightAnswers);


        public QuizzController()
        {
            //QuestionIndex = (int)Session["QuestionIndex"];
        }

        public ActionResult QuizzHome()
        {
            if (QuestionIndex < Questions.GetQuestions().Count)
            {
                Question qObj = new Question();

                qObj.Name = GetCurrentQuestionName();
                qObj.Answers = GetCurrentQuestionAnswers().ToList<string>();

                return View(qObj);
            }
            else
                return RedirectToAction("QuizzEnd");
        }

        [HttpPost]
        public ActionResult ProcessUserInput(FormCollection Input)
        {
            string UserInput = Input["Resposta"];

            IncrementState();

            return RedirectToAction("QuizzHome");
        }

        private void IncrementState()
        {
            QuestionIndex = QuestionIndex + 1;
        }

        public ActionResult QuizzEnd()
        {
            return View();
        }

        private string GetCurrentQuestionName()
        {
            return Quiz.Questions.ToArray()[QuestionIndex];
        }

        private string [] GetCurrentQuestionAnswers()
        {
            return Quiz.PrintAnswers(QuestionIndex).Split('\n');
        }

        public void UpdateQuizz()
        {
            Question qObj = new Question();

            qObj.Name = GetCurrentQuestionName();
            qObj.Answers = GetCurrentQuestionAnswers().ToList<string>();

            QuestionsList.Add(qObj);
        }
    }
}