package Controller;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;

import Model.*;
import View.InputManagement;
import View.ShowResult;

public class CommandProgram {
	private ApplyCommand command;
	private InputManagement input;
	private ShowResult result;
	private dataManagement dataManagement = new dataManagement();
	private String currentPath;

	public CommandProgram() {
		command = new ApplyCommand();
		input = new InputManagement();
		result = new ShowResult();
		currentPath = System.getProperty("user.home"); //getCanonicalPath()
		File p = new File("C:\\Users\\..\\BFF");
		try {
			System.out.println(p.getCanonicalPath());
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		// showDirectory();
		// clearScreen();
		runProgram();

	}

	private void runProgram() {
		//List<String> inputlist = new ArrayList<String>();
		List<String> inputlist = dataManagement.splitString(input.startCommand(command.getVersion(), currentPath));
		//String firstsplittedString[] = dataManagement.splitString(input.startCommand(command.getVersion()));
		while (true) {
			if (inputlist.isEmpty()) { }
			else {
				switch (inputlist.get(0)) {
				//case "cd":					
				//	break;
				case "dir":
					System.out.println(command.getVolume());
					result.showDirectory();
					break;
				case "cls":
					result.clearScreen();
					break;
				case "help":
					result.helpCommand();
					break;
				case "copy": // 깊은 복사
					command.copy(inputlist.get(1), inputlist.get(2));
					break;
				case "move":
					command.copy(inputlist.get(1), inputlist.get(2));
					command.delete(inputlist.get(1));
					break;
				case "tree":
					break;
				default:
					//System.out.println(inputlist.get(0).length());
					if(inputlist.get(0).substring(0, 2).equals("cd")) {
						if(inputlist.get(0).length() == 2) { // cd에 띄어쓰기
							if(inputlist.get(1).isEmpty()) { // cd만 입력
								System.out.println(currentPath); // 현재 경로 출력
							}
							else { // cd [값] 이런 식
								String targetPath;
								if(inputlist.get(1).contains(":")) {
									targetPath = inputlist.get(1);
								}
								else {
									targetPath = currentPath + "\\" +inputlist.get(1);
								}
								File targetFile = new File(targetPath);
								if(targetFile.exists()) { // 파일이나 디렉토리 존재
									if(targetFile.isFile()) {
										System.out.println("디렉터리 이름이 올바르지 않습니다.");
									}
									else {
										currentPath = targetPath;
									}
								}
							}//C:\Users\구나영\Desktop
						}
						else { // cd에 띄어쓰기 안함
							if(inputlist.get(0).length() == 3) {// cd. 이런식
								if(inputlist.get(0).substring(2, 3).equals(".")) {
									break;
								}
								if(inputlist.get(0).substring(2, 3).equals("/") || inputlist.get(0).substring(2, 3).equals("\\")) {
									currentPath = System.getenv("SystemDrive") + "\\";
								}
								if(inputlist.get(0).substring(2, 3).equals(",") || inputlist.get(0).substring(2, 3).equals(";") || inputlist.get(0).substring(2, 3).equals("=")
										|| inputlist.get(0).substring(2, 3).equals("&")) {
									System.out.println(currentPath);
								}
								if(inputlist.get(0).substring(2, 3).equals(":")) {
									System.out.println("파일 이름, 디렉터리 이름 또는 볼륨 레이블 구문이 잘못되었습니다.");
								}
								if(inputlist.get(0).substring(2, 3).equals("?") || inputlist.get(0).substring(2, 3).equals(";") || inputlist.get(0).substring(2, 3).equals("'")
										|| inputlist.get(0).substring(2, 3).equals("\"") || inputlist.get(0).substring(2, 3).equals("-") || inputlist.get(0).substring(2, 3).equals("_")
										|| inputlist.get(0).substring(2, 3).equals(")") || inputlist.get(0).substring(2, 3).equals("*")
										|| inputlist.get(0).substring(2, 3).equals("%")|| inputlist.get(0).substring(2, 3).equals("$")
										|| inputlist.get(0).substring(2, 3).equals("#")|| inputlist.get(0).substring(2, 3).equals("@")
										|| inputlist.get(0).substring(2, 3).equals("!")|| inputlist.get(0).substring(2, 3).equals("~")
										|| inputlist.get(0).substring(2, 3).equals("`")) {
									// 'cd?'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는 배치 파일이 아닙니다.
								}
								if(inputlist.get(0).substring(2, 3).equals("|")) {
									System.out.println("명령 구문이 올바르지 않습니다.");
								}
								if(inputlist.get(0).substring(2, 3).equals("+") || inputlist.get(0).substring(2, 3).equals("(")) {
									System.out.println("지정된 경로를 찾을 수 없습니다.");
								}
								if(inputlist.get(0).substring(2, 3).equals("^")) {
									System.out.print("More?");
									String inputString = new Scanner(System.in).nextLine();
									//'cd+more뒤에 입력한 값'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는 배치 파일이 아닙니다.
								}
							}
							else {
								
							}
						}
						System.out.println(inputlist.get(0).length());
						System.out.println(inputlist.get(0).substring(0, 2));
					}
					break;
				}
				inputlist = dataManagement.splitString(input.inputCommand(currentPath));
				//String splittedString[] = dataManagement.splitString(input.startCommand(command.getVersion()));
			}
			// splittedString[] = (input.inputCommand()).split(" ");
		}

		// System.out.println(System.getProperty("file.separator"));
	}


}
