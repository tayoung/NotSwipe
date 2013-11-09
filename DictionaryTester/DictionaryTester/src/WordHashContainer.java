//
// Dictionary Controller Test Program
// 
// Aurality Studios
//
// Zack Misso
//
import java.util.ArrayList;
import java.util.Collections;
public class WordHashContainer {
	private ArrayList<String> words;
	private Integer hash;
	
	public WordHashContainer(int code){
		words=new ArrayList<String>();
		hash=code;
	}
	
	public WordHashContainer(int code,String first){
		words=new ArrayList<String>();
		hash=code;
		words.add(first);
	}
	
	public int hashCode(){
		return hash;
	}
	
	public ArrayList<String> getListOfWords(){return words;}
	public void add(String param){words.add(param);}
	
	public String toString(){
		return hash.toString();
	}
}
