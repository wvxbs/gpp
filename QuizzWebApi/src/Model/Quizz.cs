using System;
using System.Collections.Generic;

namespace QuizzWebApi.src.Model
{
    public class Quizz
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public string RightAnswer { get; set; }
    }
}