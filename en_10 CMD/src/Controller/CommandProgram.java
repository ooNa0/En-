package Controller;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import Model.ApplyCommand;
import View.InputManagement;
import View.ShowResult;

public class CommandProgram {
	private ApplyCommand command;
	private InputManagement input;
	private ShowResult result;
	
	public CommandProgram() {
		command = new ApplyCommand();
		input = new InputManagement();
		result = new ShowResult();
		
		System.out.print("Everything on the console will cleared");
		showDirectory();
		//clearScreen();
		//runProgram();
		
	}
	
	public void showDirectory() {
		String path = System.getProperty("user.home");
	    System.out.println("Working Directory = " + path);
	    File file = new File(path); // 보고자 하는 디렉토리(파일)
	    System.out.println("[" + file.getAbsolutePath() + "]" + " 디렉토리 내용");
	    
	    // 디렉토리 안의 모든 파일 목록 가져오기
	    File[] files = file.listFiles();
	    // 하위 디렉토리 정보를 저장할 리스트 생성, 파일 배열의 인텍스 저장
	    List<Integer> subDirctioryList = new ArrayList<Integer>();
	    // 원하는 날짜 포맷으로 값 저장
	    SimpleDateFormat fileDateFormat = new SimpleDateFormat("yyyy-MM-dd a hh:mm");
	    
	    for(int i = 0; i < files.length; i++) {
	    	String attr = ""; // 파일의 속성
	    	String size = ""; // 파일 용량
	    	
	    	if(files[i].isDirectory()) {
	    		attr = "<DIR>";
	    		subDirctioryList.add(i);
	    	}
	    	else {
	    		size = files[i].length() + "";
	    	}
	    	System.out.printf("%s %5s %12s %s\n", 
	    			fileDateFormat.format(new Date(files[i].lastModified())).toString(),
	    			attr, size, files[i].getName());
	    }
	    
	}
	
	private void runProgram() {
		//System.out.println(splittedString.length);
		String splittedString[] = input.startCommand(command.getVersion()).split(" ");
		while(true) {
			
			input.inputCommand().split(" ");
			if(splittedString.length == 0) { }
			else {
				for(int i=0 ; i<splittedString.length ; i++)
		        {
		            //System.out.println("splittedString["+i+"] : " + splittedString[i]);
		        }
			}			
		}
		
		//System.out.println(System.getProperty("file.separator"));
	}
	
}
