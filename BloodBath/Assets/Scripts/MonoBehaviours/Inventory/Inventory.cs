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

	public GameObject inventoryPanel;
	public GameObject inventoryDescription;
	public GameObject inventoryItemsWrapper;
	public Image inventoryImage;

	private int selectedIndex;
	private int amountOfItems = 0;
	private Text[] labels;
	private Text description;

	public static Inventory GetInstance()
	{
		return instance;
	}

	public void ShowInventory()
	{
		this.selectedIndex = 0;
		this.PopulateList ();
		inventoryPanel.SetActive (true);
		this.UpdateSelectedItem ();
	}

	public void HideInventory()
	{
		inventoryPanel.SetActive (false);
	}

	private void UpdateSelectedItem()
	{
		Item item = items [selectedIndex];

		if (item == null) {
			inventoryImage.enabled = false;
			inventoryDescription.SetActive (false);

			return;
		} 

		Text label = labels [selectedIndex];
		label.color = new Color(255, 165, 0);

		if (item != null) {
			description.text = item.description;
			inventoryDescription.SetActive (true);

			if (item.sprite == null) {
				inventoryImage.enabled = false;
			} else {
				inventoryImage.sprite = item.sprite;
				inventoryImage.enabled = true;
			}
		}
	}

	public void moveUp()
	{
		if (selectedIndex != 0) {
			labels [selectedIndex].color = Color.white;
			selectedIndex--;
		}

		UpdateSelectedItem ();
	}

	public void moveDown()
	{
		if (selectedIndex < labels.Length && selectedIndex < amountOfItems) {
			labels [selectedIndex].color = Color.white;
			selectedIndex++;
		}

		UpdateSelectedItem ();
	}

	public bool AddItem(Item item)
	{
		for (int i = 0; i < maxSize; i++) {
			if (items [i] == null) {
				items [i] = item;
				amountOfItems++;

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
				amountOfItems--;

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
		for (var index = 0; index < labels.Length; index++) {
			Text child = (Text) labels[index];
			child.text = "";
			child.color = Color.white;
		}
		for (var index = 0; index < items.Length; index++) {
			Item item = items [index];
			if (item != null) {
				Text label = labels[index];
				label.text = item.name;
			}
		}
	}

	protected void Awake()
	{
		if (instance == null) {
			Debug.Log ("Menu initialised");

			instance = this;
			DontDestroyOnLoad (this);
			inventoryPanel.SetActive (false);
			description = inventoryDescription.GetComponentInChildren<Text> ();
			labels = inventoryItemsWrapper.GetComponentsInChildren<Text> ();
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
}
