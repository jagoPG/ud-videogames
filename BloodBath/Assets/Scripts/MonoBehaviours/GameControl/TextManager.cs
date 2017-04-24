using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

	public struct TextInstruction {
		public float startTime;
		public string text;
	};

	// Singleton instance
	private static TextManager instance;
	private Queue<TextInstruction> queue;
	private UnityEngine.UI.Text textLabel;
	private float clearTime;
	TextInstruction currentText;

	public GameObject conversationText;

	public static TextManager getInstance()
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
			textLabel = instance.conversationText.GetComponentInChildren<UnityEngine.UI.Text> ();
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
		} else if (currentTime >= clearTime) {
			textLabel.text= string.Empty;
			conversationText.SetActive(false);
		}
	}

	public void SetText(string text, float delay)
	{
		float startTime = Time.time;
		clearTime = startTime + delay;

		TextInstruction textInstruction = new TextInstruction {
			startTime = startTime,
			text = text,
		};

		this.queue.Enqueue (textInstruction);
	}
}
