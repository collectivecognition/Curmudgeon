using UnityEngine;
using System.Collections;

public class WinGameEvent : GameEvent {
	public override string text {
		get {
			return "You found all the King's spices!\n\nAh, what bounty you bring, 'tis most splendid! The kingdom's meals shall be bland no more!\n\n toast to you fine Captain and our enemy's enemies!";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "New Game";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Application.Quit ();
		Application.LoadLevel(Application.loadedLevel);
	}
}
