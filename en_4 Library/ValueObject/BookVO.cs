using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class BookVO
    {
        private string id; // 도서 번호
        private string bookName;      // 도서명
        private string publisher; // 출판사명
        private string author;    // 저자명
        private int quantity;  // 수량

        public BookVO(string bookName, string publisher, string author, int quantity)
        {
            this.BookName = bookName;
            this.Publisher = publisher;
            this.Author = author;
            this.Quantity = quantity;
        }

        public string BookName // 도서명
        {
            get { return bookName; }
            set { bookName = value; }
        }
        public string Publisher // 출판사명
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public string Author // 저자명
        {
            get { return author; }
            set { author = value; }
        }
        public int Quantity // 수량
        {
            get { return quantity; }
            set { quantity = value; }
        }
        
        public override string ToString()
        {
            return " - " + BookName + "(" + Author + "_" + Publisher + ") - " + Quantity;
        }
    }
}
