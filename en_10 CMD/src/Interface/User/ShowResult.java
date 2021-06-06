package View;

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

import Model.Constant;

public class ShowResult {

	private NumberFormat sizeFormatString = NumberFormat.getInstance(Locale.KOREA);
	private DecimalFormat sizeFormat = new DecimalFormat("#,###");
	// 원하는 날짜 포맷으로 값 저장
	private SimpleDateFormat fileDateFormat = new SimpleDateFormat(Constant.DIRECTORY_DATE_FORMAT);
	
	public String showCurrentPath(String path) {
		File file = new File(path);		
		try {
			return file.getCanonicalPath().replace("\\\\", "\\");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}
	
	public void helpCommand() {
		System.out.println(Constant.HELP_COMMAND_INFORMATION);
	}
	
	public void clearScreen() {
		for(int i = 0; i < 50; i++) {
			System.out.println();
		}
	}
	
	public void showDirectory(String path) { // /b 파일 이르므만 보게 하는거
		// Model 친구들이다.
		int filesSize = 0;
		int fileNumber = 0;
		int directoryNumber = 2;
		String attr = ""; // 파일의 속성
		String size = ""; // 파일 용량
		
		System.out.println(path + " 디렉터리\n");		
		
		File file = new File(path); // 보고자 하는 디렉토리(파일)
		
		if(!path.equals(Constant.DIRECTORY_DATE_FORMAT)) {
				//FileTime time = Files.readAttributes(file.toPath(), BasicFileAttributes.class).creationTime();
				//System.out.printf("%s %5s %12s %s\n", fileDateFormat.format(time.toMillis()).toString(), attr, size, ".");
				System.out.printf("%s %5s %12s %s\n", fileDateFormat.format(new Date(file.lastModified())).toString(), "<DIR>", size, ".");
				System.out.printf("%s %5s %12s %s\n", fileDateFormat.format(new Date(file.lastModified())).toString(), "<DIR>", size, "..");

		}
		// 디렉토리 안의 모든 파일 목록 가져오기
		File[] files = file.listFiles();
		// 하위 디렉토리 정보를 저장할 리스트 생성, 파일 배열의 인텍스 저장
		List<Integer> subDirctioryList = new ArrayList<Integer>();
		for (int i = 0; i < files.length; i++) {
			attr = ""; // 파일의 속성
			size = ""; // 파일 용량

			if (files[i].isDirectory()) {
				attr = "<DIR>";
				directoryNumber++;
				subDirctioryList.add(i);
			}
			if (files[i].isFile()) {
				if (files[i].getName().endsWith(".ini")) { // 얜 출력도 안함
					continue;
				}
				fileNumber++;
				filesSize += files[i].length();
				size = sizeFormat.format(new BigDecimal(files[i].length())).toString() + "";
			}
			System.out.printf("%s %5s %12s %s\n", fileDateFormat.format(new Date(files[i].lastModified())).toString(),
					attr, size, files[i].getName());
		}
		System.out.printf("              %d개 파일    %16s 바이트\n", fileNumber, sizeFormatString.format(filesSize));
		System.out.printf("              %d개 디렉토리 %16s 바이트 남음\n",directoryNumber, sizeFormat.format(new BigDecimal(file.getUsableSpace())));
		//System.out.printf("              %d개 디렉토리 %16s 바이트 남음\n\n", directoryNumber, sizeFormat.format(new BigDecimal((file.getUsableSpace()) - (root.getUsableSpace() / Math.pow(1024, 3)))));

		 
	}
	
	
}
