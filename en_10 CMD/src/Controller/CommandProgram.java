package Controller;

import Model.ApplyCommand;
import View.InputManagement;

public class CommandProgram {
	//private String commandVersion;
	private ApplyCommand command;
	private InputManagement input;
	
	public CommandProgram() {
		command = new ApplyCommand();
		input = new InputManagement();
		
		//input.startCommand(command.getVersion());
		System.out.println(System.getProperty("file.separator"));
	}
	
	
	
}
