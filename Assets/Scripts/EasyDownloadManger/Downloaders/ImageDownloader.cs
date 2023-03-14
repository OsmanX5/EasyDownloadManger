using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	class ImageDownloader : InterneDownloader
    {
		Action<Texture2D> OnDownloadCompleteCallBack;
        public void DownLoadImage(string url, Action<Texture2D> onDownloadComplete)
		{
            OnDownloadCompleteCallBack = onDownloadComplete;
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
			Download(webRequest);
        }
        protected override void OnResponse(UnityWebRequest Response)
		{
            base.OnResponse(Response);
            Texture2D DownloadedTexture = DownloadHandlerTexture.GetContent(Response);
            OnDownloadCompleteCallBack(DownloadedTexture);
        }
	}
}
