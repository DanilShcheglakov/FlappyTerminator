using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _rotationSpeed;

	[SerializeField] private float _maxRotationZ;
	[SerializeField] private float _minRotationZ;

	private Vector3 _startPosition;
	private Rigidbody2D _rigidbody;

	private Quaternion _maxRotation;
	private Quaternion _minRotation;

	private void Awake()
	{
		_startPosition = transform.position;
		_rigidbody = GetComponent<Rigidbody2D>();

		_maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
		_minRotation = Quaternion.Euler(0, 0, _minRotationZ);
	}

	private void Update()
	{
		transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
	}

	public void Reset()
	{
		transform.position = _startPosition;
		transform.rotation = Quaternion.identity;
		_rigidbody.velocity = Vector2.zero;
	}

	public void Jump()
	{
		_rigidbody.velocity = new Vector2(_speed, _jumpForce);
		transform.rotation = _maxRotation;
	}
}
