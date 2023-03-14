using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioClipTest : Test
{
	public void showData(AudioClip clip)
	{
		clear();
		GameObject created =Instantiate(new GameObject(),infoScreen.transform);
		AudioSource aud = created.AddComponent<AudioSource>();
		infoText.text = "  Playing Audio now";
		aud.PlayOneShot(clip);
	}
}
