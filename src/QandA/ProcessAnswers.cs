using System;
using System.Collections.Generic;
using System.IO;

namespace gpp.src.qanda
{
    public class ProcessAnswers
    {       
        List<string> AnswerList = new List<string>();
        
        public ProcessAnswers (List<string> _FileData)
        {
            SeparateAnswersFromFileData(_FileData.ToArray());
        }

        private void SeparateAnswersFromFileData(string [] FileData)
        {   
            int NextAnswerIndex = 1;
            string TemporaryString = "";

            for(int i = 0; i < FileData.Length; i++)
            {
                if(NextAnswerIndex == i)
                {
                    TemporaryString = TemporaryString + $" {FileData[i]}";

                    var TemporaryStringArray = TemporaryString.Split(" ");

                    if(TemporaryStringArray.Length < 6)
                    {
                        NextAnswerIndex = 1 + NextAnswerIndex;
                    }
                    else
                    {
                        NextAnswerIndex = 4 + NextAnswerIndex;
                        AnswerList.Add(TemporaryString);
                        TemporaryString = "";
                    }
                }
            }
        }

        public List<string> GetAnswers()
        {
            return AnswerList;
        }
    }
}