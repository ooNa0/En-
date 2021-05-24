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

public class InputManagement extends JFrame implements ActionListener, KeyListener{

	private JFrame frame;
	private String calculationProcessString = "";
	private JTextField inputNumberField;
	private JTextField calculationProcessField;
	private int operator = 0;// a = -1, b = 0,
	private boolean negatecheck = false;
	private boolean isInputOperator;
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
	
	public InputManagement() {
		calculate = new CalculateManagement();
		setting = new SetCalculator();
		
	}//calculate.operatorConversion(operator)
	
	public void initialize() {
		frame = new JFrame("나영's 계산기");
		frame.pack();
		frame.setBounds(100, 100, 550, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLocationRelativeTo(null); // 정중앙에 띄우기
		/*
	        addComponentListener(new ComponentAdapter() {
	            @Override
	            public void componentResized(ComponentEvent e) {
	                //resize();
	            }
	        });
	    
	        int j=0;
	        while(true) {
	            Font before = getFont();
	            Font font = new Font(before.getName(), before.getStyle(), j);
	            setFont(font);
	            if(getPreferredSize().getWidth()>getWidth() || getPreferredSize().getHeight()>getHeight()) {
	                font = new Font(before.getName(), before.getStyle(), j-1);
	                setFont(font);
	                break;
	            }
	            j++;    
	        }
	    */
		JPanel panel = new JPanel();
		
		String[] columnName = new String[] { "계산 기록" };
		model = new DefaultTableModel(columnName, 0) {
			@Override
			public boolean isCellEditable(int row, int column) {
				if(row == 0 && column == 0) {
					model.setNumRows(0); // 기록 초기화
					model.addRow(new Object[] {"클릭 시, 계산 기록 초기화"});
				}
				return false;
			}
		};
		model.addRow(new Object[] {"클릭 시, 계산 기록 초기화"});
		JTable table = new JTable(model);
		JScrollPane scrollPane = new JScrollPane(table);
		setPanel();
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

		inputNumberField = setting.setTextField(Constant.DEFAULT_VALUE, 20);
		calculationProcessField = setting.setTextField(" ", 15);

		JPanel buttonpanel = new JPanel();
		GroupLayout gl_panel = new GroupLayout(panel);
		gl_panel.setHorizontalGroup(gl_panel.createParallelGroup(Alignment.TRAILING).addGroup(gl_panel
				.createSequentialGroup().addContainerGap()
				.addGroup(gl_panel.createParallelGroup(Alignment.TRAILING)
						.addComponent(buttonpanel, Alignment.LEADING, GroupLayout.PREFERRED_SIZE, 230, Short.MAX_VALUE)
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
				.addComponent(buttonpanel, GroupLayout.DEFAULT_SIZE, 159, Short.MAX_VALUE).addContainerGap()));

		buttonpanel.setLayout(new GridLayout(0, 4, 3, 3));

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
			buttonpanel.add(buttons[i]);
		}
		buttonpanel.requestFocus();
		panel.setLayout(gl_panel);
		frame.getContentPane().setLayout(groupLayout);
		buttons[3].requestFocusInWindow();
		frame.setVisible(true);
	}
	public void keyTyped(KeyEvent e) {
	}

	public void keyReleased(KeyEvent e) {
		if ((e.getModifiers() & 1) != 0) {
			if (e.getKeyCode() == 61) {
				buttons[15].doClick();
			}
			if (e.getKeyCode() == 56) {
				buttons[7].doClick();
			}
		} else {
			if (e.getKeyCode() == 56) {
				buttons[5].doClick();
			}
		}
	}

	public void keyPressed(KeyEvent e) {
		switch (e.getKeyCode()) {
		case KeyEvent.VK_BACK_SPACE:
			buttons[2].doClick(); // 뒤로가기.
			break;
		case KeyEvent.VK_ENTER: // 엔터
			buttons[19].doClick();
			break;
		case 27: // esc
			buttons[1].doClick(); // C
			break;
		case 127: // delete
			buttons[0].doClick(); // CE
			break;
		case 45: // - 버튼
			buttons[11].doClick();
			break;
		case 47: // / 버튼
			buttons[3].doClick();
			break;
		case 46: // .
			buttons[18].doClick();
			break;
		case 48: // 0
			buttons[17].doClick();
			break;
		case 49:
			buttons[12].doClick();
			break;
		case 50:
			buttons[13].doClick();
			break;
		case 51:
			buttons[14].doClick();
			break;
		case 52:
			buttons[8].doClick();
			break;
		case 53:
			buttons[9].doClick();
			break;
		case 54:
			buttons[10].doClick();
			break;
		case 55:
			buttons[4].doClick();
			break;
		case 57:
			buttons[6].doClick();
			break;
		}
	}

	public void actionPerformed(ActionEvent e) {

		if (e.getActionCommand().equals("C")) { // 연산자 기록까지 초기화

			calculationProcessString = "";
			calculationProcessField.setText(null);
			inputNumberField.setText(Constant.DEFAULT_VALUE);
			isFristInput = true;
			firstOperand = BigDecimal.ZERO;
			operator = 0;
			lastInput = 0;

		} else if (e.getActionCommand().equals("CE")) { // 연산자 기록은 그대로
			//firstOperand = new BigDecimal(String.valueOf(inputNumberField.getText().replaceAll("\\,", ""))).stripTrailingZeros();
			inputNumberField.setText(Constant.DEFAULT_VALUE);
			//firstOperand = BigDecimal.ZERO;
			//calculationProcessString = "";
			//calculationProcessField.setText(null);

		} else if (e.getActionCommand().equals("\u2190")) { // 하나 지우기
			if(!isInputOperator) {
				if(lastInput == Constant.EQUAL_NUMBER) {
					calculationProcessString = "";
					calculationProcessField.setText(null);
				}else {
					if (inputNumberField.getText().replaceAll("\\,", "").length() == Constant.MINIMUM_TEXT) {
						inputNumberField.setText(Constant.DEFAULT_VALUE);
					} else if (inputNumberField.getText().replaceAll("\\,", "").length() > Constant.MINIMUM_TEXT) {
						String a = inputNumberField.getText().replaceAll("\\,", "").substring(0,
								inputNumberField.getText().replaceAll("\\,", "").length() - 1);
						inputNumberField.setText(a);
					}				
				}
			}			

		} else if (e.getActionCommand().equals(".")) { // 소수점 붙이기!
			if(isInputOperator) {
				inputNumberField.setText("0.");
			}
			if (!inputNumberField.getText().contains(".")) { // 텍스트 공간에 . 이 없을 경우에 추가가능!
				String b = inputNumberField.getText().replaceAll("\\,", "");				
				b += ".";
				//b = new DecimalFormat("###,###.##").format(new BigDecimal(b));
				inputNumberField.setText(b);
				//inputNumberField.setText(new DecimalFormat("###,###.##").format(new BigDecimal(inputNumberField.getText().replaceAll("\\,", "") + e.getActionCommand())));
				
			}

		} else if (e.getActionCommand().equals("±")) { // +/- 버튼

			BigDecimal u = new BigDecimal(inputNumberField.getText().replaceAll("\\,", ""));
			System.out.println("u =" + u);
			// 앞에 연산자면 negate(~~) 필요하고, 아니라면 -만 붙었다 안붙었다//inputnegate
			if (isInputOperator) {
				if(negatecheck) {// 앞이 네게이트라면
					inputnegate = "negate(" + inputnegate + ")";
				}
				else {
					inputnegate = String.valueOf(u);
					inputnegate = "negate(" + inputnegate + ")";//negatecheck
					negatecheck = true;
				}
				calculationProcessField.setText(calculationProcessString + calculate.operatorConversion(operator) + inputnegate);//"negate(" + u + ")"
			}
			inputNumberField.setText(String.valueOf(u.negate()));////String.valueOf(u.multiply(BigDecimal.valueOf(-1))));
			//isInputOperator = true; // . 에,,
			// isFristInput = false;

		} else if (e.getActionCommand().equals("+")) {
			fourRuleCalculation(1);

		} else if (e.getActionCommand().equals("-")) {
			fourRuleCalculation(2);

		} else if (e.getActionCommand().equals("×")) {
			fourRuleCalculation(3);

		} else if (e.getActionCommand().equals("÷")) {
			fourRuleCalculation(4);

		} else if (e.getActionCommand().equals("=")) {
			String resultArithmetic = null;
			System.out.println("firstOperand =" + firstOperand);
			System.out.println("secondOperand =" + secondOperand);
			System.out.println("operator =" + operator);
			BigDecimal big = new BigDecimal(String.valueOf(inputNumberField.getText().replaceAll("\\,", ""))).stripTrailingZeros();
			//if(big.scale() < 0) big = big.setScale(0);
			//inputNumberField.setText(String.valueOf(big));
			if (isFristInput) { // 첫 입력이었을때에는 아무것도 없어야 함,, 그냥 동일한 값 계속 출력
				row[0] = String.valueOf(big);
				calculationProcessString = String.valueOf(big);
			} else {
				if (lastInput != Constant.EQUAL_NUMBER) {
					secondOperand = big;//new BigDecimal(inputNumberField.getText().replaceAll("\\,", "")).setScale(0);
				} else {
					firstOperand = big;//new BigDecimal(inputNumberField.getText().replaceAll("\\,", "")).setScale(0);
				}
				row[0] = firstOperand + calculate.operatorConversion(operator) + secondOperand;//inputNumberField.getText().replaceAll("\\,", "");
				calculationProcessString = firstOperand + calculate.operatorConversion(operator) + secondOperand;
				resultArithmetic = calculate.arithmetic(operator, firstOperand, secondOperand, inputNumberField);
			}
			if (resultArithmetic == null && isFristInput) {
				inputNumberField.setText(String.valueOf(big));
			}
			else {
				//inputNumberField.setText(resultArithmetic);
				isFristInput = false;
				lastInput = Constant.EQUAL_NUMBER;// operator = Constant.EQUAL_NUMBER;
				// if(isFristInput == false) isFristInput = true; else
			}
			isInputOperator = true;
			big = new BigDecimal(String.valueOf(inputNumberField.getText().replaceAll("\\,", ""))).stripTrailingZeros();
			row[0] += "=" + big;
			calculationProcessString += "=";
			System.out.println(calculationProcessString);
			calculationProcessField.setText(calculationProcessString);
			calculationProcessString = "";
			model.addRow(row);negatecheck = false;
			
		} else {
			if (isInputOperator) {
				inputNumberField.setText(null);
			}isInputOperator = false;
			if (inputNumberField.getText().replaceAll("\\,", "").length() < Constant.MAXIMUM_TEXT) {

				if (inputNumberField.getText().replaceAll("\\,", "").equals(Constant.DEFAULT_VALUE)) {

					inputNumberField.setText(null);
					System.out.println(e.getActionCommand());
					inputNumberField.setText(e.getActionCommand());

				} else {
					//NumberFormat nf = NumberFormat.getCurrencyInstance(Locale.KOREA);
					//nf.setMaximumFractionDigits(16);
					//if (inputNumberField.getText().contains(".")) { // 콤마가 있을경우에는 그냥
						//inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());
					//} else {
						//BigDecimal input = new BigDecimal(inputNumberField.getText().replaceAll("\\,", "") + e.getActionCommand());
						inputNumberField.setText(inputNumberField.getText().replaceAll("\\,", "") + e.getActionCommand());
					//}//new DecimalFormat("#,###,###,###,###.################").format(new BigDecimal(
				}
			}negatecheck = false;
		}
	}

	void fourRuleCalculation(int calculateOperator) {
		System.out.println("isFristInput =" + isFristInput);
		System.out.println("isInputOperator =" + isInputOperator);
		BigDecimal big = new BigDecimal(String.valueOf(inputNumberField.getText().replaceAll("\\,", ""))).stripTrailingZeros();
		//if(big.scale() < 0) big = big.setScale(0);
		//inputNumberField.setText(String.valueOf(big));
		if (isFristInput || isInputOperator || calculationProcessString == "") { // 첫입력이거나, 전에 연산자였는지
			if (lastInput == Constant.EQUAL_NUMBER) {
				firstOperand = big;//new BigDecimal(inputNumberField.getText().replaceAll("\\,", "")).stripTrailingZeros();
				calculationProcessString += firstOperand;
			} else if (operator != calculateOperator) { // 동일 연산자 입력이 아니라면
				firstOperand = big;//new BigDecimal(inputNumberField.getText().replaceAll("\\,", "")).stripTrailingZeros();
				if (isFristInput)
					calculationProcessString += firstOperand;
			}
		} else { // 연산자를 입력받았는데, 앞에가 첫입력도 아닌데 숫자라면
			secondOperand = big;//new BigDecimal(inputNumberField.getText().replaceAll("\\,", ""));
			inputNumberField.setText(calculate.arithmetic(operator, firstOperand, secondOperand, inputNumberField));
			calculationProcessString = inputNumberField.getText();//.replaceAll("\\,", "");
			if (lastInput != Constant.EQUAL_NUMBER) {
				row[0] = firstOperand + calculate.operatorConversion(operator) + secondOperand + "="
						+ inputNumberField.getText();//.replaceAll("\\,", "");
				model.addRow(row);
			}
		}
		big = new BigDecimal(String.valueOf(inputNumberField.getText().replaceAll("\\,", ""))).stripTrailingZeros();
		//if(big.scale() < 0) big = big.setScale(0);
		firstOperand = big;
		operator = calculateOperator;
		calculationProcessField.setText(calculationProcessString + calculate.operatorConversion(operator));
		isInputOperator = true;
		isFristInput = false;negatecheck = false;
		lastInput = calculateOperator;
	}
	
	void setPanel() {
		
	}
}
/*
public class AutoLabel extends JLabel {
	 
    public AutoLabel() {
        setHorizontalAlignment(SwingConstants.CENTER);
        setText("AutoLable");
        addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                resize();
            }
        });
    }
 
    void resize() {
        int i=0;
        while(true) {
            Font before = getFont();
            Font font = new Font(before.getName(), before.getStyle(), i);
            setFont(font);
            if(getPreferredSize().getWidth()>getWidth() || getPreferredSize().getHeight()>getHeight()) {
                font = new Font(before.getName(), before.getStyle(), i-1);
                setFont(font);
                break;
            }
            i++;    
        }
    }
 
}*/
