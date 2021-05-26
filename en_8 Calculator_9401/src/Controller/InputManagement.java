package Controller;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;
import java.awt.event.FocusListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Locale;

import javax.swing.GroupLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.border.Border;
import javax.swing.table.DefaultTableModel;

import Model.CalculateManagement;
import Model.Constant;
import View.SetCalculator;

import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;

public class InputManagement extends JFrame implements ActionListener, KeyListener, ComponentListener {

	private JFrame frame;
	private String calculationProcessString = "";
	private JTextField inputNumberField;
	private JTextField calculationProcessField;
	private int operator = 0;
	private boolean negatecheck = false;
	private boolean isInputOperator = false;
	private int lastInput = 0;
	private boolean isFristInput = true;
	public JButton[] buttons;
	private BigDecimal firstOperand; // 오차가 안생기게 하기 위해서는 string 값으로 선언 필요
	private BigDecimal secondOperand = BigDecimal.ZERO; // 오차가 안생기게 하기 위해서는 string 값으로 선언 필요
	private DefaultTableModel model;
	private String[] row = new String[1];
	private CalculateManagement calculate;
	private SetCalculator setting;
	private String inputnegate = "";
	private boolean isBackspace = true;

	public InputManagement() {
		calculate = new CalculateManagement();
		setting = new SetCalculator();
	}

	public void initialize() {
		frame = new JFrame("나영's 계산기");
		frame.pack();
		frame.setBounds(100, 100, 458, 600);
		frame.addComponentListener(this);

		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setMinimumSize(new Dimension(458, 600));
		JPanel panel = new JPanel();

		String[] columnName = new String[] { "계산 기록" };
		model = new DefaultTableModel(columnName, 0) {
			@Override
			public boolean isCellEditable(int row, int column) {
				return false;
			}
		};
		JTable table = new JTable(model);
		JScrollPane scrollPane = new JScrollPane(table);

		JButton resetButton = new JButton("계산기록 초기화");
		resetButton.addActionListener(this);
		resetButton.setBackground(new Color(210, 210, 210));
		resetButton.setFont(new Font("굴림", Font.BOLD, 20));
		GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		groupLayout.setHorizontalGroup(groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup().addContainerGap()
						.addComponent(panel, GroupLayout.DEFAULT_SIZE, 257, Short.MAX_VALUE)
						.addPreferredGap(ComponentPlacement.RELATED)
						.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING)
								.addComponent(resetButton, GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE)
								.addComponent(scrollPane, GroupLayout.DEFAULT_SIZE, 146, Short.MAX_VALUE))
						.addContainerGap()));
		groupLayout.setVerticalGroup(groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup().addContainerGap()
						.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
								.addGroup(groupLayout.createSequentialGroup()
										.addComponent(scrollPane, GroupLayout.DEFAULT_SIZE, 472, Short.MAX_VALUE)
										.addPreferredGap(ComponentPlacement.RELATED)
										.addComponent(resetButton, GroupLayout.DEFAULT_SIZE, 23, Short.MAX_VALUE)
										.addContainerGap())
								.addComponent(panel, Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 511,
										Short.MAX_VALUE))));

		inputNumberField = setting.setTextField(Constant.DEFAULT_VALUE, 20);
		calculationProcessField = setting.setTextField(" ", 15);

		JPanel buttonPanel = new JPanel();
		GroupLayout bottonsGroupPanel = new GroupLayout(panel);
		bottonsGroupPanel.setHorizontalGroup(bottonsGroupPanel.createParallelGroup(Alignment.TRAILING)
				.addGroup(bottonsGroupPanel.createSequentialGroup().addContainerGap()
						.addGroup(bottonsGroupPanel.createParallelGroup(Alignment.TRAILING)
								.addComponent(buttonPanel, Alignment.LEADING, GroupLayout.PREFERRED_SIZE, 230,
										Short.MAX_VALUE)
								.addComponent(inputNumberField, Alignment.LEADING, 400, 400, Short.MAX_VALUE)
								.addComponent(calculationProcessField, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 230,
										Short.MAX_VALUE))
						.addContainerGap()));
		bottonsGroupPanel.setVerticalGroup(bottonsGroupPanel.createParallelGroup(Alignment.LEADING)
				.addGroup(bottonsGroupPanel.createSequentialGroup().addContainerGap()
						.addComponent(calculationProcessField, GroupLayout.PREFERRED_SIZE, 29,
								GroupLayout.PREFERRED_SIZE)
						.addPreferredGap(ComponentPlacement.RELATED)
						.addComponent(inputNumberField, GroupLayout.PREFERRED_SIZE, 29, GroupLayout.PREFERRED_SIZE)
						.addPreferredGap(ComponentPlacement.RELATED)
						.addComponent(buttonPanel, GroupLayout.DEFAULT_SIZE, 159, Short.MAX_VALUE).addContainerGap()));

		buttonPanel.setLayout(new GridLayout(0, 4, 3, 3));

		String[] str = { "CE", "C", "\u2190", "÷", "7", "8", "9", "×", "4", "5", "6", "-", "1", "2", "3", "+", "±", "0",
				".", "=" };
		buttons = new JButton[20];
		for (int i = 0; i < buttons.length; i++) {

			buttons[i] = new JButton(str[i]);
			buttons[i].setFont(new Font("굴림", Font.PLAIN, 30));
			if ((i == 4) || (i == 5) || (i == 6) || (i == 8) || (i == 9) || (i == 10) || (i == 12) || (i == 13)
					|| (i == 14) || (i == 17)) {
				buttons[i].setBackground(new Color(255, 255, 255));
			} else {
				buttons[i].setBackground(new Color(230, 230, 230));
			}
			/*
			 * buttons[i].addActionListener(new ActionListener() { public void
			 * actionPerformed(ActionEvent e) { //calculate.actionPerformed(e); } });
			 */
			// buttons[i].addActionListener(new EventHandler());
			buttons[i].addActionListener(this);
			buttons[i].addKeyListener(this);
			buttonPanel.add(buttons[i]);
		}
		buttonPanel.requestFocus();
		panel.setLayout(bottonsGroupPanel);
		frame.getContentPane().setLayout(groupLayout);
		buttons[3].requestFocusInWindow();
		frame.setVisible(true);
	}
			public void componentResized(ComponentEvent e) {}//resize();}
			public void componentHidden(ComponentEvent e) {}
			public void componentMoved(ComponentEvent e) {}
			public void componentShown(ComponentEvent e) {}
