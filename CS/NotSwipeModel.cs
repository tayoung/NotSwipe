using UnityEngine;
using System.Collections;

class SwipeDictionaryObject : IComparable {
	// Data
	public string* word;
	public float weight;
	
	// Overrides
	public int CompareTo(object obj) {
		if(obj == null) return 1;
		
		SwipeDictionaryObject otherDict = obj as SwipeDictionaryObject;
		if(otherDict != null) {
			return this.weight.CompareTo(otherDict.weight);
		}
		else {
			throw new ArgumentException("Object being compared not a SwipeDictionaryObject");
		}
	}
	
}

public class NotSwipeModel {
	// Data
	// Using floats in place of doubles due to the structure of Vector2.
	public static float[,] mat = new float[300,300];
	public static float[] wei  = new float[300];
	public static float angleFromPoints(Vector2 start, Vector2 end);
	
	//
	public static double wlcs(string input, string word) {
		for(int i=1; i <= word.Length; i++) {
			for(int j=1; j <= input.Length; j++) {
				
				if(input[j-1] == word[i-1])
					mat[i][j] = Math.Max(mat[i-1][j-1]+wei[j-1], mat[i-1][j]-30);
				else
					mat[i][j] = Math.Max(mat[i-1][j], mat[i][j-1]);
			}
		}
		return mat[word.Length][input.Length];
	}
	
	
	// Self-explanatory
	public static ArrayList<string> findBestMatches(string* input, ArrayList<Vector2> entrancePoints) {
		int begin = input[0]-'0';
		int end = input[input.Length]-'0';
		// I honestly don't know what to do with this since we don't know the file format.
		string path = string.Format ("/var/swype/English/{0}-{1}.plist", new string[]{begin,end});
		// here we need to open the file and put it in the array words
		ArrayList<string> words = new ArrayList();
		ArrayList<float> weights = findAngleDifferences(findAnglesForPoints(entrancePoints));
		
		for(int i=0; i < weights.Count; i++) {
			wei[i+1] = weights[i];
		}
		wei[0] = 180;
		wei.Add(180);
		ArrayList<SwipeDictionaryObject> arr = new ArrayList();
		
		for(int i=0; i < words.Count; i++) {
			string word = words[i];
			if(word.Equals(input)){
				SwipeDictionaryObject tmp = new SwipeDictionaryObject();
				tmp.weight = (words.Count-i) / (words.count*180 + wlcs(input, word));
				tmp.word = word;
				arr.Add(tmp);
			}
		}
		
		arr.Sort();
		
		// Return sorted list of results.
		// TODO: Can probably do this at the same time as the dictionary object construction.
		ArrayList<string> results = new ArrayList();
		foreach(SwipeDictionaryObject o in arr){
			ret.Add(o.word);
		}
		
		return results;
	}
	
	//
	public static void updatePreference(string* str) {
		
	}
	
	
	// Helper functions
	
	// Returns list of angles between each adjacent vector.
	public static ArrayList<float> findAnglesForPoints(ArrayList<Vector2> entrancePoints) {
		ArrayList<float> results = new ArrayList();
		
		for(int i=1; i < entrancePoints.Count; i++) {
			Vector2 t1 = entrancePoints[i-1];
			Vector2 t2 = entrancePoints[i];
			results.Add(Vector2.Angle(t1,t2));	// Unity library
		}
		return results;
	}
	
	// Returns a list of all differences in the angles.
	public static ArrayList<float> findAngleDifferences(ArrayList angles) {
		ArrayList<float> results = new ArrayList();
		
		for(int i=1; i < angles.Count; i++ ) {
			float t1 = angles[i-1];
			float t2 = angles[i];
			results.Add(minAngle(t1,t2));
		}
		return results;
	}

	//
	private static float minAngle(float a1, float a2) {
		float min = Math.Min(a1,a2);
		float max = Math.Max(a1,a2);
		return Math.Max(max-min, min-max+360);
	}
}
