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

	private JFrame frame;
	private JTextField textField;
	private JTextField textField_1;
	private JButton[] buttons;
	//JFrame frame;

	//JPanel p1, p2;

	//JTextField jtf;
	JButton[] btns;

	int a = 0, b = 0, c = 0;

	public CalculateNumber() {
		frame = new JFrame("°è»ê±â");
		frame.setBounds(100, 100, 500, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel panel = new JPanel();
		
		textField = new JTextField();
		textField.setHorizontalAlignment(SwingConstants.RIGHT);
		textField.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		textField.setColumns(10);
		textField.setEditable(false);
		
		textField_1 = new JTextField();
		textField_1.setHorizontalAlignment(SwingConstants.RIGHT);
		textField_1.setColumns(10);
		textField_1.setEditable(false);
		
		GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, groupLayout.createSequentialGroup()
					.addContainerGap()
					.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING)
						.addComponent(textField_1, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 460, Short.MAX_VALUE)
						.addComponent(textField, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 460, Short.MAX_VALUE)
						.addComponent(panel, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 460, Short.MAX_VALUE))
					.addContainerGap())
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, groupLayout.createSequentialGroup()
					.addContainerGap()
					.addComponent(textField_1, GroupLayout.DEFAULT_SIZE, 33, Short.MAX_VALUE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(textField, GroupLayout.DEFAULT_SIZE, 84, Short.MAX_VALUE)
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
		/*
		setPreferredSize(new Dimension(500, 600));
		setBorder(BorderFactory.createEmptyBorder(4, 4, 4, 4));
		setLayout(new BorderLayout());
		

		p1 = new JPanel(new BorderLayout());


		p2 = new JPanel();
		p2.setLayout(new GridLayout(4, 4, 2, 2));

		String[] str = {
				"C", "+", "-", "¡¿",
				"7", "8", "9", "¡À",
				"4", "5", "6", "=",
				"1", "2", "3", "0"};

		btns = new JButton[16];

		for(int i = 0; i < btns.length; i++) {

			btns[i] = new JButton(str[i]);
			btns[i].addActionListener(this);

			p2.add(btns[i]);

		}

		jtf = new JTextField(10);
		jtf.setEditable(false);
		jtf.setText("0");

		p1.add(jtf);

		add(BorderLayout.NORTH, p1);
		add(BorderLayout.CENTER, p2);
		
		init();
		*/
		
	}

	public void actionPerformed(ActionEvent e) {
		if(e.getActionCommand().equals("C")) {

			textField.setText("0");

		} else if(e.getActionCommand().equals("+")) {

			a = Integer.valueOf(textField.getText());

			textField.setText("0");
			
			c = 1;

		} else if(e.getActionCommand().equals("-")) {

			a = Integer.valueOf(textField.getText());

			textField.setText("0");

			c = 2;

		} else if(e.getActionCommand().equals("=")) {

			if(a != 0) {

				b = Integer.valueOf(textField.getText());

				switch(c) {
				case 1 : textField.setText(String.valueOf(a + b)); break;
				case 2 : textField.setText(String.valueOf(a - b)); break;
				case 3 : textField.setText(String.valueOf(a * b)); break;
				case 4 : textField.setText(String.valueOf(a / b)); break;
				}

			}

		} else if(e.getActionCommand().equals("¡¿")) {

			a = Integer.valueOf(textField.getText());

			textField.setText("0");

			c = 3;

		} else if(e.getActionCommand().equals("¡À")) {

			a = Integer.valueOf(textField.getText());

			textField.setText("0");

			c = 4;

		} else {

			if(textField.getText().equals("0")) {

				textField.setText(null);

				textField.setText(textField.getText() + e.getActionCommand());

			} else {

				textField.setText(textField.getText() + e.getActionCommand());

			}

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
