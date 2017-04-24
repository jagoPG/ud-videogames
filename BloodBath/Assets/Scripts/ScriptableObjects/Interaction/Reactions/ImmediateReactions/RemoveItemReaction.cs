using UnityEngine;

[CreateAssetMenu]
public class RemoveItemReaction : Reaction
{
	public Item item;
	private Inventory inventory;

	protected override void SpecificInit()
	{
		this.inventory = FindObjectOfType<Inventory> ();
	}

	protected override void ImmediateReaction()
	{
		inventory.RemoveItem (item);
	}
}
