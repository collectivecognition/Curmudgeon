using UnityEngine;
using System.Collections;

public class SpiceAFoundGameEvent : GameEvent {
	public override string text {
		get {
			return "The landing party returns with a flowering vine thick with spicy berries. Ye have discovered Pepper!";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Harvest Pepper";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.spiceA = true;
	}
}
