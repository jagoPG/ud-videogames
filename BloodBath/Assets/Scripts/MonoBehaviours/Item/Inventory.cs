using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static int maxSize = 10;

	public GUIText[] names = new GUIText[maxSize];
	public Item[] items = new Item[maxSize];

	public bool addItem(Item item)
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

	public bool removeItem(Item item)
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
}
