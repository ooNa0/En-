using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace en_6_Library_DB
{
    class LogManagement
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\log.txt";
        public LogManagement()
        {
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }

        }

        public void DeleteLogFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("파일 삭제 완료");
                Console.ReadLine();
            }
        }

        public void AddLog(string input)
        {
            DateTime dateTime = DateTime.Now;
            string stringDate = dateTime.ToString("yyyy-MM-dd HH:mm");

            string inputLog = string.Format("[{0}] {1}", dateTime.ToString("yyyy-MM-dd HH:mm"), input);

            StreamWriter writer;
            writer = File.AppendText(path);
            writer.WriteLine(inputLog);
            writer.Close();
        }
    }
}
