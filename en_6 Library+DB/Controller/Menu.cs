using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace en_6_Library_DB
{
    class Menu
    {
        private OutputMenu outputMenu;
        private OutputData outputData;
        private InputManagement inputManagement;
        private UserDataManagement userSignUpDataManagement;//TransferObject
        private Exception exception;
        private OutputError outputError;
        private UserManagement userManagement;
        private AdministratorManagement administratorManagement;
        private MySqlConnection connection;
        private DataAccessObject dataAccessObject;// = new DateAccessObject();
        private bookManagement bookManagement;

        public Menu()
        {
            exception = new Exception();
            outputMenu = new OutputMenu();
            outputError = new OutputError();
            outputData = new OutputData(outputMenu);
            dataAccessObject = new DataAccessObject();
            connection = new MySqlConnection(Constant.DATABASE_CONNECTION_INFOMATION);//Server=localhost;port=3306; Database=; Uid=root; Pwd=0000; Charset=utf8            userSignUpDataManagement = new UserDataManagement();
            inputManagement = new InputManagement(exception, outputError);
            bookManagement = new bookManagement(outputMenu, outputData, inputManagement, dataAccessObject);
            userManagement = new UserManagement(exception, inputManagement, userSignUpDataManagement, outputMenu, dataAccessObject, outputError, outputData, bookManagement);
            administratorManagement = new AdministratorManagement(exception, inputManagement, outputMenu, outputData, dataAccessObject, outputError, bookManagement, userManagement);
        }

        public void MainMenu() // 첫 메뉴
        {
            string adminPassword;
            bool hasEnded = false;
            while (!hasEnded) {
                outputMenu.ShowFirstMenu();
                switch (inputManagement.GetMenuNumber(Constant.MAXIMUN_FIRST_MENU_NUMBER))
                {
                    case Constant.EXIT:
                        Console.WriteLine("이용해주셔서 감사합니다.");
                        //hasEnded = true;
                        return;
                    case Constant.SIGN_IN:
                        if (userManagement.SignInUser()) { userManagement.ManageUserMenu(); }
                        break;
                    case Constant.SIGN_UP:
                        userManagement.SignUpUser();
                        break;
                    case Constant.ADMINISTRATOR_MODE:
                        Console.Write("관리자 비밀번호를 입력해주세요 :");
                        adminPassword = Console.ReadLine();
                        if (adminPassword == Constant.ADMINISTRATOR_PASSWORD) { administratorManagement.AdministratorMenu(); }
                        else { outputError.ShowAdministratorLoginFailure(); }
                        break;
                }
            }
        }
    }
}
