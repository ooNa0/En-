package Model;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;

public class CommandCalculation {	
	
	public String getVersion() {
		String outVertionInformation = Constant.EMPTY_VALUE;
		try {
			BufferedReader buffer = new BufferedReader(new InputStreamReader(new ProcessBuilder(Constant.EXECUTION_COMMAND).start().getInputStream()));
			outVertionInformation = buffer.readLine() + Constant.PROGRAM_ENTER_FORMAT;
			outVertionInformation += buffer.readLine() + Constant.PROGRAM_ENTER_FORMAT;
			outVertionInformation += buffer.readLine();
		} catch (IOException e) {}
		return outVertionInformation;
	}
	
	public String getVolume() {
		String outVolumeInformation = Constant.EMPTY_VALUE;
		try {
			BufferedReader buffer = new BufferedReader(new InputStreamReader(new ProcessBuilder(Constant.EXECUTION_COMMAND, "/c", "dir").start().getInputStream()));
			outVolumeInformation = buffer.readLine() + Constant.PROGRAM_ENTER_FORMAT;
			outVolumeInformation += buffer.readLine() + Constant.PROGRAM_ENTER_FORMAT;
			outVolumeInformation += buffer.readLine();
		} catch (IOException e) {}
		return outVolumeInformation;
	}
	
	public void copyDirectory(String fromPath, String toPath){ // 미완
		File sourceF = new File(fromPath);
		File targetF = new File(toPath);
		File[] target_file = sourceF.listFiles();
		for (File file : target_file) {
			File temp = new File(targetF.getAbsolutePath() + File.separator + file.getName());
			if(file.isDirectory()){
				temp.mkdir();
				copyDirectory(file.getPath(), temp.getPath());
			} else {
				FileInputStream fis = null;
				FileOutputStream fos = null;
				try {
					fis = new FileInputStream(file);
					fos = new FileOutputStream(temp) ;
					byte[] b = new byte[4096];
					int cnt = 0;
					while((cnt=fis.read(b)) != -1){
						fos.write(b, 0, cnt);
					}
				} catch (Exception e) {
					e.printStackTrace();
				} finally{
					try {
						fis.close();
						fos.close();
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}	
				}
			}
		  }	
	    }
	
	public boolean copy(String originalFilePath, String copyFilePath) {
		File originalFile = new File(originalFilePath);
		File copyFile = new File(copyFilePath);
		
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
			
			//파일스트림 닫기
			fis.close();
			fos.close();

		} catch (Exception e) {
			return false;
		}
		return true;
	}

	//삭제하는 메소드
	public void delete(String originalFilePath, String currentPath) {
		if (!originalFilePath.contains(Constant.TOP_LEVEL_PATH)) { // 상대 경로 -> 절대 경로
			originalFilePath = currentPath + "\\" + originalFilePath;
		}
		File file = new File(originalFilePath);
		// 디렉토리이면 그아래의 파일 삭제
		if(file.isDirectory())
				deleteDirectoy(originalFilePath);
		file.delete();

	}

	private void deleteDirectoy(String originalFilePath) {
		File file = new File(originalFilePath);
		File[] filelist = file.listFiles();

		for (int i = 0; i < filelist.length; i++) {
			if (filelist[i].isDirectory()) {
				deleteDirectoy(filelist[i].toString());
				filelist[i].delete();
			} else {
				filelist[i].delete();
			}
		}
	}
}
