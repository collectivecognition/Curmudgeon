using UnityEngine;
using System.Collections;

public class OverboardGameEvent : GameEvent {
	public string crew;

	public OverboardGameEvent(){
		crew = Globals.Instance.RandomCrew ();
	}

	public override string text {
		get {
			var ret = "Man overboard! A rogue wave appears and sweeps " + crew + " into the sea.\n\n";

			if(Globals.Instance.crew > 1){
				ret += "As captain ye may risk ordering another sailor into the sea to pull them back aboard.\n\nDo ye take the risk?";
			}

			return ret;
		}
	}
	
	public override string buttonAText {
		get {
			if(Globals.Instance.crew > 1){
				return "Try to Save " + crew;
			}

			return "";
		}
	}
	
	public override string buttonBText {
		get {
			if(Globals.Instance.crew > 1){
				return "Abandon " + crew;
			}else{
				return "Aw Shucks";
			}
		}
	}
	
	public override void OnButtonAClicked() {
		if(Random.Range (0, 2) == 1){
			Globals.Instance.eventManager.SetGameEvent(new OverboardSuccessGameEvent(crew));
		}else{
			Globals.Instance.eventManager.SetGameEvent(new OverboardFailureGameEvent(crew));
		}
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.DeleteCrew (crew);
	}
}
