using System;
using System.Configuration;

namespace gpp.src
{
    public class LoadFilePathFromConfigurationFile
    {
        public string GetFilePath()
        {
              try
             {                 
                 return ConfigurationManager.AppSettings["FilePath"];
             }
             catch
             {
              throw;
             }
        }
}}