using System;
using System.Collections.Generic;
using gpp.src.qanda;

namespace gpp.src.quizactions
{
    public class Percentage
    {       
        public int CalculatePercentage(List<string> CorrectAnswers,int QuantityOfQuestions)
        {

            int Operation = (CorrectAnswers.Count * 100) / QuantityOfQuestions;

            return Operation;
        }
    }
}