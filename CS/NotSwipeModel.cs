using UnityEngine;
using System;
using System.Collections.Generic;

class SwipeDictionaryObject : IComparable {
	// Data
	public string word;
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
	
	//
	public static float wlcs(string input, string word) {
		for(int i=1; i <= word.Length; i++) {
			for(int j=1; j <= input.Length; j++) {
				
				if(input[j-1] == word[i-1])
					mat[i, j] = Math.Max(mat[i-1, j-1]+wei[j-1], mat[i-1, j]-30);
				else
					mat[i, j] = Math.Max(mat[i-1, j], mat[i, j-1]);
			}
		}
		return mat[word.Length, input.Length];
	}
	
	
	// Main algorithm.
	public static List<string> findBestMatches(string input, List<Vector2> entrancePoints) {
		int begin = input[0]-'0';
		int end = input[input.Length]-'0';
		// I honestly don't know what to do with this since we don't know the file format.
		string path = String.Format("/var/swype/English/{0}-{1}.plist", new int[]{begin,end});
		// Here we need to open the file and put it in the words List, but see above.
		List<string> words = new List<string>();
		List<float> weights = findAngleDifferences(findAnglesForPoints(entrancePoints));
		
		for(int i=0; i < weights.Count; i++) {
			wei[i+1] = weights[i];
		}
		wei[0] = 180;
		wei[weights.Count+1] = 180;
		List<SwipeDictionaryObject> arr = new List<SwipeDictionaryObject>();
		
		for(int i=0; i < words.Count; i++) {
			string word = words[i];
			if(word.Equals(input)){
				SwipeDictionaryObject tmp = new SwipeDictionaryObject();
				tmp.weight = (words.Count - i) / (words.Count*180 + wlcs(input, word));
				tmp.word = word;
				arr.Add(tmp);
			}
		}
		
		arr.Sort();
		
		// Return sorted list of results.
		// TODO: Can probably do this at the same time as the dictionary object construction.
		List<string> results = new List<string>();
		foreach(SwipeDictionaryObject o in arr){
			results.Add(o.word);
		}
		
		return results;
	}
	
	// Updates the preference a user has for a typed word.
	public static void updatePreference(string str) {
		int begin = (int) (str[0] - '0');
		int end = (int) (str[str.Length] - '0');
		// I honestly don't know what to do with this since we don't know the file format.
		string path = String.Format ("/var/swype/English/{0}-{1}.plist", new int[]{begin,end});
		// Here we need to open the file and put it in the words List, but see above.
		List<string> words = new List<string>();
		
		words.Remove(str);
		words.Insert(0, str);
		// TODO: Find out WTF this is.
		//[[NSPropertyListSerialization dataFromPropertyList:words format:NSPropertyListBinaryFormat_v1_0 errorDescription:nil] writeToFile:path atomically:true];
	}
	
	
	/***************** Helper functions *****************/
	
	// Returns list of angles between each adjacent vector.
	private static List<float> findAnglesForPoints(List<Vector2> entrancePoints) {
		List<float> results = new List<float>();
		
		for(int i=1; i < entrancePoints.Count; i++) {
			Vector2 t1 = entrancePoints[i-1];
			Vector2 t2 = entrancePoints[i];
			results.Add(Vector2.Angle(t1, t2));	// Unity library
		}
		return results;
	}
	
	// Returns a list of all differences in the angles.
	private static List<float> findAngleDifferences(List<float> angles) {
		List<float> results = new List<float>();
		
		for(int i=1; i < angles.Count; i++ ) {
			float t1 = angles[i-1];
			float t2 = angles[i];
			results.Add(minAngle(t1, t2));
		}
		return results;
	}

	// Self-explanatory name.
	private static float minAngle(float a1, float a2) {
		float min = Math.Min(a1,a2);
		float max = Math.Max(a1,a2);
		return Math.Max(max-min, min-max+360);
	}
}
