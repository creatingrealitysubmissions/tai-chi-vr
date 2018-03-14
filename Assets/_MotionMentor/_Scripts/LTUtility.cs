using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LTUtility
{
	public static void ButtonClickWobble(GameObject go) 
	{
		LeanTween.scale(go, Vector3.one * .85f, .05f).setOnComplete(() =>
		{
			LeanTween.cancel(go);
			LeanTween.scale(go, Vector3.one, .4f).setEase(LeanTweenType.easeOutBack);
		});
	}
}
