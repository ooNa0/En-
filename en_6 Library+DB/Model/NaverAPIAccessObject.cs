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
        public NaverAPIAccessObject(OutputData outputData, DataAccessObject dataAccessObject, InputManagement inputManagement)
        {
            this.outputData = outputData;
            this.dataAccessObject = dataAccessObject;
            this.inputManagement = inputManagement;
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

            //outputData.ShowAllNaverBookList(text, isRegistration);
            JObject parseJson = JObject.Parse(text);
            Console.WriteLine(text);
            if (parseJson["items"].ToString() == "[]")
            {
                Console.WriteLine("검색한 도서가 존재하지 않습니다!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("네이버 도서 검색 결과 ");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");

            //Console.WriteLine(parseJson["display"]);
            int i = 0;
            foreach (JToken jToken in parseJson["items"])
            {
                Console.Write("NO :[{0}]  ", i);
                Console.WriteLine("도서 제목:{0}", jToken["title"]);

                Console.WriteLine("저자:{0}", jToken["author"]);

                Console.WriteLine("출판사:{0}", jToken["publisher"]);
                Console.WriteLine("출판일:{0}", jToken["pubdate"]);

                Console.WriteLine("가격:{0}원, ISBN:{1}", jToken["price"], jToken["isbn"]);
                //description = 
                Console.WriteLine("설명:{0}", jToken["description"]);
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                i++;
            }

            int index = 0;
            string discount = "1";
            if (isRegistration) // 따로 Controller의 bookmanagement에 빼고 싶다
            {
                Console.WriteLine(parseJson["items"][index]["author"]);
                index = inputManagement.GetBookNO(); // 이거도 controller
                discount = inputManagement.GetBookNumber();
                //Console.WriteLine("______________");
                dataAccessObject.InputBookDateInDataBase(Convert.ToString(parseJson["items"][index]["title"]),
                     Convert.ToString(parseJson["items"][index]["author"]),
                     Convert.ToString(parseJson["items"][index]["publisher"]), discount,
                     Convert.ToString(parseJson["items"][index]["price"]),
                     Convert.ToString(parseJson["items"][index]["pubdate"]),
                     Convert.ToString(parseJson["items"][index]["isbn"]),
                     Convert.ToString(parseJson["items"][index]["description"]));
                // 책 등록
            }
            Console.WriteLine("책 등록 완료, ENTER를 눌러주세요.");
            Console.ReadLine();
        }    
    }
}
