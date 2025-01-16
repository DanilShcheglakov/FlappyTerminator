using System;
using System.Collections;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	private int _score;
	private WaitForSeconds _waitSecond;

	public event Action<int> ScoreChanged;

	private void Awake()
	{
		_waitSecond = new WaitForSeconds(0.75f);
	}

	private void Start()
	{
		StartCoroutine(Scoring());
	}

	public void Add()
	{
		_score++;

		ScoreChanged?.Invoke(_score);
	}

	public void Reset()
	{
		_score = 0;

		ScoreChanged?.Invoke(_score);
	}

	private IEnumerator Scoring()
	{
		while (enabled)
		{
			Add();
			yield return _waitSecond;
		}
	}
}
