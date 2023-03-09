
using UnityEngine;
using TMPro;


public class DebugLog : MonoBehaviour
{
	static TMP_Text Messege;
	public TMP_Text _debugLog;
	static bool hasScreen;
	private void Awake()
	{
		hasScreen = _debugLog !=null;
		Messege = _debugLog;
	}
	public static void AddMessege(string messege)
	{
		if(hasScreen)
			Messege.text += messege + "\n";
		else
			Debug.Log(messege);
		
	}
	public static void Clear()
	{
		if(hasScreen)
			Messege.text = " ";
	}
}
