using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class Administrator
    {
        public void Remove(List<UserVO> userList, Print print)
        {
            Console.Clear();
            print.Library();
            print.ShowUserList(userList, print);
            Console.WriteLine("지울 회원의 이름을 입력해주세요.");

            string wantRemoveName = Console.ReadLine();
            int count = userList.Count - 1;
            int remove = 0;

            while (count >= 0)
            {
                if (wantRemoveName == userList[count].Name)
                {
                    remove++;
                }
                count--;
            }
            if (remove == 1)
            {
                userList.RemoveAt(count + 1);
                Console.WriteLine("회원 삭제 완료!");
            }
            else if (remove == 0)
            {
                Console.WriteLine("지울 회원이 존재하지 않거나, 잘못입력하셨습니다.");
                Console.WriteLine("아무 키나 입력해주세요..");
                Console.ReadLine();
                return;
            }
            else if(remove != 0)
            {
                Console.WriteLine("이름이 중복되는 회원이 있습니다.");
                Console.WriteLine("지우고자 하는 아이디를 입력해주세요.");
                string wantRemoveIdentity = Console.ReadLine();
                count = userList.Count - 1;
                remove = 0;
                while (count >= 0)
                {
                    if (wantRemoveIdentity == userList[count].Id && wantRemoveName == userList[count].Name)
                    {
                        remove++;
                        userList.RemoveAt(count);
                        Console.WriteLine("회원 삭제 완료!");
                    }
                    count--;
                }
            }
            if(remove == 0)
            {
                Console.WriteLine("지울 회원인 {0}의 입력하신 아이디가 존재하지 않거나, 잘못입력하셨습니다.", wantRemoveName);
            }
            Console.WriteLine("아무 키나 입력해주세요..");
            Console.ReadLine();
        }

        public void Search(List<UserVO> userList, Print print)
        {
            string howToSearch;
            int count = userList.Count - 1;
            int search = 0;

            Console.Clear(); print.Library();
            Console.WriteLine("찾으실 유저의 이름을 입력해주세요.");
            howToSearch = Console.ReadLine();
            while (count >= 0)
            {
                if (userList[count].Name.Contains(howToSearch))
                {
                    Console.WriteLine("{0}\n", userList[count].ToString());
                    search++;
                }
                count--;
            }
            if (search == 0)
            {
                Console.WriteLine("찾고자 하는 유저가 없습니다!");
            }
            Console.ReadLine();
        }
    }
}
