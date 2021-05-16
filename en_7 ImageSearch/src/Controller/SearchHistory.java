package Controller;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Vector;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JScrollPane;

import Model.Constant;
import Model.DataBase;

@SuppressWarnings("serial")
public class SearchHistory extends JFrame{
	JLabel label;
	DataBase database = new DataBase();
	public SearchHistory() {
			JPanel panel = new JPanel();
			panel.setBackground(new Color(Constant.PANEL_COLOR_GREY_SET,
					Constant.PANEL_COLOR_GREY_SET,
					Constant.PANEL_COLOR_GREY_SET));
			JLabel la = new JLabel("검색 기록 보기");
			setTitle("Image Search"); //Frame의 타이틀 이름 주기
	        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	        setSize(700, 500); //Frame의 크기 설정
			setResizable(false); // 창 크기 수정 불가능하게
			setLocationRelativeTo(null); // 창 화면 가운데에 나오도록
			JButton backButton = new JButton("뒤로가기");
			JButton resetButton = new JButton("데이터 베이스 초기화");
			panel.add(la);
			panel.add(resetButton);
			panel.add(backButton);
			add(panel, BorderLayout.NORTH);
			JPanel imagePanel = new JPanel();
			imagePanel.setLayout(new FlowLayout());
			Vector queryArray = database.showDataBase();
			JList<?> list = new JList();
			list.setListData(queryArray);
			add(new JScrollPane(list), "Center");
			setVisible(true);
			
			backButton.addActionListener(new ActionListener() { // 뒤로가기 버튼
				@Override
				public void actionPerformed(ActionEvent e) {
						setVisible(false);
						new MainMenu().startMenu();
						
				}
			});
			resetButton.addActionListener(new ActionListener() { // 데베 초기화 버튼
				@Override
				public void actionPerformed(ActionEvent e) {
						
					database.resetDataBase();
					Vector queryArray = database.showDataBase();
					JList<?> list = new JList();
					list.setListData(queryArray);
					add(new JScrollPane(list), "Center");
					setVisible(true);
						// 그걸 출력
				}
			});
	}
}
