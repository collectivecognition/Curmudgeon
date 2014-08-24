using UnityEngine;
using System.Collections;

public class SpoiledFoodGameEvent : GameEvent {
	private int amount;

	private ArrayList foods = new ArrayList(new string[] {
		"Honey", "Apple", "Grog", "Raisin"
	});
	private string food;

	private ArrayList containers = new ArrayList (new string[] {
		"Vat", "Bushel", "Pit", "Barrel"
	});
	private string container;

	public SpoiledFoodGameEvent(){
		amount = Random.Range (1, 6);
		food = (string)foods [Random.Range (0, foods.Count)];
		container = (string)containers [Random.Range (0, containers.Count)];
	}

	public override string text {
		get {
			var ret = "The vermin get into the " + food + " " + container + ". What's left smells a bit rotten.\n\nDo you eat the tainted food anyway, or toss it overboard?";
			return ret;
		}
	}
	
	public override string buttonAText {
		get {
			return "Toss " + amount + " " + food;
		}
	}
	
	public override string buttonBText {
		get {
			return "Just Eat It";
		}
	}
	
	public override void OnButtonAClicked() {
		Globals.Instance.food -= amount;
	}
	
	public override void OnButtonBClicked() {
		if(Random.Range (0, 2) == 1){
			Globals.Instance.eventManager.SetGameEvent(new SpoiledFoodSuccessGameEvent(food));
		}else{
			Globals.Instance.eventManager.SetGameEvent(new SpoiledFoodFailureGameEvent(food));
		}
		
	}
}
