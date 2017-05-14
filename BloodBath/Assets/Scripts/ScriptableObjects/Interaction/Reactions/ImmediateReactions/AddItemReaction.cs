using UnityEngine;

[CreateAssetMenu]
public class AddItemReaction : Reaction
{
	public Item item;
	public bool isGrabbed;

	protected override void SpecificInit()
	{
		this.isGrabbed = false;
	}

	protected override void ImmediateReaction()
	{
		if (!isGrabbed) {
			Debug.Log ("Añadir objeto: " + item.name);

			this.isGrabbed = true;
			Inventory.GetInstance().AddItem (item);

			TextManager.GetInstance().SetText ("You have grabbed " + item.name, 3, null);
		}
	}
}
