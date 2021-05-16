import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

@SuppressWarnings("serial")
public class StartProgram extends JPanel implements ActionListener {

	JFrame frame;

	JPanel p1, p2;

	JTextField jtf;
	JButton[] btns;

	int a = 0, b = 0, c = 0;

	public StartProgram() {

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

	}

	public void actionPerformed(ActionEvent e) {

		if(e.getActionCommand().equals("C")) {

			jtf.setText("0");

		} else if(e.getActionCommand().equals("+")) {

			a = Integer.valueOf(jtf.getText());

			jtf.setText("0");
			
			c = 1;

		} else if(e.getActionCommand().equals("-")) {

			a = Integer.valueOf(jtf.getText());

			jtf.setText("0");

			c = 2;

		} else if(e.getActionCommand().equals("=")) {

			if(a != 0) {

				b = Integer.valueOf(jtf.getText());

				switch(c) {
				case 1 : jtf.setText(String.valueOf(a + b)); break;
				case 2 : jtf.setText(String.valueOf(a - b)); break;
				case 3 : jtf.setText(String.valueOf(a * b)); break;
				case 4 : jtf.setText(String.valueOf(a / b)); break;
				}

			}

		} else if(e.getActionCommand().equals("¡¿")) {

			a = Integer.valueOf(jtf.getText());

			jtf.setText("0");

			c = 3;

		} else if(e.getActionCommand().equals("¡À")) {

			a = Integer.valueOf(jtf.getText());

			jtf.setText("0");

			c = 4;

		} else {

			if(jtf.getText().equals("0")) {

				jtf.setText(null);

				jtf.setText(jtf.getText() + e.getActionCommand());

			} else {

				jtf.setText(jtf.getText() + e.getActionCommand());

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

	public static void main(String[] args) {

		new StartProgram();

	}

}