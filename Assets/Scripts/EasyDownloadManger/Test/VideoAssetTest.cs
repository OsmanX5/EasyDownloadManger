using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoAssetTest : Test
{
	public void ShowData(VideoClip data)
	{
		clear();
		infoText.text = "creating Video Prefab";
		VideoPlayer videoPlayer = FindObjectOfType<VideoPlayer>();
		videoPlayer.clip = data;
	}
}
