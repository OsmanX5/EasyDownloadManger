using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	public class AssetBunddleDownloader : InterneDownloader
    {
        public void Download(string url, Action<AssetBundle> onDownloadComplete)
        {
            OnDownloadCompleteCallBack = onDownloadComplete;
            UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle(url);
            StartDownloadingWithRequest(webRequest);
        }
        protected override void OnResponse(UnityWebRequest Response)
        {
            base.OnResponse(Response);
            AssetBundle asset = DownloadHandlerAssetBundle.GetContent(Response);
            OnDownloadCompleteCallBack.DynamicInvoke(asset);
        }
	}

}
