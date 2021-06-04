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
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

import Model.*;
import View.InputManagement;
import View.ShowResult;

public class CommandProgram {
	private CommandCalculation command;
	private InputManagement input;
	private ShowResult result;
	private Exception exception;
	private dataManagement dataManagement;
	private String currentPath;
	private List<String> avoidCommasString;

	public CommandProgram() {
		command = new CommandCalculation();
		input = new InputManagement();
		result = new ShowResult();
		dataManagement = new dataManagement();
		exception = new Exception(command, result, dataManagement, input);
		
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
		String inputString = input.startCommand(command.getVersion(), currentPath);
		List<String> inputlist = dataManagement.splitString(inputString);
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
				case "copy": // ±Ì¿∫ ∫πªÁ
					exception.copyException(dataManagement.avoidCommasList(inputString), currentPath, false);	
					break;
				case "move":
					if(exception.moveException(dataManagement.avoidCommasList(inputString), currentPath, true))
						command.delete(avoidCommasString.get(1), currentPath);
					break;
				case "tree":
					break;
				default:
					if(inputlist.get(0).substring(0, 2).equals("cd"))
						currentPath = exception.changeDirectoryException(inputlist, currentPath);						
					break;
				}
				inputString = input.inputCommand(currentPath);
				inputlist = dataManagement.splitString(inputString);
			}
		}
	}


}
