using UnityEngine;

[ExecuteInEditMode]
public class AmmoPouchScr : MonoBehaviour
{
	[SerializeField] int i_magSlots;
	public GameObject magSlotPrefab;
	public GameObject[] go_magSlots;

	private void OnValidate()
	{
		UpdateMagSlots();
	}

	private void UpdateMagSlots()
	{
		if (magSlotPrefab == null)
			return;

		if (go_magSlots == null || go_magSlots.Length != i_magSlots)
		{
			// Clear existing slots
			if (go_magSlots != null)
			{
				foreach (var slot in go_magSlots)
				{
					if (slot != null)
						DestroyImmediate(slot);
				}
			}

			// Create new slots
			go_magSlots = new GameObject[i_magSlots];
			for (int i = 0; i < i_magSlots; i++)
			{
				go_magSlots[i] = Instantiate(magSlotPrefab, transform);
			}
		}
	}
}