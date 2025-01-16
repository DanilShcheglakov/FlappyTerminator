using System.Collections.Generic;
using UnityEngine;

public class AlienSkin : MonoBehaviour
{
	[SerializeField] private List<Sprite> _skins;

	public Sprite GetRandom()
	{
		return _skins[Random.Range(0, _skins.Count)];
	}
}
