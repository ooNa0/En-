using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace en_3_Libray
{
    class BookVO
    {
        private bool isBorrowed; // 대출중?
        private string userId; // 대출중이면 누가
        private DateTime borrowDate; // 대출일
        private DateTime returnDate; // 반납일

        // VO get/set method, ToString()
        public string Id { get; set; } // 도서 번호
        public string BookName { get; set; } // 도서명
        public string Publisher { get; set; } // 출판사명
        public string Author { get; set; } // 저자명
        public string Quantity { get; set; } // 수량
        public override string ToString()
        {
            return "Book id: " + Id + ", Name: " + BookName + ", Author: " + Author;//base.ToString();
        }

        public BookVO(string id, string bookName, string publisher, string author, string quantity)
        {
            this.Id = id;
            this.BookName = bookName;
            this.Publisher = publisher;
            this.Author = author; 
            this.Quantity = quantity;
        }

        public BookVO(string id, string bookName, string publisher)
        // 생성자 - 부모 클래스가 자식 클래스의 기반, 코드의 재활용
        // 상속 - 초기화 값 많고, 생설자가 필요할 경우
        //:this(id, bookName, publisher, "작가 미상")
        {

        }
    }
}
