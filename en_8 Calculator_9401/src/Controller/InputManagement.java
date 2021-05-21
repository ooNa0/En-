package Controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyListener;
import java.math.BigDecimal;

import Model.Constant;

public class InputManagement implements ActionListener, KeyListener {
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

			inputNumberField.setText(Constant.DEFAULT_VALUE);
			firstOperand = BigDecimal.ZERO;

		} else if (e.getActionCommand().equals("\u2190")) { // 하나 지우기

			if (inputNumberField.getText().length() == Constant.MINIMUM_TEXT) {
				inputNumberField.setText(Constant.DEFAULT_VALUE);
			} else if (inputNumberField.getText().length() > Constant.MINIMUM_TEXT) {
				String a = inputNumberField.getText().substring(0, inputNumberField.getText().length() - 1);
				inputNumberField.setText(a);
			}

		} else if (e.getActionCommand().equals(".")) { // 소수점 붙이기!

			if (!inputNumberField.getText().contains(".")) { // 텍스트 공간에 . 이 없을 경우에 추가가능!
				String b = inputNumberField.getText();
				b += ".";
				inputNumberField.setText(b);
			}

		} else if (e.getActionCommand().equals("±")) { // +/- 버튼

			BigDecimal u = new BigDecimal(inputNumberField.getText());
			// 앞에 연산자면 negate(~~) 필요하고, 아니라면 -만 붙었다 안붙었다
			if (isInputOperator) {
				calculationProcessField.setText(calculationProcessString + operatorConversion() + "negate(" + u + ")");
			}
				inputNumberField.setText(String.valueOf(u.multiply(BigDecimal.valueOf(-1))));
			

		} else if (e.getActionCommand().equals("+")) {
			fourRuleCalculation(1);

		} else if (e.getActionCommand().equals("-")) {
			fourRuleCalculation(2);

		} else if (e.getActionCommand().equals("×")) {
			fourRuleCalculation(3);

		} else if (e.getActionCommand().equals("÷")) {
			fourRuleCalculation(4);

		} else if (e.getActionCommand().equals("=")) {
			String[] row = new String[1];
			row[0] = calculationProcessField.getText();
			BigDecimal big = new BigDecimal(String.valueOf(inputNumberField.getText()));
			if (isFristInput) { // 첫 입력이었을때에는 아무것도 없어야 함,, 그냥 동일한 값 계속 출력
			} 
			else {
				if (lastInput != Constant.EQUAL_NUMBER) {
					secondOperand = new BigDecimal(inputNumberField.getText());
					row[0] += secondOperand;
				} 
				else {
					firstOperand = new BigDecimal(inputNumberField.getText());
					row[0] += firstOperand + operatorConversion();
					row[0] += secondOperand;
				}
				System.out.println("계산결과 =" + arithmetic());
				inputNumberField.setText(arithmetic());
				System.out.println("계산결과 =" + (arithmetic()==null));
				if(arithmetic() == null) {
					inputNumberField.setText(String.valueOf(big));
					row[0] = "=" + String.valueOf(inputNumberField.getText());
				}
				else {
					row[0] += "=" + String.valueOf(inputNumberField.getText());
				}
				System.out.println("=" + inputNumberField.getText());
			}		
			model.addRow(row);

			calculationProcessString = "";
			calculationProcessField.setText(null);
			lastInput = Constant.EQUAL_NUMBER;// operator = Constant.EQUAL_NUMBER;
			// if(isFristInput == false) isFristInput = true; else
			isFristInput = false;
			isInputOperator = true;
		} else {
			if (isInputOperator) {
				inputNumberField.setText(null);
			}
			isInputOperator = false;

			if (inputNumberField.getText().equals(Constant.DEFAULT_VALUE)) {

				inputNumberField.setText(null);
				inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());

			} else {

				inputNumberField.setText(inputNumberField.getText() + e.getActionCommand());

			}
		}
}
