using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace QuizzMVC.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new List<string>();
        }

        public string Name{ get; set; }
        public List<string> Answers { get; set; }
    }
}