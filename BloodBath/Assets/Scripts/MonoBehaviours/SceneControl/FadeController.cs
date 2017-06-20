using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour {

	private static FadeController instance;
	private SpriteRenderer sprite;

	public static FadeController GetInstance()
	{
		return instance;
	}

	private void Start() {
		if (FadeController.instance == null) {
			FadeController.instance = this;
			GameObject fadeLayer = GameObject.FindGameObjectWithTag ("BlackBg");
			Debug.Log (fadeLayer == null);
			sprite = fadeLayer.GetComponent<SpriteRenderer> ();
			Debug.Log (sprite.color.a);
		} else {
			Destroy (this);
		}
	}

	public void FadeOut()
	{
		StartCoroutine(doFadeOut (sprite));
	}

	public void FastFadeIn()
	{
		StartCoroutine (doFastFadeIn (sprite));
	}

	public void FastFadeOut()
	{
		StartCoroutine (doFastFadeOut (sprite));
	}

	private IEnumerator doFadeOut(SpriteRenderer sprite) {
		Color tmp = sprite.color;

		for (float i = 0; i < 1; i += 0.05F) {
			tmp.a = i;
			sprite.color = tmp;

			yield return new WaitForSeconds (0.05F);
		}
	}

	private IEnumerator doFastFadeOut(SpriteRenderer sprite) {
		Color tmp = sprite.color;

		for (float i = 0; i < 1; i += 0.05F) {
			tmp.a = i;
			sprite.color = tmp;

			yield return new WaitForSeconds (0.1F);
		}
	}

	private IEnumerator doFastFadeIn(SpriteRenderer sprite) {
		Color tmp = sprite.color;

		for (float i = 1; i > 0; i -= 0.05F) {
			tmp.a = i;
			sprite.color = tmp;

			yield return new WaitForSeconds (0.1F);
		}
	}
}
