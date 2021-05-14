package Model;

import java.awt.List;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import javax.imageio.ImageIO;
import javax.net.ssl.HttpsURLConnection;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;


//import org.json.JSONArray;
//import org.json.JSONObject;


public class KakaoAPI {
	//Map<String, Object> rtnObj = new HashMap<> ();
	@SuppressWarnings("unchecked")
	public JSONArray getImageData(String searchItem, String size) {
		String auth = "KakaoAK " + "4d74071d3fbd89dfcb53c6ab3e6dd5e0";
		HttpsURLConnection hc;
        String inputLine;
        StringBuffer res = new StringBuffer();
		try {
			String linkString =  "https://dapi.kakao.com/v2/search/image.json?query=" + URLEncoder.encode(searchItem, "UTF-8") + "&&size=" + size;
			URL link = new URL(linkString);
			 System.out.println(link);
			// 접속
			hc = (HttpsURLConnection)link.openConnection();
			// 요청 헤더 추가
			hc.setRequestMethod("GET");
			hc.setRequestProperty("User-Agent", "Java-Client");	// https 호출시 user-agent 필요
			hc.setRequestProperty("X-Requested-With", "curl");
			hc.setRequestProperty("Authorization", auth);

            int responseCode = hc.getResponseCode();
            BufferedReader br;
            if(responseCode==200) 
            { // 정상 호출
                br = new BufferedReader(new InputStreamReader(hc.getInputStream(), "UTF-8")); 
                //서버와 연결되어 있는 스트림을 추출한다.
                //InputStream is = conn.getInputStream();
                //InputStreamReader isr = new InputStreamReader(is, "UTF-8");
                //BufferedReader br = new BufferedReader(isr);
            }
            else 
            {  // 에러 발생
                br = new BufferedReader(new InputStreamReader(hc.getErrorStream()));
            }
            //String json = "";
            while ((inputLine = br.readLine()) != null) 
            {
            	res.append(inputLine);
            }
            br.close();

            //Component a = res;
            //c.add(res)
		} catch (IOException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
		
	       JSONParser jsonParser1 = new JSONParser();
	        JSONObject jsonObject1 = null;
	        BufferedImage image;
     	       try {
				jsonObject1 = (JSONObject)jsonParser1.parse(res.toString());
			} catch (org.json.simple.parser.ParseException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
                JSONArray jsonArray1 = (JSONArray) jsonObject1.get("documents"); 
                //System.out.println((JSONArray) jsonObject1.get("documents"));    
               for(int i=0; i<jsonArray1.size(); i++){
                   //System.out.println("검색결과"+ i +" : " +jsonArray1.get(i));            
                   JSONObject objectInArray = (JSONObject) jsonArray1.get(i);
                   URL url;
				try {
					url = new URL(objectInArray.get("image_url").toString());
	                try {
						image = ImageIO.read(url);
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
				} catch (MalformedURLException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				} 
                   System.out.println("image_url값은 "+objectInArray.get("image_url"));
               }
               
		//System.out.println(inputLine);
	    // 가장 큰 JSONObject를 가져옵니다.JSONParser parser = new JSONParser(); 

		// json array
               
		return jsonArray1;
	}
}

/*
 * String searchItem;
 
try {
	String query = "https://dapi.kakao.com/v2/search/image.json?query=고양이"
			+ URLEncoder.encode(searchItem, "UTF-8");
	HttpHeaders headers = new HttpHeaders();
    headers.add("Authorization", "KakaoAK {4d74071d3fbd89dfcb53c6ab3e6dd5e0}");
//ObjectMapper objectMapper = new ObjectMapper();
//objectMapper.configure(DeserializationFeature.ACCEPT_SINGLE_VALUE_AS_ARRAY, true);
//la.setText(labelName);
}*/

//containerPanel.add(la);
//containerPanel.add(backBtn);
//setVisible(true);
//}
