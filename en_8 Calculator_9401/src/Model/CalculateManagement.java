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
	
	public String arithmetic(int operator, BigDecimal firstOperand, BigDecimal secondOperand, JTextField inputNumberField) {
		switch (operator) { // Constant.SUBSTRACT_NUMBER 하면 case expressions must be constant expressions에러뜸 ㅠ
		case 1:
			//inputNumberField.setText(String.valueOf(new DecimalFormat("#,###,###,###,###.################").format(firstOperand.add(secondOperand))));//new DecimalFormat("#,###").format(
			return String.valueOf(firstOperand.add(secondOperand));
		case 2:
			//inputNumberField.setText(String.valueOf(new DecimalFormat("#,###,###,###,###.################").format((firstOperand.subtract(secondOperand)))));//new DecimalFormat("#,###").format
			return String.valueOf(firstOperand.subtract(secondOperand));
		case 3:
			//inputNumberField.setText(String.valueOf(new DecimalFormat("#,###,###,###,###.################").format(((firstOperand.multiply(secondOperand)).setScale(14, RoundingMode.HALF_UP)).stripTrailingZeros())));//new DecimalFormat("#,###").format
			return String.valueOf((firstOperand.multiply(secondOperand)).stripTrailingZeros());//.setScale(14, RoundingMode.HALF_UP)
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
				//inputNumberField.setText(String.valueOf((firstOperand.divide(secondOperand, MathContext.DECIMAL64))));//new DecimalFormat("#,###.0").format
				return String.valueOf(new DecimalFormat("#,###,###,###,###.################").format(firstOperand.divide(secondOperand, MathContext.DECIMAL64)));}
		}//new DecimalFormat("###,###.##").format(new BigDecimal(inputNumberField.getText().replaceAll("\\,", "")
		return null;
	}
//(new DecimalFormat("###,###.##").format(firstOperand.divide(secondOperand, MathContext.DECIMAL64)));}
}
