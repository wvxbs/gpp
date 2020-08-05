using System;
using System.Collections.Generic;
using System.IO;

namespace gpp.src.qanda
{
    public class ProcessQuestions
    {       
        List<string> QuestionList = new List<string>();
        
        public ProcessQuestions (List<string> _FileData)
        {
            SeparateQuestionsFromFileData(_FileData.ToArray());
        }

        private void SeparateQuestionsFromFileData(string [] FileData)
        {   
            int NextAnswerIndex = 0;

            for(int i = 0; i < FileData.Length; i++)
            {
                if(NextAnswerIndex == i)
                {
                    QuestionList.Add(FileData[i]);
                    NextAnswerIndex = 8 + NextAnswerIndex;
                }
            }
        }

        public List<string> GetQuestions()
        {
            return QuestionList;
        }
    }
}