using System;
using gpp.src;
using gpp.src.qanda;

namespace gpp
{
    class Program
    {
        static void Main(string[] args)
        {
            var RetrieveData = new RetrieveQandAFromFile("questions.txt");
            var RawFileData = RetrieveData.GetRawFileData();

            var Questions = new ProcessQuestions(RawFileData);
            var Answers = new ProcessAnswers(RawFileData);
            var RightAnswers = new ProcessRightAnswer(RawFileData);

            Console.WriteLine(String.Join("\n", Questions.GetQuestions()));
            Console.WriteLine(String.Join("\n", Answers.GetAnswers()));
            Console.WriteLine(String.Join("\n", RightAnswers.GetRightAnswers()));
        }
    }
}