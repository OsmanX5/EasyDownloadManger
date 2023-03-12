using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	class AssetBunddleDownloader : MonoBehaviour
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
				Debug.Log("Failed to download AssetBunddle");
				Debug.Log(request.error);
				yield break;
			}

			AssetBundle asset = DownloadHandlerAssetBundle.GetContent(request);
			Debug.Log("Loadded Asset :" + asset.name);
			callBack(asset);
		}
	}

}
