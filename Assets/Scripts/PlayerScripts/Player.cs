using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerable
{
	[SerializeField] private Mover _mover;
	[SerializeField] private Gun _gun;
	[SerializeField] private InputHandler _input;
	[SerializeField] private ScoreCounter _counter;

	public event Action GameEnd;

	private void OnEnable()
	{
		_input.FlyButtonPressed += Fly;
		_input.FireButtonPressed += Fire;
	}

	private void OnDisable()
	{
		_input.FlyButtonPressed -= Fly;
		_input.FireButtonPressed -= Fire;
	}
	public void Reset()
	{
		_counter.Reset();
		_mover.Reset();
		_gun.Reset();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out IAlianable _) || collision.TryGetComponent<Ground>(out _))
			GameEnd?.Invoke();
	}

	private void Fly()
	{
		_mover.Jump();
	}

	private void Fire()
	{
		_gun.Shoot();
	}
}
