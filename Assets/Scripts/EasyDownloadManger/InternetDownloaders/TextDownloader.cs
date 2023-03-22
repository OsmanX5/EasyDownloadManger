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
        public override void Download(string url, Delegate OnDownloadComplete)
        {
	        OnDownloadCompleteCallBack = OnDownloadComplete;
            UnityWebRequest webRequest = UnityWebRequest.Get(url);
            StartDownloadingWithRequest(webRequest);
        }
        protected override void OnResponse(UnityWebRequest Response)
        {
            base.OnResponse(Response);
            string DownloadedText = Response.downloadHandler.text;
            OnDownloadCompleteCallBack.DynamicInvoke(DownloadedText);
        }
	}
}