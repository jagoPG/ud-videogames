using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public struct TextInstruction {
		public float startTime;
		public string text;
		public Sprite image;
	};

	// Singleton instance
	private static TextManager instance;
	private Queue<TextInstruction> queue;
	private UnityEngine.UI.Text textLabel;
	private float clearTime;
	TextInstruction currentText;

	public GameObject conversationText;
	public Image conversationImage;

	public static TextManager GetInstance()
	{
		return instance;
	}

	private void Awake ()
	{
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
			queue = new Queue <TextInstruction>();
			conversationText.SetActive (false);
			textLabel = instance.conversationText.GetComponentInChildren<Text> ();
		} if (instance != this) {
			Destroy (gameObject);
		}
	}

	private void Update()
	{
		float currentTime = Time.time;

		if (queue.Count > 0 && currentTime >= currentText.startTime) {
			currentText = queue.Dequeue ();
			textLabel.text = currentText.text;
			conversationText.SetActive(true);
			conversationImage.sprite = currentText.image;

			if (currentText.image == null) {
				conversationImage.enabled = false;
			} else {
				conversationImage.enabled = true;
			}
		} else if (currentTime >= clearTime) {
			textLabel.text= string.Empty;
			conversationImage.sprite = null;
			conversationText.SetActive(false);
		}
	}

	public void SetText(string text, float delay, Sprite image)
	{
		float startTime = Time.time;
		clearTime = startTime + delay;

		TextInstruction textInstruction = new TextInstruction {
			startTime = startTime,
			text = text,
			image = image
		};

		this.queue.Enqueue (textInstruction);
	}
}
