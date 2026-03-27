using System;
using Godot;

public partial class MainUi : CanvasLayer
{
	[Export] private Label _scoreLabel = null;
	[Export] private BaseButton _fiButton = null;
	[Export] private BaseButton _enButton = null;
	[Export] private BaseButton _closeButton = null;
	[Export] private Control _pauseMenu = null;

	public override void _EnterTree()
	{
		GameManager.Instance.ScoreChanged += OnScoreChanged;
		_fiButton.Pressed += OnFiPressed;
		_enButton.Pressed += OnEnPressed;
		_closeButton.Pressed += ClosePause;
	}

	public override void _ExitTree()
	{
		GameManager.Instance.ScoreChanged -= OnScoreChanged;
		_fiButton.Pressed -= OnFiPressed;
		_enButton.Pressed -= OnEnPressed;
		_closeButton.Pressed -= ClosePause;
	}

	public override void _Ready()
	{
		OnScoreChanged(GameManager.Instance.Score);
		ClosePause();
	}

	public override void _Notification(int what)
	{
		// Notifies about the language change
		if (what == NotificationTranslationChanged)
		{
			OnScoreChanged(GameManager.Instance.Score);
		}
	}

	public void OpenPause()
	{
		_pauseMenu.Show();
		GameManager.Instance.SceneTree.Paused = true;
	}

	public void ClosePause()
	{
		GameManager.Instance.SceneTree.Paused = false;
		_pauseMenu.Hide();
	}

	private void OnScoreChanged(int currentScore)
	{
		if (_scoreLabel != null)
		{
			string localizedScore = Tr("SCORE");
			_scoreLabel.Text = string.Format(localizedScore, currentScore);
		}
	}

	private void OnEnPressed()
	{
		GameManager.Instance.SetLocale("en");
	}

	private void OnFiPressed()
	{
		GameManager.Instance.SetLocale("fi");
	}
}
