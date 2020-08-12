using gpp.src.qanda;
using gpp.src.quizactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzForms.src
{
    class RunQuizz
    {

        public static string QuestionsFilePath = @"C:\Users\GabrielFerreira\Documents\repos\gpp\ConsoleQuizz\Questions.txt";

        public static RetrieveQandAFromFile RetrieveData = new RetrieveQandAFromFile(QuestionsFilePath);
        public static List<string> RawFileData = RetrieveData.GetRawFileData();

        public static ProcessQuestions Questions = new ProcessQuestions(RawFileData);
        public static ProcessAnswers Answers = new ProcessAnswers(RawFileData);
        public static ProcessRightAnswer RightAnswers = new ProcessRightAnswer(RawFileData);
        public static Quiz Quiz = new Quiz(Questions, Answers, RightAnswers);


    }
}
