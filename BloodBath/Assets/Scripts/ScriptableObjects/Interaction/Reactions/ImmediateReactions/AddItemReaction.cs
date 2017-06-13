using UnityEngine;

[CreateAssetMenu]
public class AddItemReaction : Reaction
{
	public Item item;
	public bool isGrabbed;
	public AudioClip open;
	public AudioSource audio;

	protected override void SpecificInit()
	{
		this.isGrabbed = false;
	}

	protected override void ImmediateReaction()
	{
		if (!isGrabbed) {
			Debug.Log ("Añadir objeto: " + item.name);

			// Add item
			this.isGrabbed = true;
			Inventory.GetInstance().AddItem (item);
			TextManager.GetInstance ().SetText ("You have grabbed " + item.name, 3, null);

			// Play sound if it is set
			if (null != audio) {
				Debug.Log ("Play audio");
				audio.PlayOneShot(open, 0.7F);
			}
		}
	}
}
