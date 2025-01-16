using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	private KeyCode _flyButton;
	private KeyCode _fireButton;

	public event Action FlyButtonPressed;
	public event Action FireButtonPressed;

	private void Awake()
	{
		_flyButton = KeyCode.Space;
		_fireButton = KeyCode.F;
	}

	private void Update()
	{
		if (Input.GetKeyDown(_flyButton))
			FlyButtonPressed?.Invoke();

		if (Input.GetKeyDown(_fireButton))
			FireButtonPressed?.Invoke();
	}
}
