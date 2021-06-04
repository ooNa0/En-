package Controller;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.util.List;
import java.util.Scanner;

import Model.CommandCalculation;
import Model.Constant;
import Model.dataManagement;
import View.InputManagement;
import View.ShowResult;

public class Exception {

	private ShowResult result;
	private InputManagement input;
	private dataManagement dataManagement;
	private CommandCalculation command;
	private String fromPath;
	private String toPath;
	private String askString;
	private int index;
	private int indexrow;
	private File[] fileList;
	
	public Exception(CommandCalculation command, ShowResult result, dataManagement dataManagement, InputManagement input) {
		this.command = command;
		this.result = result;
		this.dataManagement = dataManagement;
		this.input = input;
	}

	public boolean isDirectoryExist(String path) {

		File targetFile = new File(path);
		if(targetFile.exists()) { // 파일이나 디렉토리 존재
			if(targetFile.isFile()) {
				System.out.println(Constant.INFORMATION_DIRECTORY_NAME_INCORRECT);
			}
			else {
				return true;
			}
		}
		else {
			System.out.println(Constant.INFORMATION_PATH_NOTFOUND);
		}
		
		return false;
	}
	
	private boolean isCorrectPrepareException(List<String> inputStringList, String currentPath) {
		fromPath = inputStringList.get(1);
		toPath = inputStringList.get(2);
		
		// dirve 이름이 없으면, 앞에 경로에 추가해주기
		if(!inputStringList.get(1).contains(Constant.TOP_LEVEL_PATH)) {
			fromPath = currentPath + "\\" + inputStringList.get(1);
		}
		if(!inputStringList.get(2).contains(Constant.TOP_LEVEL_PATH)) {
			toPath = currentPath + "\\" + inputStringList.get(2);
		}
		
		File file = new File(fromPath);
		if(!file.exists()) {
			System.out.println(Constant.INFORMATION_FILE_NOTFOUND);
			return false;
		}	
		
		return true;
	}
	
	public void copyException(List<String> inputStringList, String currentPath, boolean isMoveCommand) {

		int copyNumber = 0;
		if (!isCorrectPrepareException(inputStringList, currentPath))
			return;

		File fromFile = new File(fromPath);
		File toFile = new File(toPath);

		fileList = fromFile.listFiles();

		boolean isAsk = true;
		boolean isOverlap = false;

		if(fromPath.equals(toPath)) {
			System.out.println(Constant.INFORMATION_DONOT_COPY_SAMEFILE);
		}
		else {
			if (toFile.exists()) {
				if (toFile.isFile()) { // 대상이 파일일 경우
					//if()
					//command.copy(fromPath, toPath);
					switch (input.isContinueAsking(toFile)) {
					case Constant.COVER:
						command.copy(fromPath, toPath);
						copyNumber++;
						break;
					case Constant.COVER_ALL:
						break;
					}
				}
				else { // 대상이 디렉토리일 경우
					if(fromFile.isFile()) { // 파일에서 -> 디렉토리
						command.copy(fromPath, toPath + "\\" + fromFile.getName());
						copyNumber++;
					}
					else { // 디렉토리 -> 디렉토리
						
						// 예외처리 제대로 동작 X
						for (index = 0; index < fileList.length; index++) {
							isOverlap = false;
							for (indexrow = 0; indexrow < toFile.listFiles().length; indexrow++) {
								if (fileList[index].getName().equalsIgnoreCase(toFile.listFiles()[indexrow].getName())) {
									isOverlap = true;
									break;
								}
								// System.out.println(fileList[index].getName());
							}
							if(indexrow == toFile.listFiles().length) {
								//command.copyDirectory(fromFile, toFile);
								//command.copyDirectory(fileList[index].getPath(), toFile.listFiles()[indexrow-1].getPath());
								//command.copy(fileList[index].getPath(), toFile.listFiles()[indexrow-1].getPath());
								//command.copy(fileList[index].getPath(), toFile.listFiles()[indexrow-1].getPath());
								copyNumber++;								
							}
							if (isOverlap) {								
								switch (input.isContinueAsking(fileList[index])) {
								case 1: // Constant하면 case expressions must be constant expressions 에러
									//command.copyDirectory(fileList[index].getPath(), toFile.listFiles()[indexrow].getPath());
									//command.copy(fileList[index].getPath(), toFile.listFiles()[indexrow].getPath());
									copyNumber++;
									break;
								case 0:
									isOverlap = false;
									break;
								}
							}
						}
						command.copyDirectory(fromFile.getPath(), toFile.getPath());
					}					
				}
			}
			else {
				if(fromFile.isDirectory()) {
					command.copyDirectory(fromFile.getPath(), toFile.getPath());
				}
				else {
					command.copy(fromPath, toPath);
					
				}
				copyNumber++;
			}
		}

		result.printMessage("\t" + copyNumber + Constant.INFORMATION_COPY_SUCCESS);
	}
	
