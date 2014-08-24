using UnityEngine;
using System.Collections;

public class SpiceDFoundGameEvent : GameEvent {
	public override string text {
		get {
			return "The landing party returns with a bushel of egg shaped arils from a nutmeg tree. Ye have discovered Nutmeg!";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Harvest Nutmeg";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.spiceD = true;
	}
}
