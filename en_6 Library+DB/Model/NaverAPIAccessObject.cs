using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Xml;

namespace en_6_Library_DB
{
    class NaverAPIAccessObject
    {
        private OutputData outputData;
        public NaverAPIAccessObject(OutputData outputData)
        {
            this.outputData = outputData;
        }
        public void ShowNaverBookList(string query, bool isRegistration)
        {
            string url = "https://openapi.naver.com/v1/search/book.json?query=" + query + Constant.NAVER_API_DISPLAY + Constant.NAVER_API_DISPLAY_NUMBER; // 결과가 JSON 포맷
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // 한글을 URL에 추가하기 위해 UTF-8 형식으로 URL 인코딩
            request.Headers.Add("X-Naver-Client-Id", Constant.NAVER_API_CLIENT_ID); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", Constant.NAVER_API_CLIENT_SECRET);       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();

            text = text.Replace("<b>", "");
            text = text.Replace("</b>", "");
            text = text.Replace("&lt;", "<");
            text = text.Replace("\n", " ");
            text = text.Replace("&gt;", ">");
            text = text.Replace("&quot;", "");

            outputData.ShowAllNaverBookList(text, isRegistration);
        }    
    }
}
