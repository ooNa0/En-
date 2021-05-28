package Model;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyListener;
import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.text.DecimalFormat;

import javax.swing.JTextField;

public class CalculateManagement{
	
	public String operatorConversion(int operator) {
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
	
	@SuppressWarnings("deprecation")
	public BigDecimal arithmetic(int operator, BigDecimal firstOperand, BigDecimal secondOperand, JTextField inputNumberField) {
		switch (operator) { // Constant.SUBSTRACT_NUMBER ÇÏ¸é case expressions must be constant expressions¿¡·¯¶ä ¤Ð
		case 1: return firstOperand.add(secondOperand);//String.valueOf(
		case 2: return firstOperand.subtract(secondOperand);//String.valueOf(
		case 3: return firstOperand.multiply(secondOperand);//new BigDecimal(decimalFormat.format(
		case 4:	return firstOperand.divide(secondOperand, 1000, RoundingMode.HALF_EVEN);//, 20, RoundingMode.HALF_EVEN
		}
		return null;
	}
}
