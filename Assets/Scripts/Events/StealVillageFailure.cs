using UnityEngine;
using System.Collections;

public class StealVillageFailureGameEvent : GameEvent {
	private string crew;
	
	public StealVillageFailureGameEvent(){
		crew = Globals.Instance.RandomCrew ();
	}
	
	public override string text {
		get {
			return "The cannibals return whilst you're loading up their worldly posessions.\n\n" + 
				"Unfortunately " + crew + " (being the slowest of your crew) is caught and eaten during your escape.";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Abandon " + crew;
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.DeleteCrew (crew);
	}
}
