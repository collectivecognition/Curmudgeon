using UnityEngine;
using System.Collections;

public class ShipwreckGameEvent : GameEvent {
	private string crew;

	public ShipwreckGameEvent(){
		crew = Globals.Instance.RandomCrewName();
	}

	public override string text {
		get {
			return "A disheveled hermit emerges hysterically from the bushes...\n\n" +
				"\"Shipwrecked, I was! " + crew + " be my name!\"\n\n" +
				"Despite a hint of madness in their eyes, ye invite them to join your crew.";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Add " + crew + " To Your Crew";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.AddCrew (crew);
	}
}
