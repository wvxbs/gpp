using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizzApi.Models
{
    public class QuestionObj
    {
        public QuestionObj()
        {
            Answers = new List<string>();
        }

        public string QuestionTitle { get; set; }
        public List<string> Answers { get; set; }
        public string UserInput { get; set; }
    }
}   