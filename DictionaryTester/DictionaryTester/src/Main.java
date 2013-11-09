//
// Dictionary Controller Test Program
// 
// Aurality Studios
//
// Zack Misso
//
import java.util.ArrayList;
public class Main{
	public static void main(String[] args){
		DictionaryController controller=new DictionaryController();
		// test code //
		ArrayList<String> matches=controller.getHashMatches("as");
		for(String str:matches)
			System.out.println(str);
	}
}
