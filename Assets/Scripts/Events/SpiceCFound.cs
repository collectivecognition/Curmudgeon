using UnityEngine;
using System.Collections;

public class SpiceCFoundGameEvent : GameEvent {
	public override string text {
		get {
			return "The landing party returns with collection of pale gnarly roots. They have a juicy tang. Ye have discovered Ginger! ";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Harvest Ginger";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.spiceC = true;
	}
}
