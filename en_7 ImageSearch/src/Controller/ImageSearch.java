package Controller;

import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.request.ImageSearchRequest;
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.response.DetailImageInfo;
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.response.ImageSearchResult;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;

import View.SetFrame;

public class ImageSearch extends JFrame {
	/*private SetFrame setFrame;
	public ImageSearch(SetFrame setFrame) {
		this.setFrame = setFrame;
	}*/
	JLabel la = new JLabel("You");
	ImageSearch(String labelName){
		super("YourFrame");
		
		
		setLayout(null); //Layout을 NULL로 설정 (컴포넌트의 위치를 사용자가 설정해주어야 함)
		//setFrame.createFrame();
		setTitle("Image Search"); //Frame의 타이틀 이름 주기
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(700, 500); //Frame의 크기 설정
		setResizable(false); // 창 크기 수정 불가능하게
		setLocationRelativeTo(null); // 창 화면 가운데에 나오도록
		setVisible(true); //생성한 Frame을 윈도우에 뿌리기
		
		
		Container c = getContentPane();
		c.setLayout(new FlowLayout());
		JButton backBtn = new JButton("back");
		backBtn.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
					//setVisible(false);
					new MainMenu().startMenu();
			}
		});
		
		curl -v -X GET "https://dapi.kakao.com/v2/search/image" \
		--data-urlencode "query=설현" \
		-H "Authorization: KakaoAK {4d74071d3fbd89dfcb53c6ab3e6dd5e0}"
		
		la.setText(labelName);
		c.add(la);
		c.add(backBtn);
		setVisible(true);
	}
}
