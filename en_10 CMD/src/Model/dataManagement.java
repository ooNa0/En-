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
}
