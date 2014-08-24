using UnityEngine;
using System.Collections;

public class PiratesFailureGameEvent : GameEvent {
	public string crew;
	
	public PiratesFailureGameEvent(){
		crew = Globals.Instance.RandomCrew ();
	}

	public override string text {
		get {
			return "The pirates shrug off your pitiful attempt at self defence and make off with all your gold.\n\nTo teach you a lesson they force " + crew + " to walk the plank.";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Run Home To Your Mama";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.gold = 0;
		Globals.Instance.DeleteCrew (crew);
	}
}