using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyDownloadManger;
using Unity.VisualScripting;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class EasyDownladMangerTest : MonoBehaviour
{
	public TMP_InputField URL;
	public GameObject infoScreen;
	public Image progressBar;
	public TMP_Text precent;
	TextTest textTest;
	ImageTest imageTest;
	AudioClipTest audioClipTest;
	AssetBunddleTest assetBunddleTest; 
	PrefabTest prefabTest;
	VideoAssetTest videoAssetTest;

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
		videoAssetTest = this.AddComponent<VideoAssetTest>();
		videoAssetTest.infoScreen = infoScreen;
	}

	void FixedUpdate()
	{
		progressBar.fillAmount = Downloader.CurrentDownloadProgress;
		int precentValue = (int)(Downloader.CurrentDownloadProgress * 100);
		if (precentValue == 100)
			precent.text = "successfully";
		else
			precent.text = precentValue.ToString() + "%";
		
	}
	public void OnClick_DownloadText()
    {
		if (string.IsNullOrEmpty(URL.text))
			URL.text = "https://drive.google.com/u/0/uc?id=18a3jIUqmd6cjLOnTrAwUueltafyoudm7&export=download";
        Downloader.Instance.DownloadText(URL.text, textTest.ShowData);
	}

	public void OnClick_DownloadImage()
	{
        if (string.IsNullOrEmpty(URL.text))
            URL.text = "https://drive.google.com/u/0/uc?id=1HoLKMvDbyczGxn2TusQNCqHeTAtM7yVH&export=download";
        Downloader.Instance.DownloadImage(URL.text, imageTest.ShowData);
	}

	public void OnClick_DownloadAudioClip()
	{
        if (string.IsNullOrEmpty(URL.text))
            URL.text = "https://drive.google.com/u/0/uc?id=19iqtWdwsZ0ZqFktVv0ZrX9wTf3ufp03M&export=download";
        Downloader.Instance.DownloadAudioCLip(URL.text, audioClipTest.showData);
	}

	public void OnClick_DownloadAssetBunddle()
	{
        if (string.IsNullOrEmpty(URL.text))
            URL.text = "https://drive.google.com/u/0/uc?id=127YdkS3_T7YDVRuFKb9anjtoKfmPhGMh&export=download";
        Downloader.Instance.DownloadAssetBunddle(URL.text, assetBunddleTest.ShowData);
	}
	public void OnClick_DownloadPrefab()
	{
        if (string.IsNullOrEmpty(URL.text))
            URL.text = "https://drive.google.com/u/0/uc?id=1R1nqvhWFGrILojKKZkmEWJZe-3qzpbO8&export=download";
        Downloader.Instance.DownloadAssetBunddleSingleItem<GameObject>(URL.text, prefabTest.ShowData);
	}

	public void OnCLick_DownloadVideoAsset()
	{
		if (string.IsNullOrEmpty(URL.text))
			URL.text = "https://drive.google.com/u/0/uc?id=1WQrSDX0eW0-flJMktX0QNPVHh7gBFSa7&export=download";
		Downloader.Instance.DownloadVideoAsset(URL.text,videoAssetTest.ShowData);
	}
}
//     text link     : https://drive.google.com/u/0/uc?id=18a3jIUqmd6cjLOnTrAwUueltafyoudm7&export=download
//    image link     : https://drive.google.com/u/0/uc?id=1HoLKMvDbyczGxn2TusQNCqHeTAtM7yVH&export=download
//    Audio link     : https://drive.google.com/u/0/uc?id=19iqtWdwsZ0ZqFktVv0ZrX9wTf3ufp03M&export=download
// assetBunddle link : https://drive.google.com/u/0/uc?id=127YdkS3_T7YDVRuFKb9anjtoKfmPhGMh&export=download
// prefab asset link : https://drive.google.com/u/0/uc?id=1R1nqvhWFGrILojKKZkmEWJZe-3qzpbO8&export=download
// video asset link  :https://drive.google.com/u/0/uc?id=1WQrSDX0eW0-flJMktX0QNPVHh7gBFSa7&export=download