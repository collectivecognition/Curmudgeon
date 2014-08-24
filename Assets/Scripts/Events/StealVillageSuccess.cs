using UnityEngine;
using System.Collections;

public class StealVillageSuccessGameEvent : GameEvent {
	private int amountGold;
	private int amountFood;
	
	public StealVillageSuccessGameEvent(){
		amountGold = Random.Range (10, 100);
		amountFood = Random.Range (5, 10);
	}
	
	public override string text {
		get {
			return "You make off with " + amountGold + " gold and " + amountFood + " food\n\n" +
				"Next time you may not be so lucky!";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Leave With Your Booty";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.gold += amountGold;
		Globals.Instance.food += amountFood;
	}
}
