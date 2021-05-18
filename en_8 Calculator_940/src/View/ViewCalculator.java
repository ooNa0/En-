package View;

import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;

import Controller.CalculateNumber;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;


@SuppressWarnings("serial")
public class ViewCalculator extends JPanel implements ActionListener {

	private JFrame frame;
	private JTextField inputNumberField;
	private JTextField calculationProcessField;
	private JButton[] buttons;
	private CalculateNumber calculate = new CalculateNumber();
	/**
	 * Launch the application.
	 */
	/**
	 * Create the application.
	 */
	public ViewCalculator() {
		//initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	public JFrame initialize() {
		frame = new JFrame("°è»ê±â");
		frame.setBounds(100, 100, 500, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel panel = new JPanel();
		
		inputNumberField = new JTextField("0");
		inputNumberField.setHorizontalAlignment(SwingConstants.RIGHT);
		inputNumberField.setFont(new Font("±¼¸²", Font.PLAIN, 30));
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
				"CE", "C", "\u2190", "¡À",
				"7", "8", "9", "¡¿",
				"4", "5", "6", "-",
				"1", "2", "3", "+",
				"+/-", "0", ".", "="};
		buttons = new JButton[20];
		
		for(int i = 0; i < buttons.length; i++) {

			buttons[i] = new JButton(str[i]);
			buttons[i].setFont(new Font("±¼¸²", Font.PLAIN, 30));
			/*buttons[i].addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					calculate.actionPerformed(e);
				}
			});*/
			//buttons[i].addActionListener(calculate.actionPerformed((ActionEvent e));
			panel.add(buttons[i]);
		}
		
		frame.getContentPane().setLayout(groupLayout);		

		frame.setVisible(true);	
		
		return frame;
	}

	
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		
	}
}
