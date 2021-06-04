package Model;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;

public class ApplyCommand {

	
	
	public String getVersion() {
		String outVertionInformation = Constant.EMPTY_VALUE;
		try {
			BufferedReader buffer = new BufferedReader(new InputStreamReader(new ProcessBuilder("cmd").start().getInputStream()));
			outVertionInformation = buffer.readLine() + "\n";
			outVertionInformation += buffer.readLine() + "\n";
			outVertionInformation += buffer.readLine();
		} catch (IOException e) {}
		return outVertionInformation;
	}
	
	public String getVolume() {
		String outVolumeInformation = Constant.EMPTY_VALUE;
		try {
			BufferedReader buffer = new BufferedReader(new InputStreamReader(new ProcessBuilder("cmd", "/c", "dir").start().getInputStream()));
			outVolumeInformation = buffer.readLine() + "\n";
			outVolumeInformation += buffer.readLine() + "\n";;
			outVolumeInformation += buffer.readLine();
		} catch (IOException e) {}
		return outVolumeInformation;
	}
	
	public void clsCommand() {
		System.out.print("\033[H\033[2J");
        System.out.flush();
	}
	
	public boolean copy(String originalFilePath, String copyFilePath) {
		File originalFile = new File(originalFilePath);
		File copyFile = new File(copyFilePath);
		
		//복사될 장소의 디렉토리가 존재하지 않으면 만들어준다.
		//if(!dirCopyFile.exists()) {
		//	dirCopyFile.mkdirs();
		//}
		
		try {
			//파일의 내용을 읽어오기위한 준비
			FileInputStream fis = new FileInputStream(originalFile);
			
			//파일의 내용을 쓰기 위한 준비
			FileOutputStream fos = new FileOutputStream(copyFile);

			//파일을 읽고 쓰기를 합니다. 
			int nRealByte = 0;
			while ((nRealByte = fis.read()) != -1) {
				fos.write(nRealByte);
			}
			
			//파일스트림을 닫아줍니다.
			fis.close();
			fos.close();

		} catch (Exception e) {
			//파일 처리 실패시 -1를 리턴합니다.
			System.out.println(e.getLocalizedMessage());
			return false;
		}
		//성공시에 메세지 출력후 1을 리턴합니다.
		//System.out.println("copy succeed !!");
		return true;
	}

	//삭제하는 메소드
	public int delete(String originalFilePath, String currentPath) {
		
		if(!originalFilePath.contains(Constant.TOP_LEVEL_PATH)) { // 상대 경로 -> 절대 경로
			originalFilePath = currentPath + "\\" + originalFilePath;
		}

		//파일이 있는지 확인합니다.
		//if (file.exists()) {
			
			//디렉토리이면 그아래의 파일 삭제
				deleteDirectoy(originalFilePath);
				File file = new File(originalFilePath);
				file.delete();
				//File[] filelist = file.listFiles();
				/*
				for (int i = 0; i < filelist.length; i++) {
					if (filelist[i].delete()) {
						System.out.println(filelist[i].getName() + "Dirlist- delete succeed !!");
					} else {
						System.out.println(filelist[i].getName() + "Dirlist- delete error");
					}
				}*/
			
			
			//파일이 존재하지 않으면 에러메세지를 보내고 -2를 리턴합니다.
		//} else {
		//	System.out.println("not exist !!!");
		//	return -2;
		//}
		//정상처리되면 1를 리턴합니다.
		return 1;
	}

	private void deleteDirectoy(String originalFilePath) {
		File file = new File(originalFilePath);
		//System.out.println(file);
		File[] filelist = file.listFiles();

		for (int i = 0; i < filelist.length; i++) {
			System.out.println(filelist.length);
			System.out.println("filelist = " + filelist[i].toString());
			if (filelist[i].isDirectory()) {
				deleteDirectoy(filelist[i].toString());//originalFilePath + "\\" + filelist[i].
				filelist[i].delete();
			} else {
				filelist[i].delete();
			}
		}
	}
	
	/*
	private String deleteDirctoy(File[] filelist) {
		
		if(filelist != null) {
			for (int i = 0; i < filelist.length; i++) {
				System.out.println(filelist[i].getName());
				if(filelist[i].isDirectory()) {
					System.out.println("엥");
					System.out.println(new File(filelist[i].getName()).listFiles());
					deleteDirctoy(new File(filelist[i].getName()).listFiles());					
				}
				filelist[i].delete();
			}
		}		
		return "";
	}*/
	}
