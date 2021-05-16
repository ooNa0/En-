package Model;

import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import javax.imageio.ImageIO;
import javax.net.ssl.HttpsURLConnection;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

//import org.json.JSONArray;
//import org.json.JSONObject;

public class KakaoAPI {

	public JSONArray getImageData(String searchItem, String size) {
		
		String auth = Constant.KAKAO_API_KEY;
		HttpsURLConnection httpConnection;
		String inputLine;
		StringBuffer res = new StringBuffer();

		try {
			URL link = new URL(Constant.KAKAO_API_LINK + 
					URLEncoder.encode(searchItem, Constant.ENCODE_KOREAN) + 
					Constant.KAKAO_API_SIZE + size);
			// 접속
			httpConnection = (HttpsURLConnection) link.openConnection();
			// 요청 헤더 추가
			httpConnection.setRequestMethod("GET");
			httpConnection.setRequestProperty("User-Agent", "Java-Client"); // https 호출시 user-agent 필요
			httpConnection.setRequestProperty("X-Requested-With", "curl");
			httpConnection.setRequestProperty("Authorization", auth);

			int responseCode = httpConnection.getResponseCode();
			BufferedReader br;

			if (responseCode == 200) { // 정상 호출
				br = new BufferedReader(new InputStreamReader(httpConnection.getInputStream(), "UTF-8"));
				// 서버와 연결되어 있는 스트림을 추출한다.
			} else {
				br = new BufferedReader(new InputStreamReader(httpConnection.getErrorStream()));
			}

			while ((inputLine = br.readLine()) != null) {
				res.append(inputLine);
			}
			br.close();
		} catch (IOException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}

		// 가장 큰 JSONObject
		JSONParser jsonParser1 = new JSONParser();
		JSONObject jsonObject1 = null;
		BufferedImage image;
		try {
			jsonObject1 = (JSONObject) jsonParser1.parse(res.toString());
		} catch (org.json.simple.parser.ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		JSONArray jsonArray1 = (JSONArray) jsonObject1.get("documents");
		for (int i = 0; i < jsonArray1.size(); i++) {
			JSONObject objectInArray = (JSONObject) jsonArray1.get(i);
			//System.out.println(objectInArray);
			URL url;
			try {
				url = new URL(objectInArray.get("image_url").toString());
				try {
					image = ImageIO.read(url.openStream()); // Can't get input stream from URL! 오류
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			} catch (MalformedURLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		return jsonArray1;
	}
}
