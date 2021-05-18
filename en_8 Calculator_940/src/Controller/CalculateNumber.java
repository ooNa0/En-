package Controller;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BorderFactory;
import javax.swing.GroupLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;

import View.ViewCalculator;

@SuppressWarnings("serial")
public class CalculateNumber extends JPanel implements ActionListener{
	private String calculationProcessString = "";
	private JFrame frame;
	private JTextField inputNumberField;
	private JTextField calculationProcessField;
	private JButton[] buttons;


	
	private JButton[] btns;

	private int a = -1, b = 0, c = 0;
	int number = 0;
	boolean isInputOperator;
	int lastInput = 0;

	public CalculateNumber() {
		frame = new JFrame("계산기");
		frame.setBounds(100, 100, 500, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel panel = new JPanel();
		
		inputNumberField = new JTextField("0");
		inputNumberField.setHorizontalAlignment(SwingConstants.RIGHT);
		inputNumberField.setFont(new Font("굴림", Font.PLAIN, 30));
		inputNumberField.setColumns(10);
		inputNumberField.setEditable(false);
		
		calculationProcessField = new JTextField(" ");
		calculationProcessField.setHorizontalAlignment(SwingConstants.RIGHT);
		calculationProcessField.setColumns(10);
		calculationProcessField.setEditable(false);
		
		GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, groupLayout.createSequentialGroup()
					.addContainerGap()
					.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING)
						.addComponent(calculationProcessField, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 460, Short.MAX_VALUE)
						.addComponent(inputNumberField, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 460, Short.MAX_VALUE)
						.addComponent(panel, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 460, Short.MAX_VALUE))
					.addContainerGap())
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, groupLayout.createSequentialGroup()
					.addContainerGap()
					.addComponent(calculationProcessField, GroupLayout.DEFAULT_SIZE, 33, Short.MAX_VALUE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(inputNumberField, GroupLayout.DEFAULT_SIZE, 84, Short.MAX_VALUE)
					.addPreferredGap(ComponentPlacement.UNRELATED)
					.addComponent(panel, GroupLayout.DEFAULT_SIZE, 408, Short.MAX_VALUE)
					.addContainerGap())
		);
		
		panel.setLayout(new GridLayout(0, 4, 3, 3));
		
		String[] str = {
				"CE", "C", "\u2190", "÷",
				"7", "8", "9", "×",
				"4", "5", "6", "-",
				"1", "2", "3", "+",
				"+/-", "0", ".", "="};
		buttons = new JButton[20];
		
		for(int i = 0; i < buttons.length; i++) {

			buttons[i] = new JButton(str[i]);
			buttons[i].setFont(new Font("굴림", Font.PLAIN, 30));
			buttons[i].addActionListener(this);
			panel.add(buttons[i]);
		}
		
		frame.getContentPane().setLayout(groupLayout);

		frame.setVisible(true);	
		//new ViewCalculator();
	}

	public void actionPerformed(ActionEvent e) {
		/*if(c == 5) { // 연산자가 = 일 경우, 위의 로그 값 모두 초기화
			calculationProcessString = "";
			calculationProcessField.setText(null);			
		}*/
		if(e.getActionCommand().equals("C")) { // 연산자 기록까지 초기화

			calculationProcessString = "";
			calculationProcessField.setText(null);	
			inputNumberField.setText("0");
			a = -1;
			c = 0;
			lastInput = 0;
			
		} else if(e.getActionCommand().equals("CE")) { // 연산자 기록은 그대로
			
			inputNumberField.setText("0");
			a = -1;
			
		} else if(e.getActionCommand().equals("+")) {			
			if(isInputOperator) { // 앞에가 연산자였으면, 
				//calculationProcessField.setText(calculationProcessString + "-");
			}
			else if(a != -1) {
				b = Integer.valueOf(inputNumberField.getText());
				inputNumberField.setText(arithmetic());
				calculationProcessString += b;
				a = Integer.valueOf(inputNumberField.getText());
			}
			else {
				a = Integer.valueOf(inputNumberField.getText());
				calculationProcessString += a;
			}
			
			calculationProcessField.setText(calculationProcessString + "+");

			//inputNumberField.setText("0");
			isInputOperator = true;
			c = 1;lastInput = 1;

		} else if(e.getActionCommand().equals("-")) {
			if(isInputOperator) { // 앞에가 연산자였으면, 
				//calculationProcessField.setText(calculationProcessString + "-");
			}
			else if(a != -1) {
				b = Integer.valueOf(inputNumberField.getText());
				inputNumberField.setText(arithmetic());
				calculationProcessString += b;
				a = Integer.valueOf(inputNumberField.getText());
			}
			else {
				a = Integer.valueOf(inputNumberField.getText());
				calculationProcessString += a;
			}
			calculationProcessField.setText(calculationProcessString + "-");
			//inputNumberField.setText("0");
			isInputOperator = true;
			c = 2;lastInput = 2;

		} else if(e.getActionCommand().equals("×")) {
			if(isInputOperator) { // 앞에가 연산자였으면, 
				//calculationProcessField.setText(calculationProcessString + "-");
			}
			else if(a != -1) {
				b = Integer.valueOf(inputNumberField.getText());
				inputNumberField.setText(arithmetic());
				calculationProcessString += b;
				a = Integer.valueOf(inputNumberField.getText());
			}
			else {
				a = Integer.valueOf(inputNumberField.getText());
				calculationProcessString += a;
			}
			calculationProcessField.setText(calculationProcessString + "x");
			a = Integer.valueOf(inputNumberField.getText());
			//inputNumberField.setText("0");
			isInputOperator = true;
			c = 3;lastInput = 3;

		} else if(e.getActionCommand().equals("÷")) {
			if(isInputOperator) { // 앞에가 연산자였으면, 
				//calculationProcessField.setText(calculationProcessString + "-");
			}
			else if(a != -1) {
				b = Integer.valueOf(inputNumberField.getText());//a = Integer.valueOf(inputNumberField.getText());
				inputNumberField.setText(arithmetic());
				calculationProcessString += b;
			}
			else {
				a = Integer.valueOf(inputNumberField.getText());
				calculationProcessString += a;
			}
			a = Integer.valueOf(inputNumberField.getText());
			calculationProcessField.setText(calculationProcessString + "÷");
			//inputNumberField.setText("0");
			isInputOperator = true;
			c = 4;lastInput = 4;

		} else if(e.getActionCommand().equals("=")) {
			if(isInputOperator) { // 앞에가 연산자였으면, 
				if(lastInput != 5) {
					b = Integer.valueOf(inputNumberField.getText());//a;					
				}
				calculationProcessString = String.valueOf(a);
				arithmetic();
				calculationProcessString += String.valueOf(b) + "=";
				calculationProcessField.setText(calculationProcessString);
			}
			else if(a != -1) {
				b = Integer.valueOf(inputNumberField.getText());
				inputNumberField.setText(arithmetic());
				calculationProcessString = "";
				calculationProcessField.setText(null);
			}		
				a = Integer.valueOf(inputNumberField.getText());
			
			
			isInputOperator = true;
			//a = 0;
			//c= 5;
			lastInput = 5;
		} else {
			if(isInputOperator) {
				inputNumberField.setText(null);
			}
			isInputOperator = false;

			if(inputNumberField.getText().equals("0")) {

				inputNumberField.setText(null);

				inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());

			} else {

				inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());

			}

		}

	}

	boolean isOperator() {
		//if()
		return true;
	}
	String arithmetic() {
		switch(c) {
		case 1 : inputNumberField.setText(String.valueOf(a + b)); calculationProcessString += "+";return String.valueOf(a + b);
		case 2 : inputNumberField.setText(String.valueOf(a - b)); calculationProcessString += "-";return String.valueOf(a - b);
		case 3 : inputNumberField.setText(String.valueOf(a * b)); calculationProcessString += "x";return String.valueOf(a * b);
		case 4 : inputNumberField.setText(String.valueOf(a / b)); calculationProcessString += "÷";return String.valueOf(a / b);
		}
		return "";
	}
	void init() {

		frame = new JFrame("계산기");
		frame.setContentPane(this);
		frame.pack();
		frame.setResizable(false);
		frame.setLocationRelativeTo(null);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true);

	}
}
