using UnityEngine;
using System.Collections;

public class SpoiledFoodSuccessGameEvent : GameEvent {
	private string food;

	public SpoiledFoodSuccessGameEvent(string providedFood){
		food = providedFood;
	}
	
	public override string text {
		get {
			return "You brave the tainted " + food + " and survive, despite a minor case of the hot sloppies";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Bring Me My Bucket";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
	}
}
