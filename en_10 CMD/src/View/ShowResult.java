package View;

import java.io.File;
import java.math.BigDecimal;
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
	
	public void helpCommand() {
		System.out.println(Constant.HELP_COMMAND_INFORMATION);
	}
	
	public void copyCommand(String from, String to) {
		
		//파일을 복사하는 메소드를 실행시킵니다.
		//정상처리 되었을때는 1을 실패시는 -1를 리턴하게 됩니다.
	}
	
	public void clearScreen() {
		for(int i = 0; i < 50; i++) {
			System.out.println();
		}
	}
	
	public void showDirectory() { // /b 파일 이르므만 보게 하는거
		// Model 친구들이다.
		int filesSize = 0;
		int fileNumber = 0;
		int directoryNumber = 0;
		String path = System.getProperty("user.home") + "\\Desktop";
		File file = new File(path); // 보고자 하는 디렉토리(파일)

		System.out.println(" " + file.getAbsolutePath() + " 디렉토리\n");

		// 디렉토리 안의 모든 파일 목록 가져오기
		File[] files = file.listFiles();
		// 하위 디렉토리 정보를 저장할 리스트 생성, 파일 배열의 인텍스 저장
		List<Integer> subDirctioryList = new ArrayList<Integer>();
		// 원하는 날짜 포맷으로 값 저장
		SimpleDateFormat fileDateFormat = new SimpleDateFormat(Constant.DIRECTORY_DATE_FORMAT);
		for (int i = 0; i < files.length; i++) {
			String attr = ""; // 파일의 속성
			String size = ""; // 파일 용량

			if (files[i].isDirectory()) {
				attr = "<DIR>";
				directoryNumber++;
				// size = sizeFormat.format(new BigDecimal(files[i].length())).toString() + "";
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
		}//
		//
		File root = new File("C:\\");
		System.out.printf("              %d개 파일    %16s 바이트\n", fileNumber, sizeFormatString.format(filesSize));
		System.out.printf("              %d개 디렉토리 %16s 바이트 남음\n\n",directoryNumber, sizeFormat.format(new BigDecimal(root.getUsableSpace())));
		
		 //try { System.out.printf("              %d개 파일 %16s 바이트 남음\n",
		 //directoryNumber, new byte[FileUtils.sizeOfDirectory(path)]); } catch
		 //(IOException e) { e.printStackTrace(); }
		 
	}
	
	
}
