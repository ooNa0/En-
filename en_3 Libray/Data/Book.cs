using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray
{
    class Book
    {
        private string id;        // 도서 번호
        private string bookName;      // 도서명
        private string publisher; // 출판사명
        private string author;    // 저자명
        private string quantity;  // 수량

        public Book(string id, string bookName, string publisher, string author, string quantity)
        {
            this.id = id;
            this.bookName = bookName;
            this.publisher = publisher;
            this.quantity = quantity;
        }

        public Book(string id, string bookName, string publisher) 
            // 생성자 - 부모 클래스가 자식 클래스의 기반, 코드의 재활용
            // 상속 - 초기화 값 많고, 생설자가 필요할 경우
            //:this(id, bookName, publisher, "작가 미상")
        { 

        }

        // VO get/set method, ToString()
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public override string ToString()
        {
            return "Book id: " + id + ", Name: " + BookName + ", Author: " + author;//base.ToString();
        }
    }
}
