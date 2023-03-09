using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetsBunddleCreator
{
	private static string SavingPath = "Assets/CreatedAssets";


	[MenuItem("AssetsBundle/CreateAssetsFor/Android")]
	public static void CreateAssetsBunddleForAndroid()
	{
		Debug.Log("Creating Assets bunddels for Android");
		CreatAssetsBunddle(BuildTarget.Android);
	}

	[MenuItem("AssetsBundle/CreateAssetsFor/Windows")]
	public static void CreateAssetsBunddleForWindows()
	{
		Debug.Log("Creating Assets bunddels for Windows");
		CreatAssetsBunddle(BuildTarget.StandaloneWindows);
	}


	[MenuItem("AssetsBundle/CreateAssetsFor/IOS")]
	public static void CreateAssetsBunddleForIOS()
	{
		Debug.Log("Creating Assets bunddels for IOS and saving it into ");
		CreatAssetsBunddle(BuildTarget.iOS);
	}

	private static void CreatAssetsBunddle(BuildTarget target)
	{
		Debug.Log("Creating Assets bunddels");
		if (!Directory.Exists(SavingPath))
			Directory.CreateDirectory(SavingPath);
		BuildPipeline.BuildAssetBundles(SavingPath, BuildAssetBundleOptions.None, target);
	}


	[MenuItem("AssetsBundle/Delete Created")]
	public static  void DeletCreated()
	{
		Debug.Log("DeletCreatedAssetsBunddle");
		if (Directory.Exists(SavingPath))
		{
			DirectoryInfo di = new DirectoryInfo(SavingPath);
			foreach (FileInfo file in di.GetFiles())
			{
				file.Delete();
			}
			foreach (DirectoryInfo dir in di.GetDirectories())
			{
				dir.Delete(true);
			}
		}
	}
}