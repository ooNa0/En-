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


	
	JButton[] btns;

	int a = 0, b = 0, c = 0;
	String lastInput;

	public CalculateNumber() {
		frame = new JFrame("°è»ê±â");
		frame.setBounds(100, 100, 500, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel panel = new JPanel();
		
		inputNumberField = new JTextField("0");
		inputNumberField.setHorizontalAlignment(SwingConstants.RIGHT);
		inputNumberField.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		inputNumberField.setColumns(10);
		inputNumberField.setEditable(false);
		
		calculationProcessField = new JTextField();
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
				"CE", "C", "\u2190", "¡À",
				"7", "8", "9", "¡¿",
				"4", "5", "6", "-",
				"1", "2", "3", "+",
				"+/-", "0", ".", "="};
		buttons = new JButton[20];
		
		for(int i = 0; i < buttons.length; i++) {

			buttons[i] = new JButton(str[i]);
			buttons[i].setFont(new Font("±¼¸²", Font.PLAIN, 30));
			buttons[i].addActionListener(this);
			panel.add(buttons[i]);
		}
		
		frame.getContentPane().setLayout(groupLayout);

		frame.setVisible(true);	
		//new ViewCalculator();
	}

	public void actionPerformed(ActionEvent e) {
		if(e.getActionCommand().equals("C")) {
			
			calculationProcessString = "0";
			calculationProcessField.setText(calculationProcessString);
			inputNumberField.setText("0");
			a = -1;
			
		} else if(e.getActionCommand().equals("CE")) {	
			
			inputNumberField.setText("0");
			
		} else if(e.getActionCommand().equals("+")) {
			if(a != -1) {
				arithmetic();
			}
			a = Integer.valueOf(inputNumberField.getText());

			calculationProcessString += a + "+";
			calculationProcessField.setText(calculationProcessString);
			//inputNumberField.setText("0");
			
			c = 1;

		} else if(e.getActionCommand().equals("-")) {
			if(a != -1) {
				arithmetic();
			}
			a = Integer.valueOf(inputNumberField.getText());
			calculationProcessString += a + "-";
			calculationProcessField.setText(calculationProcessString);
			//inputNumberField.setText("0");

			c = 2;

		} else if(e.getActionCommand().equals("=")) {

			if(a != -1) {
				arithmetic();
				calculationProcessString = null;
				calculationProcessField.setText(calculationProcessString);
			}
			else {
				a = Integer.valueOf(inputNumberField.getText());
				calculationProcessString = a+"=";
				calculationProcessField.setText(calculationProcessString);
			}

		} else if(e.getActionCommand().equals("¡¿")) {
			if(a != -1) {
				arithmetic();
			}
			a = Integer.valueOf(inputNumberField.getText());
			calculationProcessString += a + "x";
			calculationProcessField.setText(calculationProcessString);
			//inputNumberField.setText("0");

			c = 3;

		} else if(e.getActionCommand().equals("¡À")) {
			if(a != -1) {
				arithmetic();
			}
			a = Integer.valueOf(inputNumberField.getText());
			calculationProcessString += a + "¡À";
			calculationProcessField.setText(calculationProcessString);
			//inputNumberField.setText("0");

			c = 4;

		} else {

			//if(inputNumberField.getText().equals("0")) {

			//	inputNumberField.setText(null);

				inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());

			//} else {

			//	inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());

			//}

		}

	}

	boolean isOperator() {
		//if()
		return true;
	}
	void arithmetic() {
		b = Integer.valueOf(inputNumberField.getText());

		switch(c) {
		case 1 : inputNumberField.setText(String.valueOf(a + b)); break;
		case 2 : inputNumberField.setText(String.valueOf(a - b)); break;
		case 3 : inputNumberField.setText(String.valueOf(a * b)); break;
		case 4 : inputNumberField.setText(String.valueOf(a / b)); break;
		}
	}
	void init() {

		frame = new JFrame("°è»ê±â");
		frame.setContentPane(this);
		frame.pack();
		frame.setResizable(false);
		frame.setLocationRelativeTo(null);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true);

	}
}
