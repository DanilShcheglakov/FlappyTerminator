using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
{
	[SerializeField] private Transform _container;
	[SerializeField] private T _prefab;

	private Queue<T> _prefabs;
	private List<T> _allObjects;

	private void Awake()
	{
		_prefabs = new Queue<T>();
		_allObjects = new List<T>();
	}

	public T GetObject()
	{
		T prefab;

		if (_prefabs.Count == 0)
		{
			prefab = Instantiate(_prefab);
			SetStartPrefabPreferences(prefab);

			prefab.Collising += PutObject;

			_allObjects.Add(prefab);

			return prefab;
		}

		prefab = _prefabs.Dequeue();
		SetStartPrefabPreferences(prefab);
		prefab.Collising += PutObject;

		return prefab;
	}

	public void Reset()
	{
		foreach (var item in _allObjects)
			item.Delete();

		_allObjects.Clear();
		_prefabs.Clear();
	}

	protected virtual void SetStartPrefabPreferences(T prefab)
	{
		prefab.transform.position = _container.transform.position;
		prefab.transform.rotation = _container.transform.rotation;
		prefab.gameObject.SetActive(true);
	}

	private void PutObject(T prefab)
	{
		prefab.Reset();
		prefab.gameObject.SetActive(false);
		prefab.Collising -= PutObject;
		_prefabs.Enqueue(prefab);
	}
}
