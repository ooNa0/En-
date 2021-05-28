package View;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;

import javax.swing.JFrame;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.LayoutStyle.ComponentPlacement;

import Controller.InputManagement;

import javax.swing.JButton;
import javax.swing.JTable;
import javax.swing.JTextField;
import java.awt.GridLayout;

public class SetCalculatorService {

	private JFrame frame;
	private JTable table;
	private JTextField textField;
	private JTextField textField_1;
	public JButton[] buttons;
	private JTable table_1;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					SetCalculatorService window = new SetCalculatorService();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public SetCalculatorService() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 595, 560);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel panel = new JPanel();
		
		JScrollPane scrollPane = new JScrollPane();
		
		JButton btnNewButton = new JButton("New button");
		GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addContainerGap()
					.addComponent(panel, GroupLayout.DEFAULT_SIZE, 257, Short.MAX_VALUE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING)
						.addComponent(btnNewButton, GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE)
						.addComponent(scrollPane, GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE))
					.addContainerGap())
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addContainerGap()
					.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
						.addGroup(groupLayout.createSequentialGroup()
							.addComponent(scrollPane, GroupLayout.DEFAULT_SIZE, 472, Short.MAX_VALUE)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(btnNewButton, GroupLayout.DEFAULT_SIZE, 23, Short.MAX_VALUE)
							.addContainerGap())
						.addComponent(panel, Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 511, Short.MAX_VALUE)))
		);
		
		textField = new JTextField();
		textField.setColumns(10);
		
		textField_1 = new JTextField();
		textField_1.setColumns(10);
		
		JPanel panel_1 = new JPanel();
		GroupLayout gl_panel = new GroupLayout(panel);
		gl_panel.setHorizontalGroup(
			gl_panel.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, gl_panel.createSequentialGroup()
					.addContainerGap()
					.addGroup(gl_panel.createParallelGroup(Alignment.TRAILING)
						.addComponent(panel_1, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 233, Short.MAX_VALUE)
						.addComponent(textField_1, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 233, Short.MAX_VALUE)
						.addComponent(textField, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 233, Short.MAX_VALUE))
					.addContainerGap())
		);
		gl_panel.setVerticalGroup(
			gl_panel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_panel.createSequentialGroup()
					.addContainerGap()
					.addComponent(textField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(textField_1, GroupLayout.DEFAULT_SIZE, 48, Short.MAX_VALUE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(panel_1, GroupLayout.DEFAULT_SIZE, 400, Short.MAX_VALUE)
					.addContainerGap())
		);
		panel_1.setLayout(new GridLayout(0, 4, 0, 0));
		
		JButton button = new JButton("New button");
		panel_1.add(button);
		
		String[] str = { "CE", "C", "\u2190", "¡À", "7", "8", "9", "¡¿", "4", "5", "6", "-", "1", "2", "3", "+", "¡¾", "0",
				".", "=" };
		buttons = new JButton[20];
		// panel_1.addKeyListener(this);
		for (int i = 0; i < buttons.length; i++) {

			buttons[i] = new JButton(str[i]);
			buttons[i].setFont(new Font("±¼¸²", Font.PLAIN, 30));
			if ((i == 4) || (i == 5) || (i == 6) || (i == 8) || (i == 9) || (i == 10) || (i == 12) || (i == 13)
					|| (i == 14) || (i == 17)) {
				buttons[i].setBackground(new Color(255, 255, 255));
			} else {
				buttons[i].setBackground(new Color(230, 230, 230));
			}
			buttons[i].addActionListener(new InputManagement());
			buttons[i].addKeyListener(new InputManagement());
			panel_1.add(buttons[i]);
		}
		panel.setLayout(gl_panel);
		
		table = new JTable();
		scrollPane.setColumnHeaderView(table);
		
		table_1 = new JTable();
		scrollPane.setViewportView(table_1);
		frame.getContentPane().setLayout(groupLayout);
	}
}
