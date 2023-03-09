using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	public class AssetBunddleDownloader : MonoBehaviour
	{
		public void DownloadAsset(string url, Action<AssetBundle> OnDownloadComplete)
		{
			StartCoroutine(DownladAssetBunddle(url, OnDownloadComplete));
		}

		IEnumerator DownladAssetBunddle(string url, Action<AssetBundle> callBack)
		{
			UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
			yield return request.SendWebRequest();
			if (request.error != null)
			{
				DebugLog.AddMessege("Failed to download AssetBunddle");
				yield break;
			}

			AssetBundle asset = DownloadHandlerAssetBundle.GetContent(request);
			DebugLog.AddMessege("Loadded Asset :" + asset.name);
			callBack(asset);
		}
	}

}
