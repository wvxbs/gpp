using System;
using System.Collections.Generic;
using gpp.src.qanda;
using gpp.src.quizactions;

namespace ConsoleQuizz
{
    class Program
    {
        static string QuestionsFilePath = @"C:\Users\GabrielFerreira\Documents\repos\gpp\ConsoleQuizz\Questions.txt";

        static RetrieveQandAFromFile RetrieveData = new RetrieveQandAFromFile(QuestionsFilePath);
        static List<string> RawFileData = RetrieveData.GetRawFileData();

        static ProcessQuestions Questions = new ProcessQuestions(RawFileData);
        static ProcessAnswers Answers = new ProcessAnswers(RawFileData);
        static ProcessRightAnswer RightAnswers = new ProcessRightAnswer(RawFileData);
        static Quiz Quiz = new Quiz(Questions, Answers, RightAnswers);

        static void Main(string[] args)
        {
            while (true)
            {
                int NumberOfQuestions = Questions.GetQuestions().Count;
                var CorrectAnswers = Quiz.GetCorrectAnswers();

                PrintQuiz();

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

        static void PrintQuiz()
        {
            string[] QuestionArray = Quiz.Questions.ToArray();
            string Input = "";

            for (int i = 0; i < QuestionArray.Length; i++)
            {
                Console.WriteLine(QuestionArray[i]);
                Console.WriteLine(Quiz.PrintAnswers(i));
                Input = Console.ReadLine();
                Quiz.GetUserInput(Input, i);
            }
        }
    }
}