using UnityEngine;
using System.Collections;

public class CrewDeadGameEvent : GameEvent {
	public override string text {
		get {
			return "Your crew members are all dead. You are a terrible captain.";
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
