package Model;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyListener;
import java.math.BigDecimal;
import java.math.RoundingMode;

public class CalculateService {

	public String arithmetic() {

		System.out.println("firstOperand =" + firstOperand);
		System.out.println("secondOperand =" + secondOperand);
		switch (operator) { // Constant.SUBSTRACT_NUMBER ÇÏ¸é case expressions must be constant expressions
							// ¿¡·¯¶ä ¤Ð
		case 1:
			inputNumberField.setText(String.valueOf(firstOperand.add(secondOperand)));
			calculationProcessString += "+";
			return String.valueOf(firstOperand.add(secondOperand));
		case 2:
			inputNumberField.setText(String.valueOf(firstOperand.subtract(secondOperand)));
			calculationProcessString += "-";
			return String.valueOf(firstOperand.subtract(secondOperand));
		case 3:
			inputNumberField.setText(String.valueOf(firstOperand.multiply(secondOperand)));
			calculationProcessString += "x";
			return String.valueOf(firstOperand.multiply(secondOperand));
		case 4:
			inputNumberField.setText(String.valueOf(firstOperand.divide(secondOperand, 16, RoundingMode.HALF_UP)));
			calculationProcessString += "¡À";
			return String.valueOf(firstOperand.divide(secondOperand, 16, RoundingMode.HALF_UP));
		}
		return null;
	}

	public String operatorConversion() {
		String calculatorString = "=";
		if (operator == Constant.PLUS_NUMBER)
			calculatorString = "+";
		if (operator == Constant.SUBSTRACT_NUMBER)
			calculatorString = "-";
		if (operator == Constant.MULTIPLY_NUMBER)
			calculatorString = "x";
		if (operator == Constant.DIVISION_NUMBER)
			calculatorString = "¡À";
		return calculatorString;
	}

	public void fourRuleCalculation(int calculateOperator) {
		System.out.println("isFristInput =" + isFristInput);
		System.out.println("isInputOperator =" + isInputOperator);

		if (isFristInput || isInputOperator) {
			if (lastInput == Constant.EQUAL_NUMBER) {
				firstOperand = new BigDecimal(inputNumberField.getText());
				calculationProcessString += firstOperand;
			} else if (operator != calculateOperator) {
				firstOperand = new BigDecimal(inputNumberField.getText());
				if (isFristInput)
					calculationProcessString += firstOperand;
			}
		} else {
			// operator = calculateOperator;
			secondOperand = new BigDecimal(inputNumberField.getText());
			inputNumberField.setText(arithmetic());
			calculationProcessString += secondOperand;
		}
		firstOperand = new BigDecimal(inputNumberField.getText());
		operator = calculateOperator;
		calculationProcessField.setText(calculationProcessString + operatorConversion());
		isInputOperator = true;
		isFristInput = false;
		lastInput = calculateOperator;
	}
}
