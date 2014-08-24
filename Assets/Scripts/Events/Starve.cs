using UnityEngine;
using System.Collections;

public class StarveGameEvent : GameEvent {
	private string crewName;

	public StarveGameEvent () {
		crewName = Globals.Instance.DeleteRandomCrew ();
	}

	public override string text {
		get {
			return crewName + " starved to death.";
		}
	}
	
	public override string buttonAText {
		get {
			return "OK";
		}
	}
	
	public override string buttonBText {
		get {
			return "";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
	}
}
