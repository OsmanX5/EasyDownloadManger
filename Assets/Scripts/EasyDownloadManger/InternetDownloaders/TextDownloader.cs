using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	class TextDownloader : InterneDownloader
    {
        public void DownLoadText(string url, Action<string> OnDownloadComplete)
        {
	        OnDownloadCompleteCallBack = OnDownloadComplete;
            UnityWebRequest webRequest = UnityWebRequest.Get(url);
            Download(webRequest);
        }
        protected override void OnResponse(UnityWebRequest Response)
        {
            base.OnResponse(Response);
            string DownloadedText = Response.downloadHandler.text;
            OnDownloadCompleteCallBack.DynamicInvoke(DownloadedText);
        }
	}
}