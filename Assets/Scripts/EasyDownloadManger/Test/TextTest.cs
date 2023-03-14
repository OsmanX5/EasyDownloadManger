using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextTest : Test
{
	
	public void ShowData( string data)
	{
		clear();
		infoText.text = data;
	}
}
