using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class UserVO
    {
        private string id;
        private string password;
        private string name;
        private string age;
        private string phoneNumber;
        private int borrowBookNumber = 0;
        private string borrowBook ="";
        private string borrowDate; // 대출일
        private string returnDate; // 반납일

        public UserVO(string id, string password, string name, string age, string phoneNumber)
        {
            this.Id = id;
            this.Password = password;
            this.Name = name;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
        }

        public string Id // 아이디
        {
            get { return id; }
            set { id = value; }
        }
        public string Password // 비밀번호
        {
            get { return password; }
            set { password = value; }
        }
        public string Name // 이름
        {
            get { return name; }
            set { name = value; }
        }
        public string Age // 나이
        {
            get { return age; }
            set { age = value; }
        }
        public string PhoneNumber // 전화번호
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string BorrowDate
        {
            get { return borrowDate; }
            set { borrowDate = value; }
        }
        public string RorrowDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }
        public string BorrowBook
        {
            get { return borrowBook; }
            set { borrowBook = value; }

        }
        public int BorrowBookNumber
        {
            get { return borrowBookNumber; }
            set { borrowBookNumber = value; }
        }
        public override string ToString()
        {
            return " - " + Name.PadRight(10, ' ') + Id.PadRight(21, ' ') + Age.PadRight(15, ' ') + PhoneNumber;
        }
    }
}
