using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class BookDataTransferObject // 계층간 데이터 교환
    {
        private string id; // 도서 번호
        private string bookName;      // 도서명
        private string author;    // 저자명
        private string publisher; // 출판사명
        private int quantity;  // 수량
        private int price;  // 가격
        /*
        public BookDataTransferObject(string bookName, string publisher, string author, int quantity)
        {
            this.BookName = bookName;
            this.Publisher = publisher;
            this.Author = author;
            this.Quantity = quantity;
        }*/
        public string GetBookID() // 도서 아이디
        {
            return id;
        }
        public string GetBookName() // 도서명
        {
            return bookName;
        }
        public string GetAuthor() // 저자명
        {
            return author;
        }
        public string GetPublisher() // 출판사명
        {
            return publisher;
        }
        public int GetQuantity() // 수량
        {
            return quantity;
        }
        public int GetPrice() // 가격
        {
            return price;
        }
        //public override string ToString(){return " - " + BookName + "(" + Author + "_" + Publisher + ") - " + Quantity;}
    }
}
