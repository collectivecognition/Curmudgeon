using UnityEngine;
using System.Collections;

public class CrewDeadGameEvent : GameEvent {
	public override string text {
		get {
			return "Ye find oneself alone at sea, having lost the last of thy crew. Too ashamed to return to his Majesty the King empty handed, ye abandon ship and live out thy days on the nearest atoll as a crusty hermit.";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Game Over Man. Game Over!";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Application.Quit ();
		Application.LoadLevel(Application.loadedLevel);
	}
}
