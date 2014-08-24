using UnityEngine;
using System.Collections;

public class IntroductionGameEvent : GameEvent {
	public override string text {
		get {
			var ret = "Good morrow, humble subject. Listen close, for your King doth speak. I hath for thee a quest... a \"spice\" quest.\n\nI tire of eating like a peasant, with naught but tubers and grain for my stately palate! Color! Flavor! If the gods hath more beauteous tastes I needest them! Make your leave and return from the new worlds with these spicely treasures. ";

			return ret;
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Continue";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.eventManager.SetGameEvent(new IntroductionBGameEvent());
	}
}
