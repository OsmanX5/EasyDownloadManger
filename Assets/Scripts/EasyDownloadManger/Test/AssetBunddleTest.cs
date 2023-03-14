using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBunddleTest : Test
{
	public void ShowData(AssetBundle data)
	{
		clear();
		string s = " Asset Name : " + data.name;
		foreach (var assetName in data.GetAllAssetNames())
		{
			s += "\n name : " + assetName + "Type : ";
			s +=  data.LoadAsset(assetName).GetType().ToString();
		}

		infoText.text = s;
	}
}
