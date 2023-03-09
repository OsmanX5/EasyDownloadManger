using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyDownloadManger;
using Unity.VisualScripting;

public class EasyDownladMangerTest : MonoBehaviour
{
	public TMP_InputField URL;
	public GameObject infoScreen;
	TextTest textTest;
	ImageTest imageTest;
	AudioClipTest audioClipTest;
	AssetBunddleTest assetBunddleTest; 
	PrefabTest prefabTest;

	void Start()
	{
		textTest = this.AddComponent<TextTest>();
		textTest.infoScreen = infoScreen;
		imageTest = this.AddComponent<ImageTest>();
		imageTest.infoScreen = infoScreen;
		audioClipTest = this.AddComponent<AudioClipTest>();
		audioClipTest.infoScreen = infoScreen;
		assetBunddleTest = this.AddComponent<AssetBunddleTest>();
		assetBunddleTest.infoScreen = infoScreen;
		prefabTest = this.AddComponent<PrefabTest>();
		prefabTest.infoScreen = infoScreen;
	}
	public void OnClick_DownloadText()
	{
		EDM.DownloadManger.DownloadText(URL.text, textTest.ShowData);
	}

	public void OnClick_DownloadImage()
	{
		EDM.DownloadManger.DownloadImage(URL.text, imageTest.ShowData);
	}

	public void OnClick_DownloadAudioClip()
	{
		EDM.DownloadManger.DownloadAudioCLip(URL.text, audioClipTest.showData);
	}

	public void OnClick_DownloadAssetBunddle()
	{
		EDM.DownloadManger.DownloadAssetBunddle(URL.text, assetBunddleTest.ShowData);
	}
	public void OnClick_DownloadPrefab()
	{
		EDM.DownloadManger.DownloadAssetBunddleSingleItem<GameObject>(URL.text, prefabTest.ShowData);
	}
}
//     text link     : https://drive.google.com/u/0/uc?id=18a3jIUqmd6cjLOnTrAwUueltafyoudm7&export=download
//    image link     : https://drive.google.com/u/0/uc?id=1HoLKMvDbyczGxn2TusQNCqHeTAtM7yVH&export=download
//    Audio link     : https://drive.google.com/u/0/uc?id=19iqtWdwsZ0ZqFktVv0ZrX9wTf3ufp03M&export=download
// assetBunddle link : https://drive.google.com/u/0/uc?id=127YdkS3_T7YDVRuFKb9anjtoKfmPhGMh&export=download
// prefab asset link : https://drive.google.com/u/0/uc?id=1R1nqvhWFGrILojKKZkmEWJZe-3qzpbO8&export=download