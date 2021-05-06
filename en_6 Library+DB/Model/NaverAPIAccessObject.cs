using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace en_6_Library_DB
{
    class NaverAPIAccessObject
    {
        //https://openapi.naver.com/v1/search/book.json
        public void ShowNaverBookList(string query)
        {
            string url = "https://openapi.naver.com/v1/search/blog?query=" + query; // 결과가 JSON 포맷
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "YOUR-CLIENT-ID"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "YOUR-CLIENT-SECRET");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
        }
    
    }
}
