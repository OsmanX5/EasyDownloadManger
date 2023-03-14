using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
	public GameObject infoScreen;
	protected GameObject created;
	protected TMP_Text infoText;

	public void clear()
	{
		infoText = infoScreen.GetComponent<TMP_Text>();
		infoText.text = "";
		if (infoScreen.transform.childCount > 0)
		{
			Destroy(infoScreen.transform.GetChild(0).gameObject);
		}
	}
}
