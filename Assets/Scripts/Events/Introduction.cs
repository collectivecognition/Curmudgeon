using UnityEngine;
using System.Collections;

public class IntroductionGameEvent : GameEvent {
	public override string text {
		get {
			var ret = "<color=black><size=30>A Request From The King</size></color>\n\n" +
				"Zuurkoolstamppot! Ardappel! Zeebanket! Bread.. beige! Herring.. beige! Potato.. beige! All beige! Colour! Flavor! If the gods hath more beauteous tastes I needest them! Make your leave and return from the new worlds with these spicely treasures.";

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
