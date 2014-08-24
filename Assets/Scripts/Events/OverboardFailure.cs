using UnityEngine;
using System.Collections;

public class OverboardFailureGameEvent : GameEvent {
	public string crew;
	public string originalCrew;

	public OverboardFailureGameEvent(string providedOriginalCrew){
		originalCrew = providedOriginalCrew;

		do{
			crew = Globals.Instance.RandomCrew ();
		}while(crew == originalCrew);
	}
	
	public override string text {
		get {
			return crew + " dives heroically into the roiling waves to save " + originalCrew + ".\n\nThey sink like a stone. Perhaps thou shouldt send someone who can swim next time.";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Set Sail Without " + crew + " and " + originalCrew;
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.DeleteCrew (crew);
		Globals.Instance.DeleteCrew (originalCrew);
	}
}
