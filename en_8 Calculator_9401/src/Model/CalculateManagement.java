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
			calculatorString = "÷";
		return calculatorString;
	}
	
	public BigDecimal arithmetic(int operator, BigDecimal firstOperand, BigDecimal secondOperand, JTextField inputNumberField) {
		switch (operator) { // Constant.SUBSTRACT_NUMBER 하면 case expressions must be constant expressions에러뜸 ㅠ
		case 1: return firstOperand.add(secondOperand);//String.valueOf(
		case 2: return firstOperand.subtract(secondOperand);//String.valueOf(
		case 3: return (firstOperand.multiply(secondOperand));
		case 4:
			System.out.println("first = " + firstOperand);
			System.out.println(secondOperand);
			if(secondOperand.equals(BigDecimal.ZERO)) {
				if(firstOperand.equals(BigDecimal.ZERO)) {
					inputNumberField.setText("정의되지 않은 결과입니다.");return null;					
				}
				inputNumberField.setText("0으로 나눌 수 없습니다.");return null;		
			}
			else{
				return firstOperand.divide(secondOperand, MathContext.DECIMAL64);}
		}
		return null;
	}
}
