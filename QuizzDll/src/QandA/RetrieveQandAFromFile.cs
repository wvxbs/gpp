using System;
using System.Collections.Generic;
using System.IO;

namespace gpp.src.qanda
{
    public class RetrieveQandAFromFile
    {       
        string Path = @"";
        List<string> RawFileData = new List<string>();
        
        public RetrieveQandAFromFile (string _Path)
        {
            Path = _Path;
            ReadFileLines();
        }
        private void ReadFileLines()
        {
           RawFileData.AddRange(File.ReadAllLines(Path));
        } 

        public List<string> GetRawFileData()
        {
            return RawFileData;
        }
    }
}