using System;
using UnityEngine.UI;

public class StartWindow : Window
{
	public event Action PlayButtonClicked;

	public override void Close()
	{
		WindowGroup.alpha = 0f;
		ActionButton.interactable = false;

		gameObject.GetComponent<GraphicRaycaster>().enabled = false;
	}

	public override void Open()
	{
		WindowGroup.alpha = 1f;
		ActionButton.interactable = true;

		gameObject.GetComponent<GraphicRaycaster>().enabled = true;
	}

	protected override void OnButtonClick()
	{
		PlayButtonClicked?.Invoke();
	}
}
