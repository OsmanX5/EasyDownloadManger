using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ImageTest : Test
{
	public void ShowData(Texture2D data)
	{
		clear();
		CreatObject();
		Image testImage;
		created.AddComponent<RectTransform>();
		created.AddComponent<CanvasRenderer>();
		testImage = created.AddComponent<Image>();
		created.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		created.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 350);
		Rect rect = new Rect(0,0,600,350);
		testImage.sprite = Sprite.Create(data, rect,Vector2.zero);
	}
}
