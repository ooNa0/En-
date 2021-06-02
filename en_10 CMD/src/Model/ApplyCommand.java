package Model;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ApplyCommand {
	
	public String getVersion(){
		BufferedReader br = null;
		String outVertionInformation = null;
		String i;
		try {
			//br = new BufferedReader(new InputStreamReader(Runtime.getRuntime().exec("cmd /c" + "cmd").getInputStream(), "EUC-KR"));
			br = new BufferedReader(new InputStreamReader(new ProcessBuilder("cmd", "/c", "cmd").start().getInputStream()));
			while ((i = br.readLine()) != null) {
				outVertionInformation += i + "\n";
				System.out.println("out = " + outVertionInformation);
				
			}
		} catch (IOException e) {}
		System.out.println("하 왜 안되냐");
		return outVertionInformation;
	}
	/*
	void cls(HANDLE hConsole)
	{
	    CONSOLE_SCREEN_BUFFER_INFO csbi;
	    SMALL_RECT scrollRect;
	    COORD scrollTarget;
	    CHAR_INFO fill;

	    // Get the number of character cells in the current buffer.
	    if (!GetConsoleScreenBufferInfo(hConsole, &csbi))
	    {
	        return;
	    }

	    // Scroll the rectangle of the entire buffer.
	    scrollRect.Left = 0;
	    scrollRect.Top = 0;
	    scrollRect.Right = csbi.dwSize.X;
	    scrollRect.Bottom = csbi.dwSize.Y;

	    // Scroll it upwards off the top of the buffer with a magnitude of the entire height.
	    scrollTarget.X = 0;
	    scrollTarget.Y = (SHORT)(0 - csbi.dwSize.Y);

	    // Fill with empty spaces with the buffer's default text attribute.
	    fill.Char.UnicodeChar = TEXT(' ');
	    fill.Attributes = csbi.wAttributes;

	    // Do the scroll
	    ScrollConsoleScreenBuffer(hConsole, &scrollRect, NULL, scrollTarget, &fill);

	    // Move the cursor to the top left corner too.
	    csbi.dwCursorPosition.X = 0;
	    csbi.dwCursorPosition.Y = 0;

	    SetConsoleCursorPosition(hConsole, csbi.dwCursorPosition);
	}

	int main(void)
	{
	    HANDLE hStdout;

	    hStdout = GetStdHandle(STD_OUTPUT_HANDLE);

	    cls(hStdout);

	    return 0;
	}*/
}
