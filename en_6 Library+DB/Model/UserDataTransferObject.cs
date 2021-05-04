using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class UserDataTransferObject // 계층간 데이터 교환
    {
        private string id;
        private string password;
        private string name;
        private string age;
        private string phoneNumber;
        private int borrowBookNumber;
        //private string borrowBook = "";
        //private string borrowDate; // 대출일
        //private string returnDate; // 반납일
        /*
        public UserDataTransferObject(string id, string password, string name, string age, string phoneNumber, int borrowBookNumber)
        {
            this.Id = id;
            this.Password = password;
            this.Name = name;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
            this.borrowBookNumber = BorrowBookNumber;
        }*/

        public string GetId() // 아이디
        {
            return id;
        }
        public string GetPassword() // 비밀번호
        {
            return password;
        }
        public string GetName() // 이름
        {
            return name;
        }
        public string GetAge() // 나이
        {
            return age;
        }
        public string GetPhoneNumber() // 전화번호
        {
            return phoneNumber;
        }
        public int BorrowBookNumber()
        {
            return borrowBookNumber;
        }
        //public override string ToString(){return " - " + Name.PadRight(10, ' ') + Id.PadRight(21, ' ') + Age.PadRight(15, ' ') + PhoneNumber;}
    }
    //public void InputUserDataBase(string identity, string password, string name, string birthYear, string phoneNumber, string address)


}
