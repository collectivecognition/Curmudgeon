using UnityEngine;
using System.Collections;

public class PiratesGameEvent : GameEvent {
	public override string text {
		get {
			var ret = "A barbaric band of buccaneers boards the ship to ransack your hold of gold.\n\n Do ye take up arms and defend your booty?";
			return ret;
		}
	}
	
	public override string buttonAText {
		get {
			return "Surrender " + Globals.Instance.gold + " Gold";
		}
	}
	
	public override string buttonBText {
		get {
			return "Fight!";
		}
	}
	
	public override void OnButtonAClicked() {
		Globals.Instance.gold = 0;
	}
	
	public override void OnButtonBClicked() {
		if(Random.Range (0, 2) == 1){
			Globals.Instance.eventManager.SetGameEvent(new PiratesSuccessGameEvent());
		}else{
			Globals.Instance.eventManager.SetGameEvent(new PiratesFailureGameEvent());
		}

	}
}