	public boolean moveException(List<String> inputStringList, String currentPath, boolean isMoveCommand) {
		
		int moveNumber = 0;
		
		if(!isCorrectPrepareException(inputStringList, currentPath))
			return false;

		File fromFile = new File(fromPath);
		File toFile = new File(toPath);

		if(inputStringList.size() > 3) {result.printMessage(Constant.INFORMATION_COMMAND_SYNTAX_INCORRECT); return false;}

		if(!fromFile.exists()) return false;
		
		//if(fromPath.equals(toPath)) {
		//}
		//else {
			//if(fromFile.isDirectory());
		//}
		
		fileList = fromFile.listFiles();

		boolean isAsk = true;
		boolean isOverlap = false;

		if(fromPath.equals(toPath)) {
			System.out.println(Constant.INFORMATION_PROCESSOR_RUNNING);
		}
		else{
			if (toFile.exists()) {
				if (toFile.isFile()) { // 대상이 파일일 경우
					// 디렉 -> 파일, 파일 -> 파일 (안나눠도됨, 동일함)
					//덮어쓰겠습니까? 물어보기
					switch (input.isContinueAsking(toFile)) {
					case Constant.COVER:
						command.copy(fromPath, toPath);
						moveNumber++;
						break;
					case Constant.COVER_ALL:
						break;
					}
				}
				else { // 대상이 디렉토리일 경우
					if(fromFile.isFile()) { // 파일 -> 디렉토리
						// 겹치는거 덮어씌우는지 묻기 한번
						command.copy(fromPath, toPath + "\\" + fromFile.getName());
						moveNumber++;
					}
					else { // 디렉토리 -> 디렉토리
						new File(toPath + "\\" + fromFile.getName()).mkdir();
						command.copyDirectory(fromPath, toPath + "\\" + fromFile.getName());
						//command.copyDirectory(fromFile.getPath(), toFile.getPath());
						
						return false;
					}
					// 디렉1 -> 디렉2
					// 디렉2 안에 디렉1이 들어감, 만약에 디렉2안에 디렉1과 같은 이름 있음 덮어쓰겠습니까?
					//command.copyDirectory(fromPath, toPath);

					// 파일 -> 디렉
					// 디렉 안에 파일 넣기
				}
			}
			else {
				command.copy(fromPath, toPath);
				moveNumber++;
			}
		}

		result.printMessage("\t" + moveNumber + Constant.INFORMATION_MOVE_SUCCESS);
		return true;
	}
	
	public void otherInput(String inputString) {
		if(inputString == null || inputString.substring(0, 1).equals(":")|| inputString.substring(0, 1).equals(",")) {
			
		}
		else {
			result.printMessage("'" + inputString + Constant.INFORMATION_NOT_COMMAND_OPERABLE_PROGRAM_BATCHFILE);
		}
	}
	
