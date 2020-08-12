using System;
using System.Collections.Generic;
using gpp.src.qanda;

namespace gpp.src.quizactions
{
    public class QuizResults
    {       
        int Percentage;
        int NumberOfCorrectAnswers;
        int NumberOfQuestions;
        public QuizResults(int _Percentage, int _NumberOfCorrectAnswers, int _NumberOfQuestions)
        {
            Percentage = _Percentage;
            NumberOfCorrectAnswers = _NumberOfCorrectAnswers;
            NumberOfQuestions = _NumberOfQuestions;
        }

        public int DisplayPercentageAsInt()
        {
            return Percentage;
        }

        public string DisplayPercentage()
        {
            return $"Porcentagem de acertos foi:{Percentage}%\n\n";
        }

        public string DisplayNumberOfErrors()
        {

            int Val = 0;
            int Operation = (NumberOfQuestions - NumberOfCorrectAnswers);

            if( Operation > 0)
                Val = Operation;

            return $"Quantidade de erros: {Val}";
        }

        public string DisplayNumberOfCorrectAnswers()
        {
            return $"Quantidade de acertos: {NumberOfCorrectAnswers}";   
        }

        public string DisplayNumberOfQuestions()
        {
            return $"\nQuantidade de questões: {NumberOfQuestions}";
        }
    }
}