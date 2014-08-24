using UnityEngine;
using System.Collections;

public class SpiceBFoundGameEvent : GameEvent {
	public override string text {
		get {
			return "The landing party returns with sweet smelling shavings of reddish tree bark. Ye have discovered Cinnamon!";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Harvest Cinnamon";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.spiceB = true;
	}
}