	public String changeDirectoryException(List<String> inputlist, String currentPath) {
		if(inputlist.size() == 1) { //cd cd,
			
		}
		else { // 띄어쓰기가 무조건 있거
			
		}		
		
		if(inputlist.get(0).length() == 2) { // cd에 띄어쓰기
			if(inputlist.size() == 1) { // cd만 입력
				result.printMessage(currentPath); // 현재 경로 출력 dataManagement.showCurrentPath
			}
			else { // cd [값] 이런 식
				String targetPath = null;
				if(inputlist.get(1).contains(Constant.TOP_LEVEL_PATH)) { // 절대 경로 입력
					if(isDirectoryExist(inputlist.get(1)))
						currentPath = inputlist.get(1);
				}
				else if(inputlist.get(1).contains(":")) { // cd :
					result.printMessage(Constant. INFORMATION_FILE_DIRECTORY_VOLUME_NAME_INCORRECT);
				}
				else if(inputlist.get(1).contains("../")){
					
				}
				else if(inputlist.get(1).equals(Constant.PARENT_FOLDER_RELAIVE_PATH) && inputlist.size() == 2) {
					currentPath = dataManagement.backPath(currentPath);
					//if(!currentPath.equals(Constant.TOP_LEVEL_PATH)) {
					//	currentPath = currentPath.substring(0, currentPath.lastIndexOf("\\"));
					//	break;
					//}
				}
				else { // 상대 경로 입력
					targetPath = currentPath + "\\" + inputlist.get(1);
					if(isDirectoryExist(targetPath))
						currentPath = targetPath;
				}
			}
		}
		else { // cd에 띄어쓰기 안함
			//if(inputlist.get(0).length() == 3) {// cd. 이런식
				if(inputlist.get(0).substring(2, 3).equals(".")) {
					if(inputlist.get(0).length() == 4 && inputlist.get(0).substring(3, 4).equals(".")) {
						currentPath = dataManagement.backPath(currentPath);
					}
				}
				if(inputlist.get(0).substring(2, 3).equals("/") || inputlist.get(0).substring(2, 3).equals("\\")) {
					currentPath = Constant.TOP_LEVEL_PATH;
				}
				if(inputlist.get(0).substring(2, 3).equals(",") || inputlist.get(0).substring(2, 3).equals(";") || inputlist.get(0).substring(2, 3).equals("=")
						|| inputlist.get(0).substring(2, 3).equals("&")) {
					result.printMessage(currentPath); // 현재 경로 출력result.showCurrentPath(
				}
				if(inputlist.get(0).substring(2, 3).equals(":")) {
					result.printMessage(Constant.INFORMATION_FILE_DIRECTORY_VOLUME_NAME_INCORRECT);
				}
				if(inputlist.get(0).substring(2, 3).equals("?") || inputlist.get(0).substring(2, 3).equals(";") || inputlist.get(0).substring(2, 3).equals("'")
						|| inputlist.get(0).substring(2, 3).equals("\"") || inputlist.get(0).substring(2, 3).equals("-") || inputlist.get(0).substring(2, 3).equals("_")
						|| inputlist.get(0).substring(2, 3).equals(")") || inputlist.get(0).substring(2, 3).equals("*")
						|| inputlist.get(0).substring(2, 3).equals("%")|| inputlist.get(0).substring(2, 3).equals("$")
						|| inputlist.get(0).substring(2, 3).equals("#")|| inputlist.get(0).substring(2, 3).equals("@")
						|| inputlist.get(0).substring(2, 3).equals("!")|| inputlist.get(0).substring(2, 3).equals("~")
						|| inputlist.get(0).substring(2, 3).equals("`")) {
					result.printMessage("'" + inputlist.get(0) + Constant.INFORMATION_NOT_COMMAND_OPERABLE_PROGRAM_BATCHFILE);
				}
				if(inputlist.get(0).substring(2, 3).equals("|")) {
					result.printMessage(Constant.INFORMATION_COMMAND_SYNTAX_INCORRECT);
				}
				if(inputlist.get(0).substring(2, 3).equals("+") || inputlist.get(0).substring(2, 3).equals("(")) {
					result.printMessage(Constant.INFORMATION_PATH_NOTFOUND);
				}
				if(inputlist.get(0).substring(2, 3).equals("^")) {
					result.printMessage("More?");
					askString = new Scanner(System.in).nextLine();
					result.printMessage("'cd" + askString + Constant.INFORMATION_NOT_COMMAND_OPERABLE_PROGRAM_BATCHFILE);
				}
			//}
			//else if(inputlist.get(0).length() == 4){
				
			//}
		}
		return currentPath;
	}
	
}
