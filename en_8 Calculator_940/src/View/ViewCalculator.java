package View;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.LayoutStyle.ComponentPlacement;
import java.awt.GridBagLayout;
import javax.swing.JButton;
import java.awt.GridBagConstraints;
import java.awt.Insets;
import java.awt.*;
import java.awt.event.*;

import javax.swing.*;


public class ViewCalculator {

	private JFrame frame;
	private JTextField textField;
	private JTextField textField_1;
	private JButton[] buttons;

	/**
	 * Launch the application.
	 */
	/**
	 * Create the application.
	 */
	public ViewCalculator() {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ViewCalculator window = new ViewCalculator();
					window.frame.setVisible(true);					
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
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
			buttons[i].addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
				}
			});
			panel.add(buttons[i]);
		}
		panel.setLayout(new GridLayout(0, 4, 3, 3));
		/*
		JButton btnNewButton = new JButton("CE");
		btnNewButton.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		panel.add(btnNewButton);
				
		JButton btnC = new JButton("C");
		btnC.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnC);
		
		JButton btnNewButton_1 = new JButton("\u2190");
		btnNewButton_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		btnNewButton_1.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_1);
		
		JButton btnNewButton_2 = new JButton("¡À");
		btnNewButton_2.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_2);
		
		JButton btnNewButton_3 = new JButton("7");
		btnNewButton_3.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_3);
		
		JButton btnNewButton_17 = new JButton("8");
		btnNewButton_17.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17);
		
		JButton btnNewButton_18 = new JButton("9");
		btnNewButton_18.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_18);
		
		JButton btnX = new JButton("\u00D7");
		btnX.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		btnX.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnX);
		
		JButton btnNewButton_17_4 = new JButton("4");
		btnNewButton_17_4.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_4);
		
		JButton btnNewButton_17_2 = new JButton("5");
		btnNewButton_17_2.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_2);
		
		JButton btnNewButton_17_3 = new JButton("6");
		btnNewButton_17_3.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_3);
		
		JButton btnNewButton_17_1 = new JButton("\u2212");
		btnNewButton_17_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		btnNewButton_17_1.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_1);
		
		JButton btnNewButton_17_8 = new JButton("1");
		btnNewButton_17_8.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_8);
		
		JButton btnNewButton_17_2_1 = new JButton("2");
		btnNewButton_17_2_1.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_2_1);
		
		JButton btnNewButton_17_5 = new JButton("3");
		btnNewButton_17_5.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_5);
		
		JButton btnNewButton_17_6 = new JButton("+");
		btnNewButton_17_6.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_6);
		
		JButton btnNewButton_17_7 = new JButton("+/-");
		btnNewButton_17_7.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_7);
		
		JButton btnNewButton_17_2_2 = new JButton("0");
		btnNewButton_17_2_2.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_2_2);
		
		JButton btnNewButton_17_2_3 = new JButton(".");
		btnNewButton_17_2_3.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_2_3);
		
		JButton btnNewButton_17_2_4 = new JButton("=");
		btnNewButton_17_2_4.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		btnNewButton_17_2_4.setFont(new Font("±¼¸²", Font.PLAIN, 30));
		panel.add(btnNewButton_17_2_4);
		*/
		frame.getContentPane().setLayout(groupLayout);
	}
}
