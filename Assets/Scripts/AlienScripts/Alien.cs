using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Alien : MonoBehaviour, IAlianable, IPoolable<Alien>
{
	[SerializeField] private Transform _shootPoint;
	[SerializeField] private AlienFireballsPool _fireBallPool;
	[SerializeField] private AlienSkin _skin;
	[SerializeField] private float _fireballSpeed;
	[SerializeField] private float _fireballSpeedGenerate;

	private SpriteRenderer _renderer;
	private WaitForSeconds _delayOfShooting;
	private Coroutine _shoot;

	public event Action<Alien> Collising;

	private void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_delayOfShooting = new WaitForSeconds(_fireballSpeedGenerate);
	}

	private void Start()
	{
		SetNewSkin(_skin.GetRandom());
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<IPlayerable>(out _) || collision.gameObject.TryGetComponent<Ground>(out _))
			Collising?.Invoke(this);
	}

	public void SetSprite(Sprite sprite)
	{
		_renderer.sprite = sprite;
	}

	public void SetNewSkin(Sprite skin)
	{
		_renderer.sprite = skin;
	}

	private IEnumerator Shoot()
	{
		while (enabled)
		{
			var fireball = _fireBallPool.GetObject();

			Rigidbody2D fireballRigidbody = fireball.gameObject.GetComponent<Rigidbody2D>();

			Vector2 fireballDirection = new Vector2(-_fireballSpeed, 0);

			fireballRigidbody.velocity = fireballDirection;

			yield return _delayOfShooting;
		}
	}

	public void Reset()
	{
		SetNewSkin(_skin.GetRandom());

		if (_shoot != null)
			StopCoroutine(_shoot);
	}

	public void OnGet(Vector2 position)
	{
		SetNewSkin(_skin.GetRandom());
		transform.position = position;
		gameObject.SetActive(true);
		_shoot = StartCoroutine(Shoot());
	}

	public void Delete()
	{
		_fireBallPool.Reset();
		Destroy(gameObject);
	}
}
