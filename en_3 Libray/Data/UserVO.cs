using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray.Data
{
    class UserVO
    {
        public string Id { get; set; } // 아이디
        public string PassWord { get; set; } // 비밀번호
        public string Name { get; set; } // 이름
        public string Age { get; set; } // 나이
        public string PhoneNumber { get; set; } // 전화번호

        public override string ToString()
        {
            return "이름: " + Name.PadRight(4, ' ') + "아이디: " + Id.PadRight(10, ' ') + "나이: " + Age.PadRight(3, ' ') + "전화번호: " + PhoneNumber;
        }
    }
}
