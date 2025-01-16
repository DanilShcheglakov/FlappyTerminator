using System.Collections;
using UnityEngine;

public class AlienPool : ObjectPool<Alien>
{
	[SerializeField] Transform _maxY;
	[SerializeField] Transform _minY;
	[SerializeField] float _generateSpeedPerSecond;

	private WaitForSeconds _delay;

	private void Start()
	{
		_delay = new WaitForSeconds(_generateSpeedPerSecond);

		StartCoroutine(GenerateAliens());
	}

	protected override void SetStartPrefabPreferences(Alien prefab)
	{
		prefab.OnGet(GetRandomYCoordinate());
	}

	private Vector2 GetRandomYCoordinate()
	{
		return new Vector2(transform.position.x, UnityEngine.Random.Range(_minY.position.y, _maxY.position.y));
	}

	private IEnumerator GenerateAliens()
	{
		while (enabled)
		{
			GetObject();
			yield return _delay;
		}
	}
}
