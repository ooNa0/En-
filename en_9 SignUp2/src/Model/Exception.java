package Model;

import java.util.regex.Pattern;

public class Exception {
	public boolean isCorrectName(String name) {
		boolean name_check = Pattern.matches("^[°¡-ÆR]*$", name);
		return name_check;
	}
}
