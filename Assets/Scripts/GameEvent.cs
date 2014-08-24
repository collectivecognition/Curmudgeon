using UnityEngine;
using System.Collections;

public abstract class GameEvent {
	public abstract string text { get; }
	public abstract string buttonAText { get; }
	public abstract string buttonBText { get; }

	public abstract void OnButtonAClicked();

	public abstract void OnButtonBClicked();
}
