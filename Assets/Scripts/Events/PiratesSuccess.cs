using UnityEngine;
using System.Collections;

public class PiratesSuccessGameEvent : GameEvent {
	public override string text {
		get {
			return "You manage to fight off the bloodthirty pirates and escape with both your gold, and your dignity (mostly) intact.";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Sail On";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
	}
}
