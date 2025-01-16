using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] private PlayerFireballsPool _fireballPool;
	[SerializeField] private float _fireballSpeed;

	private float _secondsDelay = 0.5f;
	private bool _isRecharged;
	private WaitForSeconds _delay;

	private Coroutine _recharge;

	private void Awake()
	{
		_isRecharged = true;
		_delay = new WaitForSeconds(_secondsDelay);
	}

	public void Reset()
	{
		_fireballPool.Reset();
	}

	public void Shoot()
	{
		if (_isRecharged == true)
		{
			var fireball = _fireballPool.GetObject();

			Vector2 fireballDirection = new Vector2(_fireballSpeed * Mathf.Cos(fireball.transform.rotation.z), _fireballSpeed * Mathf.Sin(fireball.transform.rotation.z));

			fireball.GetComponent<Rigidbody2D>().velocity = fireballDirection;

			_isRecharged = false;

			if (_recharge != null)
				StopCoroutine(_recharge);

			_recharge = StartCoroutine(Recharge());
		}
	}

	private IEnumerator Recharge()
	{
		yield return _delay;

		_isRecharged = true;
	}
}
