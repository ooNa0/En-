using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray.Data
{
    class UserVO
    {
        private string id;
        private string password;
        private string name;
        private string age;
        private string phoneNumber;

        
        public string Id // 아이디
        {
            get { return id; }
            set { id = value; }
        }
        public string PassWord // 비밀번호
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
        public override string ToString()
        {
            return "이름: " + Name + "아이디: " + Id + "나이: " + Age + "전화번호: " + PhoneNumber;
            //return "이름: " + Name.PadRight(4, ' ') + "아이디: " + Id.PadRight(10, ' ') + "나이: " + Age.PadRight(3, ' ') + "전화번호: " + PhoneNumber;
        }
    }
}

