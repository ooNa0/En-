package Interaction.Data;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class DataManagement {
	
	
	public List<String> splitString(String inputString) {
		
		String[] array = inputString.trim().split("\\s+");
		
		List<String> list = new ArrayList<String>();
		
		for(int i=0; i<array.length; i++){
		    list.add(array[i]);
		}
		return list;
	}
	
	public String backPath(String currentPath) {
		currentPath = currentPath.substring(0, currentPath.lastIndexOf("\\"));
		if(currentPath.equals(Constant.DRIVE))
			currentPath = Constant.TOP_LEVEL_PATH;
		return currentPath;
	}
	
	public String repdddlaceCurrentPath(String path) {
		File file = new File(path);		
		try {
			return file.getCanonicalPath().replace("\\\\", "\\");
		} catch (IOException e) {
			e.printStackTrace();
		}
		return null;
	}
	
	public List<String> avoidCommasList(String inputString){
		List<String> avoidCommasString = new ArrayList<String>();
		Pattern regex = Pattern.compile(Constant.AVOID_COMMAS_PATTERN);
		Matcher regexMatcher = regex.matcher(inputString);
		while (regexMatcher.find()) {
			avoidCommasString.add(regexMatcher.group().replace("\"", Constant.EMPTY_VALUE).replace("\'", Constant.EMPTY_VALUE));
		}
		return avoidCommasString;
	}
	
	public String replaceCurrentPath(String path, String currentPath) {
		String convertPath = null;
		
		if(path.contains("."))
			path = currentPath + path;
		File file = new File(path);
		try {
			convertPath = file.getCanonicalPath();
		} catch (IOException e1) {
			e1.printStackTrace();
		}
		if(!file.exists())
			return null;
		
		return convertPath;
	}
}
