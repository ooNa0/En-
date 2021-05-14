package Controller;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.net.http.HttpHeaders;
import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import javax.imageio.ImageIO;
/*
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.request.ImageSearchRequest;
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.response.DetailImageInfo;
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.response.ImageSearchResult;
import org.json.JSONArray;
import org.json.JSONObject;
*/
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

import Model.Constant;
import Model.DataBase;
import Model.KakaoAPI;

@SuppressWarnings("serial")
public class ImageSearch extends JFrame{
	JLabel label;
	DataBase database = new DataBase();

	public ImageSearch(){
		JPanel panel = new JPanel();
		panel.setBackground(new Color(Constant.PANEL_COLOR_GREY_SET,
				Constant.PANEL_COLOR_GREY_SET,
				Constant.PANEL_COLOR_GREY_SET));
		
		JLabel la = new JLabel(Constant.LABEL_SEARCHITEM_INFORMATION);
		JTextField inputSearchText = new JTextField(15);
		setTitle("Image Search"); //Frame의 타이틀 이름 주기
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(Constant.FRAME_HORIZONTAL_SIZE, Constant.FRAME_VERTICAL_SIZE); //Frame의 크기 설정
		setResizable(false); // 창 크기 수정 불가능하게
		setLocationRelativeTo(null); // 창 화면 가운데에 나오도록
		//c.setLayout(new FlowLayout());
		JButton backButton = new JButton("뒤로가기");
		JButton searchButton = new JButton("검색하기");
		Integer[] numbers = {5, 10, 15, 20, 25, 30};
		JComboBox<Integer> comboBox = new JComboBox<Integer>(numbers);
		panel.add(comboBox);
		panel.add(la);
		panel.add(inputSearchText);
		panel.add(searchButton);
		panel.add(backButton);
		add(panel, BorderLayout.NORTH);
		setVisible(true);
		/*
		@Override
		  public void actionPerformed(ActionEvent ae) {
		    JButton bx = (JButton) ae.getSource();
		    for (int i = 0; i < 5; i++)
		      for (int j = 0; j < 5; j++)
		        if (b[i][j] == bx)
		        {
		          bx.setBackground(Color.RED);
		        }
		  }
		JButton button = (JButton) ev.getSource();
		int x = this.getContentPane().getComponentXIndex(button);
		int y = this.getContentPane().getComponentYIndex(button);
		*/
		//inputSearchText.addActionListener(this); // 엔터 누르면 버튼 실행
		
		backButton.addActionListener(new ActionListener() { // 뒤로가기 버튼
			@Override
			public void actionPerformed(ActionEvent e) {
					setVisible(false);
					new MainMenu().startMenu();
					
			}
		});
		searchButton.addActionListener(new ActionListener() { // 찾기 버튼
			@Override
			public void actionPerformed(ActionEvent e) {
				JPanel imagePanel = new JPanel();
				String searchItem = inputSearchText.getText();
				GridLayout layout = new GridLayout(3,3, 1, 1);
				imagePanel.setLayout(layout);

				add(imagePanel);
				setVisible(true);
				JSONArray jsonArray1 = new KakaoAPI().getImageData(searchItem, comboBox.getSelectedItem().toString());
				database.inputDataBase(searchItem);
					// 검색하기 버튼을 누르면, 그 값을 입력받아서 query에 보냄
					// 그걸 출력
				
				for(int i=0; i<jsonArray1.size(); i++){          
	                   JSONObject objectInArray = (JSONObject) jsonArray1.get(i);
	                   try {
						URL url = new URL(objectInArray.get("thumbnail_url").toString());//image_url
	                	ImageIcon img = new ImageIcon(url);
	                	JLabel imageLabel = new JLabel(img);
	                	imagePanel.add(imageLabel);
					} catch (MalformedURLException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}
		            	setVisible(true);
				}
			}
		});
		
	}/*
	@Override 
	public void actionPerformed(ActionEvent e) 
	{ 
		if (e.getSource() == backButton)
		{ //...동작을 실행한다. } } //엔터를 눌렀을 때의 액션 
			public void keyPressed(KeyEvent e)
			{ 
				if (e.getKeyCode() == KeyEvent.VK_ENTER) 
				{ //...동작을 실행한다.
					
				}
			}
		}
	}*/
}
