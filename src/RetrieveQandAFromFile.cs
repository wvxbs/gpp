using System;
using System.Collections.Generic;
using System.IO;

namespace gpp.src
{
    class RetrieveQandAFromFile
    {       
        string Path = @"";
        List<string> RawFileData = new List<string>();
        
        public RetrieveQandAFromFile (string _Path)
        {
            Path = _Path;
            ReadLines();
        }
        private void ReadLines()
        {
           RawFileData.AddRange(File.ReadAllLines(Path));
        } 

        public List<string> GetRawFileData()
        {
            return RawFileData;
        }
    }
}