using UnityEngine;
using System.Collections;

public class OverboardSuccessGameEvent : GameEvent {
	public string crew;
	public string originalCrew;

	public OverboardSuccessGameEvent(string providedOriginalCrew){
		originalCrew = providedOriginalCrew;

		do{
			crew = Globals.Instance.RandomCrew ();
		}while(crew == originalCrew);
	}
	
	public override string text {
		get {
			return crew + " braves the roiling sea and drags " + originalCrew + " back aboard in the nick of time. Take that, rogue wave!";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Set Sail";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
	}
}
