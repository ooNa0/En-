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
import java.util.stream.Collectors;

import Model.*;
import View.InputManagement;
import View.ShowResult;

public class CommandProgram {
	private ApplyCommand command;
	private InputManagement input;
	private ShowResult result;
	private Exception exception = new Exception();
	private dataManagement dataManagement = new dataManagement();
	private String currentPath;

	public CommandProgram() {
		command = new ApplyCommand();
		input = new InputManagement();
		result = new ShowResult();
		currentPath = Constant.START_POSITION_VALUE;
		//System.out.println(p.getCanonicalPath());
		
		/*
		String pd = "C:\\Users";
		File p = new File("C:\\Users");
		System.out.println(pd.lastIndexOf("\\"));
		try {
			System.out.println(p.getCanonicalPath());
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}*/
		//result.showDirectory();
		// clearScreen();
		runProgram();

	}

	private void runProgram() {
		//List<String> inputlist = new ArrayList<String>();
		String inputString = input.startCommand(command.getVersion(), currentPath);
		List<String> inputlist = dataManagement.splitString(inputString);
		//String firstsplittedString[] = dataManagement.splitString(input.startCommand(command.getVersion()));
		while (true) {
			if (inputlist.isEmpty()) { }
			else {
				switch (inputlist.get(0)) {
				//case "cd":					
				//	break;
				case "dir":
					System.out.println(command.getVolume());
					result.showDirectory(currentPath);
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
					if(inputlist.get(0).substring(0, 2).equals("cd")) {
						
						if(inputlist.size() == 1) {
							
						}
						else { // 띄어쓰기가 무조건 있거
							
						}
						if(inputlist.get(0).length() == 2) { // cd에 띄어쓰기
							if(inputlist.size() == 1) { // cd만 입력
								System.out.println(result.showCurrentPath(currentPath)); // 현재 경로 출력
							}
							else { // cd [값] 이런 식
								String targetPath = null;
								System.out.println(inputlist.get(1));
								System.out.println(Constant.TOP_LEVEL_PATH);
								System.out.println(inputlist.get(1).contains(Constant.TOP_LEVEL_PATH));
								if(inputlist.get(1).contains(Constant.TOP_LEVEL_PATH)) {
									if(exception.isDirectoryExist(inputlist.get(1)))
										currentPath = inputlist.get(1);
								}
								else if(inputlist.get(1).contains(":")) { // cd :
									System.out.println("파일 이름, 디렉터리 이름 또는 볼륨 레이블 구문이 잘못되었습니다.");
								}
								else if(inputlist.get(1).equals("..") && inputlist.size() == 2) {
									if(!currentPath.equals(Constant.TOP_LEVEL_PATH)) {
										currentPath = currentPath.substring(0, currentPath.lastIndexOf("\\"));
										break;
									}
								}
								else {
									targetPath = currentPath + "\\" + inputlist.get(1);
									//System.out.println(currentPath);
									//System.out.println(targetPath);
									//System.out.println(inputlist.get(1));
									if(exception.isDirectoryExist(targetPath))
										currentPath = targetPath;
								}
							}
						}
						else { // cd에 띄어쓰기 안함
							//if(inputlist.get(0).length() == 3) {// cd. 이런식
								if(inputlist.get(0).substring(2, 3).equals(".")) {
									if(inputlist.get(0).substring(3, 4).equals(".") && inputlist.get(0).length() == 4) {
										if(!currentPath.equals(Constant.TOP_LEVEL_PATH)) {
											currentPath = currentPath.substring(0, currentPath.lastIndexOf("\\"));
										}
									}
									else {
										break;
									}										
								}
								if(inputlist.get(0).substring(2, 3).equals("/") || inputlist.get(0).substring(2, 3).equals("\\")) {
									currentPath = Constant.TOP_LEVEL_PATH;
								}
								if(inputlist.get(0).substring(2, 3).equals(",") || inputlist.get(0).substring(2, 3).equals(";") || inputlist.get(0).substring(2, 3).equals("=")
										|| inputlist.get(0).substring(2, 3).equals("&")) {
									result.showCurrentPath(currentPath); // 현재 경로 출력
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
									System.out.println(inputlist.get(0) + "뒤에 입력한 값'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는 배치 파일이 아닙니다.");
								}
								if(inputlist.get(0).substring(2, 3).equals("|")) {
									System.out.println("명령 구문이 올바르지 않습니다.");
								}
								if(inputlist.get(0).substring(2, 3).equals("+") || inputlist.get(0).substring(2, 3).equals("(")) {
									System.out.println("지정된 경로를 찾을 수 없습니다.");
								}
								if(inputlist.get(0).substring(2, 3).equals("^")) {
									System.out.print("More?");
									String calculationInputString = new Scanner(System.in).nextLine();
									System.out.println("cd" + calculationInputString + "뒤에 입력한 값'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는 배치 파일이 아닙니다.");
								}
							//}
							//else if(inputlist.get(0).length() == 4){
								
							//}
						}
					}
					break;
				}
				inputString = input.inputCommand(currentPath);
				inputlist = dataManagement.splitString(inputString);
				//String splittedString[] = dataManagement.splitString(input.startCommand(command.getVersion()));
			}
			// splittedString[] = (input.inputCommand()).split(" ");
		}

		// System.out.println(System.getProperty("file.separator"));
	}


}
