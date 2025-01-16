using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] Player _player;
	[SerializeField] AlienPool _alienGenerator;
	[SerializeField] StartWindow _startWindow;
	[SerializeField] RestartWindow _restartWindow;

	private void Start()
	{
		Time.timeScale = 0f;
		_startWindow.Open();
		_restartWindow.Close();
	}

	private void OnEnable()
	{
		_player.GameEnd += EndGame;
		_startWindow.PlayButtonClicked += OnPlayButtonClicked;
		_restartWindow.RestartButtonClicked += OnRestartButtonClicked;
	}

	private void OnDisable()
	{
		_player.GameEnd -= EndGame;
		_startWindow.PlayButtonClicked -= OnPlayButtonClicked;
		_restartWindow.RestartButtonClicked -= OnRestartButtonClicked;
	}

	private void OnPlayButtonClicked()
	{
		_startWindow.Close();
		StartGame();
	}

	private void OnRestartButtonClicked()
	{
		_restartWindow.Close();
		StartGame();
	}

	private void EndGame()
	{
		Time.timeScale = 0f;
		_restartWindow.Open();
	}

	private void StartGame()
	{
		Time.timeScale = 1;
		_player.Reset();
		_alienGenerator.Reset();
	}
}
