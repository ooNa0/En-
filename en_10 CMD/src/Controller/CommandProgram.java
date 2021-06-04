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
		currentPath = Constant.START_POSITION_VALUE + "\\Desktop";

		runProgram();
	}

	private void runProgram() {
		String inputString = input.startCommand(command.getVersion(), currentPath);
		List<String> inputlist = dataManagement.splitString(inputString);

		while (true) {
			if (inputlist.isEmpty()) {
			} else {
				switch (inputlist.get(0).toLowerCase()) {
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
				case "copy": // 깊은 복사
					exception.copyException(dataManagement.avoidCommasList(inputString), currentPath, false);
					break;
				case "move":
					System.out.println("값,,,자른거" + dataManagement.avoidCommasList(inputString).get(1));
					if (exception.moveException(dataManagement.avoidCommasList(inputString), currentPath, true))
						command.delete(dataManagement.avoidCommasList(inputString).get(1), currentPath);
					break;
				case "tree":
					break;
				case "cmd":
					runProgram();
					break;
				default:
					if (inputlist.get(0).toLowerCase().substring(0, 2).equals("cd"))
						currentPath = exception.changeDirectoryException(inputlist, currentPath);
					else {
						exception.otherInput(inputlist.get(0));
					}
					break;
				}				
				inputString = input.inputCommand(currentPath);
				inputlist = dataManagement.splitString(inputString);
			}
		}
	}

}
