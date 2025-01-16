using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class FireBall : MonoBehaviour
{
	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = gameObject.GetComponent<Rigidbody2D>();
	}

	public void Reset()
	{
		_rigidbody.velocity = new Vector2(0, 0);
	}

	public void Delete()
	{
		Destroy(gameObject); ;
	}
}
