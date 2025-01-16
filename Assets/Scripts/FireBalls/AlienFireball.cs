using System;
using UnityEngine;

public class AlienFireball : FireBall, IAlianable, IPoolable<AlienFireball>
{
	public event Action<AlienFireball> Collising;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<Ground>(out _) || collision.TryGetComponent(out IPlayerable _))
			Collising?.Invoke(this);
	}	
}