/*
	private void resize() {
		//while (true) {
			Font before = inputNumberField.getFont();
			int j = before.getSize();
			System.out.println(before.getSize());
			j++;
			inputNumberField.setFont(new Font(before.getName(), before.getStyle(), j)); // buttons[i].setFont(new Font("굴림", Font.PLAIN, 30));

			System.out.println(frame.getContentPane().getSize());
			System.out.println(getHeight());
			if (getPreferredSize().getWidth() > getWidth() || getPreferredSize().getHeight() > getHeight()) {
				j--;
				setFont(new Font(before.getName(), before.getStyle(), j - 1));
				//break;
			}
		//}
	}*/

	public void keyTyped(KeyEvent e) {
	}

	public void keyReleased(KeyEvent e) {
		if ((e.getModifiers() & 1) != 0) {
			if (e.getKeyCode() == 61) { buttons[15].doClick(); }
			if (e.getKeyCode() == 56) { buttons[7].doClick(); }
		} else {
			if (e.getKeyCode() == 56) { buttons[5].doClick(); }
			if (e.getKeyCode() == 61) { buttons[19].doClick(); }
		}
	}

	public void keyPressed(KeyEvent e) {
		switch (e.getKeyCode()) {
		case KeyEvent.VK_BACK_SPACE: buttons[2].doClick(); break;// 뒤로가기.
		case KeyEvent.VK_ENTER: buttons[19].doClick(); break; // 엔터
		case 27: buttons[1].doClick(); break; // esc// C
		case 127: buttons[0].doClick(); break;// delete // CE
		case 45: buttons[11].doClick();break; // - 버튼
		case 47: buttons[3].doClick(); break;// / 버튼
		case 46: buttons[18].doClick(); break;// .
		case 48: buttons[17].doClick(); break;
		case 49: buttons[12].doClick(); break;
		case 50: buttons[13].doClick(); break;
		case 51: buttons[14].doClick(); break;
		case 52: buttons[8].doClick(); break;
		case 53: buttons[9].doClick(); break;
		case 54: buttons[10].doClick(); break;
		case 55: buttons[4].doClick(); break;
		case 57: buttons[6].doClick(); break;
		}
	}

	public void actionPerformed(ActionEvent e) {

		if (e.getActionCommand().equals("C")) { // 연산자 기록까지 초기화

			calculationProcessString = "";
			calculationProcessField.setText(null);
			inputNumberField.setText(Constant.DEFAULT_VALUE);
			isFristInput = true;
			firstOperand = BigDecimal.ZERO;
			inputnegate = "";
			operator = 0;
			lastInput = 0;

		} else if (e.getActionCommand().equals("계산기록 초기화")) {

			model.setNumRows(0); // 기록 초기화

		} else if (e.getActionCommand().equals("CE")) { // 연산자 기록은 그대로
			
			inputNumberField.setText(Constant.DEFAULT_VALUE);
			inputnegate = "";

		} else if (e.getActionCommand().equals("\u2190")) { // 하나 지우기
			System.out.println(isInputOperator);
			if (!isInputOperator) {
				if (lastInput == Constant.EQUAL_NUMBER) {

					calculationProcessString = "";
					calculationProcessField.setText(null);

				} else {

					if (inputNumberField.getText().replaceAll("\\,", "").length() == Constant.MINIMUM_TEXT) {

						inputNumberField.setText(Constant.DEFAULT_VALUE);

					} else { // .2 지우기하면 . 되어야 하는데, .도 같이 지워짐
						//if(inputNumberField.getText().replaceAll("\\,", "").contains(".")) {
						//	inputNumberField.setText(new DecimalFormat("#,###,###,###,###.################").format(new BigDecimal(inputNumberField.getText().replaceAll("\\,", "").substring(0,inputNumberField.getText().replaceAll("\\,", "").length() - 1))));
						//}						
						//else{
							inputNumberField.setText(new DecimalFormat("#,###,###,###,###.################").format(new BigDecimal(inputNumberField.getText().replaceAll("\\,", "").substring(0,inputNumberField.getText().replaceAll("\\,", "").length() - 1))));
						//}
					}
				}
			}
			// 1 뒤로가기 후 negate안먹어야 댐
			isBackspace = true;

		} else if (e.getActionCommand().equals(".")) { // 소수점 붙이기!
			if (isInputOperator) {
				if (negatecheck)
					calculationProcessField.setText(calculationProcessString + calculate.operatorConversion(operator));
				inputNumberField.setText("0.");
			}
			if (!inputNumberField.getText().replaceAll("\\,", "").contains(".")) { // 텍스트 공간에 . 이 없을 경우에 추가가능!
				//inputNumberField.setText(new DecimalFormat("#,###,###,###,###.################").format(new BigDecimal(inputNumberField.getText().replaceAll("\\,", "")) + e.getActionCommand()));
				inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());
			}
			isInputOperator = false;
			isFristInput = true; // 0. 해주거 네게이트 시에 되어야 함.
			negatecheck = false;

		} else if (e.getActionCommand().equals("±")) { // +/- 버튼

			BigDecimal u = new BigDecimal(inputNumberField.getText().replaceAll("\\,", ""));
			//System.out.println("u =" + operator);
			// 앞에 연산자면 negate(~~) 필요하고, 아니라면 -만 붙었다 안붙었다//inputnegate
			if (isFristInput && !isBackspace) {
				isInputOperator = true;
			}
			if (isInputOperator) {
				if (negatecheck) {// 앞이 네게이트라면
					inputnegate = "negate(" + inputnegate + ")";
				} else {
					inputnegate = String.valueOf(u);
					inputnegate = "negate(" + inputnegate + ")";// negatecheck
					negatecheck = true;
				}
				if (operator == 0) {
					calculationProcessField.setText(inputnegate);
				} else {
					calculationProcessField.setText(calculationProcessString + calculate.operatorConversion(operator) + inputnegate);
				}
			} // e 나올 때 네게이트 부분			
			inputNumberField.setText(new DecimalFormat("#,###,###,###,###.################").format(u.negate()));

		} else if (e.getActionCommand().equals("+")) {
			fourRuleCalculation(1);
		} else if (e.getActionCommand().equals("-")) {
			fourRuleCalculation(2);
		} else if (e.getActionCommand().equals("×")) {
			fourRuleCalculation(3);
		} else if (e.getActionCommand().equals("÷")) {
			fourRuleCalculation(4);
		} else if (e.getActionCommand().equals("=")) {

			String resultArithmeticString = null;
			BigDecimal big = new BigDecimal(inputNumberField.getText().replaceAll("\\,", "")).stripTrailingZeros();
			//inputNumberField.setText(String.valueOf(big));
			if (isFristInput) { // 첫 입력이었을때에는 아무것도 없어야 함,, 그냥 동일한 값 계속 출력
				row[0] = String.valueOf(big);// + "=" + String.valueOf(big);
				calculationProcessString = String.valueOf(big);// + "=";
			} else {
				if (lastInput != Constant.EQUAL_NUMBER) {
					secondOperand = big;
				} else {
					firstOperand = big;
				}
				row[0] = firstOperand + calculate.operatorConversion(operator) + secondOperand;
				calculationProcessString = firstOperand + calculate.operatorConversion(operator);// + secondOperand;
			}
				BigDecimal resultArithmetic = calculate.arithmetic(operator, firstOperand, secondOperand, inputNumberField);
				if(resultArithmetic != null) {
					int maximum = 16;
					if (inputNumberField.getText().replaceAll("\\,", "").contains(".")) {
						maximum = 17;
					}
					if (resultArithmetic.toPlainString().length() > 16) { //maximum
						big = new BigDecimal(String.format("%.16e", resultArithmetic)).stripTrailingZeros();
						/*
						if (inputNumberField.getText().replaceAll("\\,", "").contains(".")) {
							big = new BigDecimal(String.format("%.17e", resultArithmetic)).stripTrailingZeros();
							//inputNumberField.setText(String.valueOf(new BigDecimal(String.format("%.17e", resultArithmetic)).stripTrailingZeros()));
						} 
						else {
							big = new BigDecimal(String.format("%.15e", resultArithmetic)).stripTrailingZeros();
							//inputNumberField.setText(String.valueOf(new BigDecimal(String.format("%.15e", resultArithmetic)).stripTrailingZeros()));
						}*/
					} 
					else {
						big = new BigDecimal(String.valueOf(inputNumberField.getText().replaceAll("\\,", ""))).stripTrailingZeros();
						inputNumberField.setText(new DecimalFormat("#,###,###,###,###.################").format(resultArithmetic));//.setScale(10, RoundingMode.HALF_UP)
					}
					inputNumberField.setText(String.valueOf(big));
					//big = new BigDecimal(inputNumberField.getText().replaceAll("\\,", "")).stripTrailingZeros();
					calculationProcessString += secondOperand;
					row[0] += "=" + big;
					calculationProcessString += "=";
				}

				
			isFristInput = false;
			lastInput = Constant.EQUAL_NUMBER;
			isInputOperator = true;			
			calculationProcessField.setText(calculationProcessString);
			calculationProcessString = "";
			model.addRow(row);
			negatecheck = false;

		} else {
			if (isInputOperator) { inputNumberField.setText(null); }
			isInputOperator = false;
			int maximum = 16;
			if (inputNumberField.getText().replaceAll("\\,", "").contains("."))
				maximum = 17;
			System.out.println(inputNumberField.getText().replaceAll("\\,", "").replaceAll("\\.", "").length());
			if (inputNumberField.getText().replaceAll("\\,", "").replaceAll("\\.", "").length() < maximum) {// Constant.MAXIMUM_TEXT
				if (inputNumberField.getText().replaceAll("\\,", "").equals(Constant.DEFAULT_VALUE)) {

					inputNumberField.setText(null);
					inputNumberField.setText(e.getActionCommand());

				} else {
					if (inputNumberField.getText().contains(".")) { // 콤마가 있을경우에는 그냥
						inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());

					} else {
						inputNumberField.setText(String.valueOf(new DecimalFormat("#,###,###,###,###.################").format(new BigDecimal(inputNumberField.getText().replaceAll("\\,", "") + e.getActionCommand()))));
					}
				}
			}
			negatecheck = false;
		}
	}

	void fourRuleCalculation(int calculateOperator) {
		BigDecimal big = new BigDecimal(String.valueOf(inputNumberField.getText().replaceAll("\\,", ""))).stripTrailingZeros();
		//inputNumberField.setText(String.valueOf(new DecimalFormat("#,###,###,###,###.################").format(big)));
		System.out.println("big =" + big);
		if (isFristInput || isInputOperator || calculationProcessString == "") { // 첫입력이거나, 전에 연산자였는지
			if (lastInput == Constant.EQUAL_NUMBER) {
				firstOperand = big;
				calculationProcessString += firstOperand;
			} else if (operator != calculateOperator) { // 동일 연산자 입력이 아니라면

				firstOperand = big;
				if (isFristInput)
					calculationProcessString += firstOperand;
			}
		} else { // 연산자를 입력받았는데, 앞에가 첫입력도 아닌데 숫자라면
			secondOperand = big;
			System.out.println("길이 : " + inputNumberField.getText().length());

			inputNumberField.setText(String.valueOf(new DecimalFormat("#,###,###,###,###.##############").format(calculate.arithmetic(operator, firstOperand, secondOperand, inputNumberField))));
			calculationProcessString = inputNumberField.getText();
			if (lastInput != Constant.EQUAL_NUMBER) {
				row[0] = firstOperand + calculate.operatorConversion(operator) + secondOperand + "=" + inputNumberField.getText();
				model.addRow(row);
			}
		}
		big = new BigDecimal(String.valueOf(inputNumberField.getText().replaceAll("\\,", ""))).stripTrailingZeros();
		System.out.println("firstOperand =" + firstOperand);
		firstOperand = big;
		System.out.println("firstOperand =" + firstOperand);
		operator = calculateOperator;
		calculationProcessField.setText(calculationProcessString + calculate.operatorConversion(operator));
		isInputOperator = true;
		isFristInput = false;
		negatecheck = false;
		lastInput = calculateOperator;
	}
}