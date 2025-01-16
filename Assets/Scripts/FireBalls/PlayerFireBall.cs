using UnityEngine;
using System;

public class PlayerFireBall : FireBall, IPlayerable, IPoolable<PlayerFireBall>
{
	public event Action<PlayerFireBall> Collising;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<Ground>(out _) || collision.TryGetComponent(out IAlianable _))
			Collising?.Invoke(this);
	}
}
