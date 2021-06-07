package Mediator;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.util.List;
import java.util.Scanner;

import Interaction.Data.CommandCalculation;
import Interaction.Data.Constant;
import Interaction.Data.DataManagement;
import Interaction.User.InputManagement;
import Interaction.User.ShowResult;

public class Exception {

	private ShowResult result;
	private InputManagement input;
	private DataManagement dataManagement;
	private CommandCalculation command;
	private String fromPath;
	private String toPath;
	private String askString;
	private int index;
	private int indexrow;
	private File[] fileList;

	public Exception(CommandCalculation command, ShowResult result, DataManagement dataManagement, InputManagement input) {
		this.command = command;
		this.result = result;
		this.dataManagement = dataManagement;
		this.input = input;
	}

	public boolean isDirectoryExist(String path) {

		File targetFile = new File(path);
		if (targetFile.exists()) { // 파일이나 디렉토리 존재
			if (targetFile.isFile()) {
				System.out.println(Constant.INFORMATION_DIRECTORY_NAME_INCORRECT);
			} else {
				return true;
			}
		} else {
			System.out.println(Constant.INFORMATION_PATH_NOTFOUND);
		}

		return false;
	}

	private boolean isCorrectPrepareException(List<String> inputStringList, String currentPath) {
		fromPath = inputStringList.get(1);
		toPath = inputStringList.get(2);

		// dirve 이름이 없으면, 앞에 경로에 추가해주기
		if (!inputStringList.get(1).contains(Constant.TOP_LEVEL_PATH)) {
			fromPath = currentPath + "\\" + inputStringList.get(1);
		}
		if (!inputStringList.get(2).contains(Constant.TOP_LEVEL_PATH)) {
			toPath = currentPath + "\\" + inputStringList.get(2);
		}

		File file = new File(fromPath);
		if (!file.exists()) {
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

		boolean isOverlap = false;

		if (fromPath.equals(toPath)) {
			System.out.println(Constant.INFORMATION_DONOT_COPY_SAMEFILE);
			result.printMessage("\t" + copyNumber + Constant.INFORMATION_COPY_SUCCESS);
			return;
		}

		if (toFile.exists()) {
			if (toFile.isFile()) { // 대상이 파일일 경우
				switch (input.isContinueAsking(toFile)) {
				case Constant.COVER:
					command.copy(fromPath, toPath);
					copyNumber++;
					break;
				case Constant.COVER_ALL:
					break;
				}
			} else { // 대상이 디렉토리일 경우
				if (fromFile.isFile()) { // 파일에서 -> 디렉토리
					command.copy(fromPath, toPath + "\\" + fromFile.getName());
					copyNumber++;
				} else { // 디렉토리 -> 디렉토리
							// 예외처리 제대로 동작 X
					for (index = 0; index < fileList.length; index++) {
						isOverlap = false;
						for (indexrow = 0; indexrow < toFile.listFiles().length; indexrow++) {
							if (fileList[index].getName().equalsIgnoreCase(toFile.listFiles()[indexrow].getName())) {
								isOverlap = true;
								break;
							}
						}
						if (indexrow == toFile.listFiles().length) {
							copyNumber++;
						}
						if (isOverlap) {
							switch (input.isContinueAsking(fileList[index])) {
							case Constant.COVER:
								copyNumber++;
								break;
							case Constant.COVER_ALL:
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
			if (fromFile.isDirectory()) {
				command.copyDirectory(fromFile.getPath(), toFile.getPath());
			} else {
				command.copy(fromPath, toPath);
			}
			copyNumber++;
		}

		result.printMessage("\t" + copyNumber + Constant.INFORMATION_COPY_SUCCESS);
	}

	public boolean moveException(List<String> inputStringList, String currentPath, boolean isMoveCommand) {

		int moveNumber = 0;

		if (!isCorrectPrepareException(inputStringList, currentPath))
			return false;

		File fromFile = new File(fromPath);
		File toFile = new File(toPath);

		if (inputStringList.size() > 3) {
			result.printMessage(Constant.INFORMATION_COMMAND_SYNTAX_INCORRECT);
			return false;
		}

		if (!fromFile.exists())
			return false;

		fileList = fromFile.listFiles();

		if (fromPath.equals(toPath)) {
			System.out.println(Constant.INFORMATION_PROCESSOR_RUNNING);
		} 
		else {
			if (toFile.exists()) {
				if (toFile.isFile()) { // 대상이 파일일 경우
					// 디렉 -> 파일, 파일 -> 파일 (안나눠도됨, 동일함)
					// 덮어쓰겠습니까? 물어보기
					switch (input.isContinueAsking(toFile)) {
					case Constant.COVER:
						command.copy(fromPath, toPath);
						moveNumber++;
						break;
					case Constant.COVER_ALL:
						break;
					}
				} else { // 대상이 디렉토리일 경우
					if (fromFile.isFile()) { // 파일 -> 디렉토리
						// 겹치는거 덮어씌우는지 묻기 한번
						command.copy(fromPath, toPath + "\\" + fromFile.getName());
						moveNumber++;
					} else { // 디렉토리 -> 디렉토리, 디렉2 안에 디렉1이 들어감, 만약에 디렉2안에 디렉1과 같은 이름 있음 덮어쓰겠습니까?
						new File(toPath + "\\" + fromFile.getName()).mkdir();
						command.copyDirectory(fromPath, toPath + "\\" + fromFile.getName());
					}
				}
			} else {
				command.copy(fromPath, toPath);
				moveNumber++;
			}
		}

		result.printMessage("\t" + moveNumber + Constant.INFORMATION_MOVE_SUCCESS);
		return true;
	}

	public void otherInput(String inputString) {
		if (inputString == null || inputString.substring(0, 1).equals(":") || inputString.substring(0, 1).equals(",")) {

		} else {
			result.printMessage("'" + inputString + Constant.INFORMATION_NOT_COMMAND_OPERABLE_PROGRAM_BATCHFILE);
		}
	}

	public String changeDirectoryException(List<String> inputlist, String currentPath) {

		if (inputlist.get(0).length() == 2) { // cd에 띄어쓰기
			if (inputlist.size() == 1) { // cd만 입력
				result.printMessage(currentPath); // 현재 경로 출력 dataManagement.showCurrentPath
			} else { // cd [값] 이런 식
				String targetPath = null;
				//if (inputlist.get(1).contains(Constant.TOP_LEVEL_PATH)) { // 절대 경로 입력
				//	if (isDirectoryExist(inputlist.get(1)))
				//		//currentPath = inputlist.get(1);
				//		currentPath = dataManagement.replaceCurrentPath(inputlist.get(1), currentPath);
				//} 
				//else 
				if(inputlist.get(1).length() == 1 && inputlist.get(1).contains("/")) {
					currentPath = Constant.TOP_LEVEL_PATH;
				}
				else if (inputlist.get(1).contains(":")) { // cd :
					result.printMessage(Constant.INFORMATION_FILE_DIRECTORY_VOLUME_NAME_INCORRECT);
				} else if (inputlist.get(1).contains("../")) {
					currentPath = dataManagement.replaceCurrentPath(inputlist.get(1), currentPath);
				} else if (inputlist.get(1).equals(Constant.PARENT_FOLDER_RELAIVE_PATH) && inputlist.size() == 2) {
					//currentPath = dataManagement.replaceCurrentPath(inputlist.get(1), currentPath);
					currentPath = dataManagement.backPath(currentPath);
				} else { // 상대 경로 입력
					//currentPath = dataManagement.replaceCurrentPath(inputlist.get(1), currentPath);
					if(dataManagement.replaceCurrentPath(inputlist.get(1), currentPath) == null) {
						result.printMessage("'" + inputlist.get(1) + Constant.INFORMATION_NOT_COMMAND_OPERABLE_PROGRAM_BATCHFILE);
						return currentPath;
					}
					currentPath = dataManagement.replaceCurrentPath(inputlist.get(1), currentPath);
					/*
					targetPath = currentPath + "\\" + inputlist.get(1);
					//if (isDirectoryExist(targetPath))
					//	currentPath = targetPath;
					File f = new File(inputlist.get(1));
					try {
						//System.out.println("Can path : " + f.getCanonicalPath());
						
					} catch (IOException e) {
						e.printStackTrace();
					}
					if (isDirectoryExist(inputlist.get(1)))
						currentPath = targetPath;
						*/
				}
			}
		} else { // cd에 띄어쓰기 안함
					// if(inputlist.get(0).length() == 3) {// cd. 이런식
			if (inputlist.get(0).substring(2, 3).equals(".")) {
				if (inputlist.get(0).length() == 4 && inputlist.get(0).substring(3, 4).equals(".")) {
					currentPath = dataManagement.backPath(currentPath);
					//currentPath = dataManagement.replaceCurrentPath(inputlist.get(0).substring(2, inputlist.get(0).length()), currentPath);
				}
			}
			else if(inputlist.get(0).contains("../")) {
				currentPath = dataManagement.replaceCurrentPath(inputlist.get(0), currentPath);
			}
			else if (inputlist.get(0).substring(2, 3).equals("/") && inputlist.get(0).length() == 3) {//|| inputlist.get(0).substring(2, 3).equals("\\")) {
				currentPath = Constant.TOP_LEVEL_PATH;
			}
			else if (inputlist.get(0).substring(2, 3).equals(",") || inputlist.get(0).substring(2, 3).equals(";")
					|| inputlist.get(0).substring(2, 3).equals("=") || inputlist.get(0).substring(2, 3).equals("&")) {
				result.printMessage(currentPath); // 현재 경로 출력result.showCurrentPath(
			}
			else if (inputlist.get(0).substring(2, 3).equals(":")) {
				result.printMessage(Constant.INFORMATION_FILE_DIRECTORY_VOLUME_NAME_INCORRECT);
			}
			/*if (inputlist.get(0).substring(2, 3).equals("?") || inputlist.get(0).substring(2, 3).equals(";")
					|| inputlist.get(0).substring(2, 3).equals("'") || inputlist.get(0).substring(2, 3).equals("\"")
					|| inputlist.get(0).substring(2, 3).equals("-") || inputlist.get(0).substring(2, 3).equals("_")
					|| inputlist.get(0).substring(2, 3).equals(")") || inputlist.get(0).substring(2, 3).equals("*")
					|| inputlist.get(0).substring(2, 3).equals("%") || inputlist.get(0).substring(2, 3).equals("$")
					|| inputlist.get(0).substring(2, 3).equals("#") || inputlist.get(0).substring(2, 3).equals("@")
					|| inputlist.get(0).substring(2, 3).equals("!") || inputlist.get(0).substring(2, 3).equals("~")
					|| inputlist.get(0).substring(2, 3).equals("`")) {
				result.printMessage("'" + inputlist.get(0) + Constant.INFORMATION_NOT_COMMAND_OPERABLE_PROGRAM_BATCHFILE);
			}*/
			else if (inputlist.get(0).substring(2, 3).equals("|")) {
				result.printMessage(Constant.INFORMATION_COMMAND_SYNTAX_INCORRECT);
			}
			else if (inputlist.get(0).substring(2, 3).equals("+") || inputlist.get(0).substring(2, 3).equals("(")) {
				result.printMessage(Constant.INFORMATION_PATH_NOTFOUND);
			}
			else if (inputlist.get(0).substring(2, 3).equals("^")) {
				result.printMessage("More?");
				askString = new Scanner(System.in).nextLine();
				result.printMessage("'cd" + askString + Constant.INFORMATION_NOT_COMMAND_OPERABLE_PROGRAM_BATCHFILE);
			}
			else {
				result.printMessage("'" + inputlist.get(0) + Constant.INFORMATION_NOT_COMMAND_OPERABLE_PROGRAM_BATCHFILE);
			}
			// }
			// else if(inputlist.get(0).length() == 4){}
		}
		return currentPath;
	}	
}
