package Interaction.User;

import java.io.File;
import java.io.IOException;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.attribute.BasicFileAttributes;
import java.nio.file.attribute.FileTime;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import Interaction.Data.CommandCalculation;
import Interaction.Data.Constant;

public class ShowResult {

	private NumberFormat sizeFormatString = NumberFormat.getInstance(Locale.KOREA);
	private DecimalFormat sizeFormat = new DecimalFormat(Constant.INSERT_COMMAS_PATTERN);
	private SimpleDateFormat fileDateFormat = new SimpleDateFormat(Constant.DIRECTORY_DATE_FORMAT); // 원하는 날짜 포맷으로 값 저장

	private CommandCalculation command;
	public ShowResult(CommandCalculation command) {
		this.command = command;
	}

	public void printMessage(String message) {
		System.out.println(message);
	}

	public void helpCommand() {
		System.out.println(Constant.HELP_COMMAND_INFORMATION);
	}

	public void clearScreen() {
		for (int index = Constant.INITIAL_SIZE; index < Constant.NEED_EMPTY_SCREEN_SIZE; index++) {
			System.out.println();
		}
	}

	public void showDirectory(String path, String currentPath) { //

		System.out.println(command.getVolume());	
		
		int filesSize = Constant.INITIAL_SIZE;
		int fileNumber = Constant.INITIAL_SIZE;
		int directoryNumber = Constant.INITIAL_DIRECTORY_SIZE;
		String attr; // 파일의 속성
		String size; // 파일 용량

		if(path == null) {
			System.out.println(currentPath + Constant.DIRECTORY);
			return;
		}
		
		System.out.println(path + Constant.DIRECTORY);

		File file = new File(path); // 보고자 하는 디렉토리(파일)
		
		if (!path.equals(Constant.TOP_LEVEL_PATH)) {
			System.out.printf(Constant.DIRECTION_INFORMATION_PATTERN,
					fileDateFormat.format(new Date(file.lastModified())).toString(), Constant.DIRECTORY_ABBREVIATION,
					Constant.EMPTY_VALUE, Constant.PARENT_FOLDER_PATH);
			System.out.printf(Constant.DIRECTION_INFORMATION_PATTERN,
					fileDateFormat.format(new Date(file.lastModified())).toString(), Constant.DIRECTORY_ABBREVIATION,
					Constant.EMPTY_VALUE, Constant.PARENT_FOLDER_RELAIVE_PATH);

		}
		// 디렉토리 안의 모든 파일 목록 가져오기
		File[] files = file.listFiles();
		// 하위 디렉토리 정보를 저장할 리스트 생성, 파일 배열의 인텍스 저장
		List<Integer> subDirctioryList = new ArrayList<Integer>();
		for (int i = 0; i < files.length; i++) {
			attr = Constant.EMPTY_VALUE; // 파일의 속성
			size = Constant.EMPTY_VALUE; // 파일 용량

			if (files[i].isDirectory()) {
				attr = Constant.DIRECTORY_ABBREVIATION;
				directoryNumber++;
				subDirctioryList.add(i);
			}
			if (files[i].isFile()) {
				if (files[i].isHidden()) { // 숨긴 파일은 넘어가기
					continue;
				}
				fileNumber++;
				filesSize += files[i].length();
				size = sizeFormat.format(new BigDecimal(files[i].length())).toString() + Constant.EMPTY_VALUE;
			}
			System.out.printf(Constant.DIRECTION_INFORMATION_PATTERN,
					fileDateFormat.format(new Date(files[i].lastModified())).toString(), attr, size,
					files[i].getName());
		}
		System.out.printf(Constant.FILE_INFORMATION, fileNumber, sizeFormatString.format(filesSize));
		System.out.printf(Constant.DIRECTORY_INFORMATION, directoryNumber,
				sizeFormat.format(new BigDecimal(file.getUsableSpace())));
	}
}
