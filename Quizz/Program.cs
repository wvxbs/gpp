using System;
using System.Collections.Generic;
using gpp.src;
using gpp.src.qanda;
using gpp.src.quizactions;

namespace gpp
{
    class Program
    {   

        static void Main(string[] args)
        {
            LoadFilePathFromConfigurationFile ConfigurationFileData = new LoadFilePathFromConfigurationFile();
            string QuestionsFilePath = ConfigurationFileData.GetFilePath();

            RetrieveQandAFromFile RetrieveData = new RetrieveQandAFromFile(QuestionsFilePath);
            List<string> RawFileData = RetrieveData.GetRawFileData();

            ProcessQuestions Questions = new ProcessQuestions(RawFileData);
            ProcessAnswers Answers = new ProcessAnswers(RawFileData);
            ProcessRightAnswer RightAnswers = new ProcessRightAnswer(RawFileData);

            while (true)
            {
                int NumberOfQuestions = Questions.GetQuestions().Count;

                Quiz Quiz = new Quiz(Questions, Answers, RightAnswers);
                var CorrectAnswers = Quiz.GetCorrectAnswers();

                Percentage Percentage = new Percentage();
                int _Percentage = Percentage.CalculatePercentage(CorrectAnswers, NumberOfQuestions);

                QuizResults QuizResults = new QuizResults(_Percentage, CorrectAnswers.Count, NumberOfQuestions);
                
                Console.WriteLine(QuizResults.DisplayNumberOfQuestions());
                Console.WriteLine(QuizResults.DisplayNumberOfCorrectAnswers());
                Console.WriteLine(QuizResults.DisplayNumberOfErrors());
                Console.WriteLine(QuizResults.DisplayPercentage());
                Console.ReadLine();
            }
        }
    }
}