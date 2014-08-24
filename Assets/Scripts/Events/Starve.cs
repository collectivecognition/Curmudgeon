using UnityEngine;
using System.Collections;

public class StarveGameEvent : GameEvent {
	private string crewName;

	public StarveGameEvent () {
		crewName = Globals.Instance.DeleteRandomCrew ();
	}

	public override string text {
		get {
			return "\"Prithee sir, mayhap I hath some more?\"\n\n" + crewName + " succumbs to malnourishment.";
		}
	}
	
	public override string buttonBText {
		get {
			return "More Food For Me";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
	}
}
