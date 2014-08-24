using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogoGameEvent : GameEvent {
	public override string text {
		get {
			return "";
		}
	}
	
	public override string buttonAText {
		get {
			return "New Game";
		}
	}
	
	public override string buttonBText {
		get {
			return "";
		}
	}
	
	public override void OnButtonAClicked() {
		Globals.Instance.eventManager.logo.GetComponent<Image> ().enabled = false;
		Globals.Instance.eventManager.SetGameEvent (new IntroductionGameEvent ());
	}
	
	public override void OnButtonBClicked() {
	}
}
