using System;
using System.Collections.Generic;
using System.IO;

namespace gpp.src.qanda
{
    public class ProcessRightAnswer
    {       
        List<string> RightAnswerList = new List<string>();
        
        public ProcessRightAnswer (List<string> _FileData)
        {
            SeparateRightAnswerFromFileData(_FileData.ToArray());
        }

        private void SeparateRightAnswerFromFileData(string [] FileData)
        {   
            int NextAnswerIndex = 6;

            for(int i = 0; i < FileData.Length; i++)
            {
                if(NextAnswerIndex == i)
                {
                    RightAnswerList.Add(FileData[i]);
                    NextAnswerIndex = 8 + NextAnswerIndex;
                }
            }
        }

        public List<string> GetRightAnswers()
        {
            return RightAnswerList;
        }
    }
}