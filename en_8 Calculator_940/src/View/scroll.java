package View;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.LayoutStyle.ComponentPlacement;
import java.awt.GridLayout;
import javax.swing.JButton;
import javax.swing.JScrollPane;
import javax.swing.JTable;

public class scroll {

	private JFrame frame;
	private JTextField textField;
	private JTextField textField_1;
	private JPanel panel_1;
	private JButton btnNewButton;
	private JButton btnNewButton_1;
	private JButton btnNewButton_2;
	private JButton btnNewButton_3;
	private JButton btnNewButton_4;
	private JButton btnNewButton_5;
	private JButton btnNewButton_6;
	private JButton btnNewButton_7;
	private JScrollPane scrollPane;
	private JTable table;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					scroll window = new scroll();
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
	public scroll() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 500, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel panel = new JPanel();
		
		scrollPane = new JScrollPane();
		GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addContainerGap()
					.addComponent(panel, GroupLayout.PREFERRED_SIZE, 254, Short.MAX_VALUE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(scrollPane, GroupLayout.PREFERRED_SIZE, 149, GroupLayout.PREFERRED_SIZE)
					.addContainerGap())
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, groupLayout.createSequentialGroup()
					.addContainerGap()
					.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING)
						.addComponent(scrollPane, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 241, Short.MAX_VALUE)
						.addComponent(panel, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 241, Short.MAX_VALUE))
					.addContainerGap())
		);
		
		table = new JTable();
		scrollPane.setColumnHeaderView(table);
		
		textField = new JTextField();
		textField.setColumns(10);
		
		textField_1 = new JTextField("aa");
		textField_1.setColumns(10);
		
		panel_1 = new JPanel();
		GroupLayout gl_panel = new GroupLayout(panel);
		gl_panel.setHorizontalGroup(
			gl_panel.createParallelGroup(Alignment.TRAILING)
				.addGroup(gl_panel.createSequentialGroup()
					.addContainerGap()
					.addGroup(gl_panel.createParallelGroup(Alignment.TRAILING)
						.addComponent(panel_1, Alignment.LEADING, GroupLayout.PREFERRED_SIZE, 232, Short.MAX_VALUE)
						.addComponent(textField_1, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 232, Short.MAX_VALUE)
						.addComponent(textField, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 232, Short.MAX_VALUE))
					.addGap(10))
		);
		gl_panel.setVerticalGroup(
			gl_panel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_panel.createSequentialGroup()
					.addContainerGap()
					.addComponent(textField, GroupLayout.PREFERRED_SIZE, 21, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(textField_1, GroupLayout.PREFERRED_SIZE, 29, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(panel_1, GroupLayout.DEFAULT_SIZE, 159, Short.MAX_VALUE)
					.addContainerGap())
		);
		panel_1.setLayout(new GridLayout(0, 4, 0, 0));
		
		btnNewButton_1 = new JButton("New button");
		panel_1.add(btnNewButton_1);
		
		btnNewButton_4 = new JButton("New button");
		panel_1.add(btnNewButton_4);
		
		btnNewButton_2 = new JButton("New button");
		panel_1.add(btnNewButton_2);
		
		btnNewButton_3 = new JButton("New button");
		panel_1.add(btnNewButton_3);
		
		btnNewButton = new JButton("New button");
		panel_1.add(btnNewButton);
		
		btnNewButton_5 = new JButton("New button");
		panel_1.add(btnNewButton_5);
		
		btnNewButton_6 = new JButton("New button");
		panel_1.add(btnNewButton_6);
		
		btnNewButton_7 = new JButton("New button");
		panel_1.add(btnNewButton_7);
		panel.setLayout(gl_panel);
		frame.getContentPane().setLayout(groupLayout);
	}
}
