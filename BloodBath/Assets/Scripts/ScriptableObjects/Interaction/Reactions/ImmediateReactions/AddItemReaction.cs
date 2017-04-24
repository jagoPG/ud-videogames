using UnityEngine;

[CreateAssetMenu]
public class AddItemReaction : Reaction
{
	public Item item;
	private Inventory inventory;

	protected override void SpecificInit()
	{
		this.inventory = FindObjectOfType<Inventory> ();
	}

	protected override void ImmediateReaction()
	{
		inventory.AddItem (item);
	}
}
