using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
	[SerializeField] private ScoreCounter _scoreCounter;
	[SerializeField] private TMP_Text _display;

	private void OnEnable()
	{
		_scoreCounter.ScoreChanged += UpdateDisplay;
	}

	private void OnDisable()
	{
		_scoreCounter.ScoreChanged += UpdateDisplay;
	}

	private void UpdateDisplay(int score)
	{
		_display.text = score.ToString();
	}
}
