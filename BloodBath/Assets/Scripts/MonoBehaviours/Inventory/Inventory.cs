using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public static int maxSize = 10;
	private static Inventory instance;

	public Text[] names = new Text[maxSize];
	public Item[] items = new Item[maxSize];

	public GameObject sampleText;
	public GameObject inventoryPanel;

	public static Inventory GetInstance()
	{
		return instance;
	}

	public void ShowInventory()
	{
		this.PopulateList ();
		inventoryPanel.SetActive (true);
	}

	public void HideInventory()
	{
		inventoryPanel.SetActive (false);
	}

	public bool AddItem(Item item)
	{
		for (int i = 0; i < maxSize; i++) {
			if (items [i] == null) {
				items [i] = item;
			
				return true;
			}
		}

		return false;
	}

	public bool RemoveItem(Item item)
	{
		for (int i = 0; i < maxSize; i++) {
			if (item == items [i]) {
				items [i] = null;
				names [i] = null;

				return true;
			}
		}

		return false;
	}

	protected void Start()
	{
		PopulateList ();
		HideInventory ();
	}

	protected void PopulateList()
	{
		Debug.Log ("Populate item list");

		foreach (var item in items) {
			if (item != null) {
				Debug.Log ("Show item: " + item.name);

				GameObject newText = Instantiate (this.sampleText) as GameObject;
				Text sampleText = newText.GetComponent<Text> ();
				sampleText.text = item.name;
				newText.transform.SetParent (inventoryPanel.transform);
			}
		}
	}

	protected void Awake()
	{
		if (instance == null) {
			Debug.Log ("Menu initialised");

			instance = this;
			DontDestroyOnLoad (this);
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
}
