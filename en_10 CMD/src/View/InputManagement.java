package View;

import java.util.Scanner;

public class InputManagement {
	public String startCommand(String versionInformation) {
		String inputString;
		System.out.println(versionInformation);
		System.out.print(System.getProperty("user.home") + ">");

		// 엔터를 기준으로 String으로 받는다.
		inputString = new Scanner(System.in).nextLine();
		
		//System.out.println("Result : " + inputString);

		return inputString;
	}
	
	public String inputCommand() {
		String inputString;
		System.out.print(System.getProperty("user.home") + ">");

		// 엔터를 기준으로 String으로 받는다.
		inputString = new Scanner(System.in).nextLine();
		
		//System.out.println("Result : " + inputString);

		return inputString;
	}
}
