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
        private string birthYear;
        private string phoneNumber;
        private string address;
        private int borrowBookNumber;
        //private string borrowBook = "";
        //private string borrowDate; // 대출일
        //private string returnDate; // 반납일
        
        public UserDataTransferObject(string id, string password, string name, string birthYear, string phoneNumber, string address)//borrowBookNumber
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.birthYear = birthYear;
            this.phoneNumber = phoneNumber;
            this.address = address;
            //this.borrowBookNumber = BorrowBookNumber;
        }

        public string GetId() // 아이디
        {
            return this.id;
        }
        public string GetPassword() // 비밀번호
        {
            return this.password;
        }
        public string GetName() // 이름
        {
            return this.name;
        }
        public string GetBirthYear() // 나이
        {
            return this.birthYear;
        }
        public string GetPhoneNumber() // 전화번호
        {
            return this.phoneNumber;
        }
        public string GetAddress()
        {
            return this.address;
        }
        public int GetBorrowBookNumber()
        {
            return this.borrowBookNumber;
        }

        public void SetId(string id)
        {
            this.id = id;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetBirthYear(string birthYear)
        {
            this.birthYear = birthYear;
        }
        public void SetAddress(string address)
        {
            this.address = address;
        }
        public void SetPhoneNumber(string phoneNumber) // 전화번호
        {
            this.phoneNumber = phoneNumber;
        }
        //public override string ToString(){return " - " + Name.PadRight(10, ' ') + Id.PadRight(21, ' ') + Age.PadRight(15, ' ') + PhoneNumber;}
    }
    //public void InputUserDataBase(string identity, string password, string name, string birthYear, string phoneNumber, string address)


}
