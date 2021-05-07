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
        private DataAccessObject dataAccessObject;
        private InputManagement inputManagement;
        private LogManagement log;
        public NaverAPIAccessObject(OutputData outputData, DataAccessObject dataAccessObject, InputManagement inputManagement, LogManagement log)
        {
            this.outputData = outputData;
            this.dataAccessObject = dataAccessObject;
            this.inputManagement = inputManagement;
            this.log = log;
        }
        public void ShowNaverBookList(string query, bool isRegistration)
        {
            string stringLog;
            int index = 0;
            string discount = "1";
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

            JObject parseJson = JObject.Parse(text);
            //Console.WriteLine(text);

            outputData.ShowAllNaverBookList(parseJson);
           
            if (isRegistration)
            {
                discount = inputManagement.GetBookNO();
                if (discount == "b") return;
                index = Convert.ToInt32(discount);
                discount = inputManagement.GetBookNumber();
                if (discount == "b") return;
                dataAccessObject.InputBookDateInDataBase(Convert.ToString(parseJson["items"][index]["title"]),
                     Convert.ToString(parseJson["items"][index]["author"]),
                     Convert.ToString(parseJson["items"][index]["publisher"]), discount,
                     Convert.ToString(parseJson["items"][index]["price"]),
                     Convert.ToString(parseJson["items"][index]["pubdate"]),
                     Convert.ToString(parseJson["items"][index]["isbn"]),
                     Convert.ToString(parseJson["items"][index]["description"]));
                // 책 등록
                Console.WriteLine("책 등록 완료, ENTER를 눌러주세요.");
                stringLog = string.Format("관리자가 네이버도서 :{0} 등록하였습니다.", parseJson["items"][index]["title"]); log.AddLog(stringLog);
            }
            Console.ReadLine();
        }    
    }
}
