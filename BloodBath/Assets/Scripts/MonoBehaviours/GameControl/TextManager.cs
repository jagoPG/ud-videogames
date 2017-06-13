using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public struct TextInstruction {
		public float startTime;
		public string text;
		public Sprite image;
		public int phraseProgress;
		public float delay;

		public static bool operator == (TextInstruction f1, TextInstruction f2) { return false; }
		public static bool operator != (TextInstruction f1, TextInstruction f2) { return false; }
	};

	private const int CHARACTERS_PER_PHRASE = 140;

	public GameObject conversationText;
	public Image conversationImage;

	// Singleton instance
	private static TextManager instance;
	private Queue<TextInstruction> queue;
	private UnityEngine.UI.Text textLabel;
	private float clearTime = 0F;

	// For displaying several phrases
	private TextInstruction currentText;

	public static TextManager GetInstance()
	{
		return instance;
	}

	public void SetText(string text, float delay, Sprite image)
	{
		float startTime = Time.time;
		clearTime = startTime + delay;

		TextInstruction textInstruction = new TextInstruction {
			startTime = startTime,
			text = text,
			image = image,
			phraseProgress = 0,
			delay = delay
		};

		this.queue.Enqueue (textInstruction);
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
		if (queue.Count == 0 && currentText.text == null) {
			return;
		}

		float currentTime = Time.time;
		if (queue.Count > 0 && currentTime >= currentText.startTime) {
			RetrieveFirstPhrase (currentTime);
		} else if (currentTime >= this.clearTime) {
			if (!IsPhraseFinished ()) {
				this.clearTime = Time.time + currentText.delay;
				currentText.phraseProgress += 1;
				DisplayPhrase (currentTime);
			} else {
				PhraseHasFinished ();
				FreeConversationReference ();
			}
		} else {
			DisplayPhrase (currentTime);
		}
	}

	private void RetrieveFirstPhrase(float currentTime)
	{
		Debug.Log ("Retrieve First Phrase");
		
		this.currentText = queue.Dequeue ();
		DisplayPhrase (currentTime);
	}

	private void DisplayPhrase(float currentTime)
	{
		// Calculate the amount of characters to show
		string text = currentText.text;
		string finalText = "";
		int phraseProgress = currentText.phraseProgress;
		int amountOfCharacters = CalculateEndOfString (text, phraseProgress);

		finalText = text.Substring(phraseProgress * CHARACTERS_PER_PHRASE, amountOfCharacters);
		textLabel.text = finalText;
		conversationText.SetActive(true);

		// Decide if is required to show the sprite
		conversationImage.sprite = currentText.image;
		if (currentText.image == null) {
			conversationImage.enabled = false;
		} else {
			conversationImage.enabled = true;
		}
	}

	private bool IsPhraseFinished()
	{
		int currentIteration = currentText.phraseProgress + 1;

		return currentIteration * CHARACTERS_PER_PHRASE >= currentText.text.Length;
	}

	private void PhraseHasFinished()
	{
		textLabel.text = null;
		conversationImage.sprite = null;
		conversationText.SetActive(false);
	}

	private void FreeConversationReference()
	{
		currentText.text = null;
		currentText.startTime = 0F;
		currentText.delay = 0F;
		currentText.image = null;
		currentText.phraseProgress = 0;
	}


	private static int CalculateEndOfString(string phrase, int progress)
	{
		int startOn = CHARACTERS_PER_PHRASE * progress,
			stringLength = phrase.Length;

		if (stringLength > startOn + CHARACTERS_PER_PHRASE) {
			return CHARACTERS_PER_PHRASE;
		} else {
			return stringLength - startOn;
		}
	}
}
