package Controller;

import java.io.File;

import Model.Constant;

public class Exception {
	public boolean isDirectoryExist(String path) {

		File targetFile = new File(path);
		if(targetFile.exists()) { // 파일이나 디렉토리 존재
			System.out.println(targetFile.isFile());
			if(targetFile.isFile()) {
				System.out.println(Constant.INFORMATION_DIRECTORY_NAME_INCORRECT);
			}
			else {
				return true;//currentPath = targetPath;
			}
		}
		else {
			System.out.println("지정된 경로를 찾을 수 없습니다.");
		}
		
		return false;
	}
}
