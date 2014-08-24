using UnityEngine;
using System.Collections;

public class TreasureFoundGameEvent : GameEvent {
	private int amount;
	
	public TreasureFoundGameEvent(){
		amount = Random.Range (10, 100);
	}
	
	public override string text {
		get {
			return "Ye note a suspicious heap of sand on the beach. Your spade reveals a booty of gold! ";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Collect " + amount + " gold";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.gold += amount;
	}
}
