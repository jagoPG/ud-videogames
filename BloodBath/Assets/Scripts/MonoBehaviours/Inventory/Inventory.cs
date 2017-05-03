using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static int maxSize = 10;
	private static Inventory instance;

	public UnityEngine.UI.Text[] names = new UnityEngine.UI.Text[maxSize];
	public Item[] items = new Item[maxSize];

	public GameObject propietary;
	public GameObject sampleText;
	public GameObject inventoryPanel;

	public void Start()
	{
		PopulateList ();
	}

	public bool AddItem(Item item)
	{
		for (int i = 0; i < maxSize; i++) {
			if (items [i] == null) {
				items [i] = item;
				names [i].text = item.name;
			
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

	public void PopulateList()
	{
		foreach (var item in items) {
			GameObject newText = Instantiate (this.sampleText) as GameObject;
			UnityEngine.UI.Text sampleText = newText.GetComponent<UnityEngine.UI.Text> ();
			sampleText.text = item.name;
			newText.transform.SetParent (inventoryPanel.transform);
		}
	}
}
