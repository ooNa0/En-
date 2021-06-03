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

	public CommandProgram() {
		command = new ApplyCommand();
		input = new InputManagement();
		result = new ShowResult();
		// System.out.println(command.getVolume());
		// showDirectory();
		// clearScreen();
		runProgram();

	}

	

	private void runProgram() {
		//List<String> inputlist = new ArrayList<String>();
		List<String> inputlist = dataManagement.splitString(input.startCommand(command.getVersion()));
		//String firstsplittedString[] = dataManagement.splitString(input.startCommand(command.getVersion()));
		while (true) {
			if (inputlist.isEmpty()) {
			} else {
				switch (inputlist.get(0)) {
				case "cd":
					break;
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
				case "copy":
					break;
				case "move":
					break;
				case "tree":
					break;
				case "exit":
					break;
				}
				inputlist = dataManagement.splitString(input.inputCommand());
				//String splittedString[] = dataManagement.splitString(input.startCommand(command.getVersion()));
			}
			// splittedString[] = (input.inputCommand()).split(" ");
		}

		// System.out.println(System.getProperty("file.separator"));
	}

}
