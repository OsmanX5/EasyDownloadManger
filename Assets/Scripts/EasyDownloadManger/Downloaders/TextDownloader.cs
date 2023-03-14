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
        Action<string> callBackFunction;
        public void DownLoadText(string url, Action<string> OnDownloadComplete)
        {
            callBackFunction = OnDownloadComplete;
            UnityWebRequest webRequest = UnityWebRequest.Get(url);
            Download(webRequest);
        }
        protected override void OnResponse(UnityWebRequest Response)
        {
            base.OnResponse(Response);
            string DownloadedText = Response.downloadHandler.text;
            callBackFunction(DownloadedText);
        }
	}
}