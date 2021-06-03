package Model;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ApplyCommand {

	
	
	public String getVersion() {
		String outVertionInformation = "";
		try {
			BufferedReader buffer = new BufferedReader(new InputStreamReader(new ProcessBuilder("cmd").start().getInputStream()));
			outVertionInformation = buffer.readLine() + "\n";
			outVertionInformation += buffer.readLine() + "\n";
			outVertionInformation += buffer.readLine();
		} catch (IOException e) {}
		return outVertionInformation;
	}
	
	public String getVolume() {
		String outVertionInformation = "";
		try {
			BufferedReader buffer = new BufferedReader(new InputStreamReader(new ProcessBuilder("cmd", "/c", "dir").start().getInputStream()));
			outVertionInformation = buffer.readLine() + "\n";

			outVertionInformation += buffer.readLine() + "\n";;
			outVertionInformation += buffer.readLine();
		} catch (IOException e) {}
		return outVertionInformation;
	}
	
	public void clsCommand() {
		System.out.print("\033[H\033[2J");
        System.out.flush();
	}
	
	/*
	 * void cls(HANDLE hConsole) { CONSOLE_SCREEN_BUFFER_INFO csbi; SMALL_RECT
	 * scrollRect; COORD scrollTarget; CHAR_INFO fill;
	 * 
	 * // Get the number of character cells in the current buffer. if
	 * (!GetConsoleScreenBufferInfo(hConsole, &csbi)) { return; }
	 * 
	 * // Scroll the rectangle of the entire buffer. scrollRect.Left = 0;
	 * scrollRect.Top = 0; scrollRect.Right = csbi.dwSize.X; scrollRect.Bottom =
	 * csbi.dwSize.Y;
	 * 
	 * // Scroll it upwards off the top of the buffer with a magnitude of the entire
	 * height. scrollTarget.X = 0; scrollTarget.Y = (SHORT)(0 - csbi.dwSize.Y);
	 * 
	 * // Fill with empty spaces with the buffer's default text attribute.
	 * fill.Char.UnicodeChar = TEXT(' '); fill.Attributes = csbi.wAttributes;
	 * 
	 * // Do the scroll ScrollConsoleScreenBuffer(hConsole, &scrollRect, NULL,
	 * scrollTarget, &fill);
	 * 
	 * // Move the cursor to the top left corner too. csbi.dwCursorPosition.X = 0;
	 * csbi.dwCursorPosition.Y = 0;
	 * 
	 * SetConsoleCursorPosition(hConsole, csbi.dwCursorPosition); }
	 * 
	 * int main(void) { HANDLE hStdout;
	 * 
	 * hStdout = GetStdHandle(STD_OUTPUT_HANDLE);
	 * 
	 * cls(hStdout);
	 * 
	 * return 0; }
	 */
}
