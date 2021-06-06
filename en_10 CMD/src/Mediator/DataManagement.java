package Model;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class dataManagement {
	
	
	public List<String> splitString(String inputString) {
		
		String[] array = inputString.trim().split("\\s+");
		
		List<String> list = new ArrayList<String>();
		
		for(int i=0; i<array.length; i++){
		    list.add(array[i]);
		}

		
		//System.out.println(array.length);
		
		//for(int i=0;i<array.length;i++) {
		//System.out.println(array[i]);
		
		//String splittedString[] = inputString.split(" ");
		return list;
	}
	
	public String backPath(String currentPath) {
		currentPath = currentPath.substring(0, currentPath.lastIndexOf("\\"));
		if(currentPath.equals(Constant.DRIVE))
			currentPath = Constant.TOP_LEVEL_PATH;
		return currentPath;
		/*
		if(currentPath.equals(Constant.DRIVE) || currentPath.equals(Constant.TOP_LEVEL_PATH)) {
			if(currentPath.equals(Constant.DRIVE))
				return currentPath + "\\";
			return currentPath;
		}
		else {
			
		}
		if(!currentPath.substring(0, currentPath.lastIndexOf("\\")).equals(Constant.DRIVE)) {
			return currentPath.substring(0, currentPath.lastIndexOf("\\")) + "\\";			
		}
		return currentPath;
		*/
	}
}
