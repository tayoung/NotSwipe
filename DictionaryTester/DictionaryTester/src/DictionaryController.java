//
// Dictionary Controller Test Program
// 
// Aurality Studios
//
// Zack Misso
//
import java.util.*;
import java.lang.*;
import java.util.Scanner;
import java.io.File;
import java.io.IOException;
public class DictionaryController{
	private HashMap<Integer,WordHashContainer> words;
	
	public DictionaryController(){
		words=new HashMap<Integer,WordHashContainer>();
		try{
			Scanner file=new Scanner(new File("Full_English_Dictionary.txt"));
			file.nextLine();
			file.nextLine();
			while(file.hasNextLine()){
				String word=file.nextLine();
				if(!word.equals("")){
					String hash=word.charAt(0)+""+word.charAt(word.length()-1);
					int code=(hash.charAt(0)-97)*100+(hash.charAt(1)-97);
					if(words.containsKey(new Integer(code)))
						words.get(code).add(word);
					else
						words.put(new Integer(code),new WordHashContainer(code,word));
				}
			}
		}catch(IOException e) {System.out.println("could not read file");}
	}
	
	public ArrayList<String> getHashMatches(String hash){
		int code=(hash.charAt(0)-97)*100+(hash.charAt(1)-97);
		return words.get(code).getListOfWords();
	}
}
