package Model;

public class DataTransferObject {

		private String name;
		private String birthday;
		private String id;
		private String password;
	    private String phonenumber;
	    private String email;
	    private String address;
	//»ý¼ºÀÚ
	    public DataTransferObject(String name, String birthday, String id, String password, String phonenumber, String email, String address){
	        this.name = name;
	        this.birthday = birthday;
	        this.id = id;
	        this.password = password;
	        this.phonenumber = phonenumber;
	        this.email = email;
	        this.address = address;
	    }
	//getter, setter
	    public String getName(){
	        return name;
	    }
	    public String getBirthday(){
	        return birthday;
	    }
	    public String getIdentity() {
	        return id;
	    }
	    public String getPassword(){
	        return password;
	    }
	    public String getPhonenumber(){
	        return phonenumber;
	    }
	    public String getEmail(){
	        return email;
	    }
	    public String getAddress(){
	        return address;
	    }
	    
	    public void setName(String name){
	        this.name = name;
	    }
	    public void setBirthday(String birthday){
	        this.birthday = birthday;
	    }
	    public void setIdentity(String id){
	        this.id = id;
	    }
	    public void setPassword(String password) {
	    	this.password = password;
	    }
	    public void setPhonenumber(String phonenumber){
	        this.phonenumber = phonenumber;
	    }
	    public void setEmail(String email){
	        this.email = email;
	    }
	    public void setAddress(String address){
	        this.address = address;
	    }
	}
