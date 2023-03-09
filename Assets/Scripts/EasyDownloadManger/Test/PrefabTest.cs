using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : Test
{
	public void ShowData(GameObject data)
	{
		clear();
		infoText.text = "creating prefab";
		GameObject temp = Instantiate(data);
		temp.transform.position = Vector3.zero;
	}
}
