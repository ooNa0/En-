package View;

import java.awt.Color;
import java.awt.Font;
import java.awt.GridLayout;

import javax.swing.GroupLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;
import javax.swing.table.DefaultTableModel;

import Model.Constant;

public class SetCalculator {
	
	private JFrame frame;
	private JPanel panel;
	private DefaultTableModel model;
	private JTable table;
	private JScrollPane scrollPane;
	private JTextField inputNumberField;
	private JTextField calculationProcessField;
	public JButton[] buttons;
	
	public void initialize() {
		frame = new JFrame("9계산기0");
		frame.setBounds(100, 100, 550, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		panel = new JPanel();
		
		// 기록
		String[] columnName = new String[] { "계산 기록" };
		model = new DefaultTableModel(columnName, 0) {
			@Override
			public boolean isCellEditable(int row, int column) {
				return false;
			} // 수정 못하게
		};
		table = new JTable(model);
		scrollPane = new JScrollPane(table);
		
		GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		groupLayout
				.setHorizontalGroup(
						groupLayout.createParallelGroup(Alignment.LEADING)
								.addGroup(groupLayout.createSequentialGroup().addContainerGap()
										.addComponent(panel, GroupLayout.PREFERRED_SIZE, 254, Short.MAX_VALUE)
										.addPreferredGap(ComponentPlacement.RELATED).addComponent(scrollPane,
												GroupLayout.PREFERRED_SIZE, 149, GroupLayout.PREFERRED_SIZE)
										.addContainerGap()));
		groupLayout.setVerticalGroup(groupLayout.createParallelGroup(Alignment.LEADING).addGroup(Alignment.TRAILING,
				groupLayout.createSequentialGroup().addContainerGap()
						.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING)
								.addComponent(scrollPane, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 241,
										Short.MAX_VALUE)
								.addComponent(panel, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 241, Short.MAX_VALUE))
						.addContainerGap()));
		
		inputNumberField = new JTextField(Constant.DEFAULT_VALUE);
		inputNumberField.setHorizontalAlignment(SwingConstants.RIGHT);
		inputNumberField.setFont(new Font("굴림", Font.PLAIN, 15));
		inputNumberField.setColumns(10);
		inputNumberField.setEditable(false);

		calculationProcessField = new JTextField(" ");
		calculationProcessField.setHorizontalAlignment(SwingConstants.RIGHT);
		calculationProcessField.setFont(new Font("굴림", Font.PLAIN, 15));
		calculationProcessField.setColumns(10);
		calculationProcessField.setEditable(false);
		
		JPanel panel_1 = new JPanel();
		GroupLayout gl_panel = new GroupLayout(panel);
		gl_panel.setHorizontalGroup(gl_panel.createParallelGroup(Alignment.TRAILING).addGroup(gl_panel
				.createSequentialGroup().addContainerGap()
				.addGroup(gl_panel.createParallelGroup(Alignment.TRAILING)
						.addComponent(panel_1, Alignment.LEADING, GroupLayout.PREFERRED_SIZE, 230, Short.MAX_VALUE)
						.addComponent(inputNumberField, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 230,
								Short.MAX_VALUE)
						.addComponent(calculationProcessField, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 230,
								Short.MAX_VALUE))
				.addContainerGap()));
		gl_panel.setVerticalGroup(gl_panel.createParallelGroup(Alignment.LEADING).addGroup(gl_panel
				.createSequentialGroup().addContainerGap()
				.addComponent(calculationProcessField, GroupLayout.PREFERRED_SIZE, 29, GroupLayout.PREFERRED_SIZE)
				.addPreferredGap(ComponentPlacement.RELATED)
				.addComponent(inputNumberField, GroupLayout.PREFERRED_SIZE, 29, GroupLayout.PREFERRED_SIZE)
				.addPreferredGap(ComponentPlacement.RELATED)
				.addComponent(panel_1, GroupLayout.DEFAULT_SIZE, 159, Short.MAX_VALUE).addContainerGap()));

			panel_1.setLayout(new GridLayout(0, 4, 3, 3));
			String[] str = { "CE", "C", "\u2190", "÷", "7", "8", "9", "×", "4", "5", "6", "-", "1", "2", "3", "+", "±", "0",
					".", "=" };
			buttons = new JButton[20];
			// panel_1.addKeyListener(this);
			for (int i = 0; i < buttons.length; i++) {

				buttons[i] = new JButton(str[i]);
				buttons[i].setFont(new Font("굴림", Font.PLAIN, 30));
				if((i == 4)||(i == 5)||(i == 6)||(i == 8)||(i == 9)||(i == 10)||(i == 12)||(i == 13)||(i == 14)||(i == 17)) {
					buttons[i].setBackground(new Color(255, 255, 255));
				}
				else{
					buttons[i].setBackground(new Color(230, 230, 230));
				}
				buttons[i].addActionListener(this);
				buttons[i].addKeyListener(this);
				panel_1.add(buttons[i]);
			}
			panel.setLayout(gl_panel);
	}
}
