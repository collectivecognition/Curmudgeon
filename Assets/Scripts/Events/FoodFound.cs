using UnityEngine;
using System.Collections;

public class FoodFoundGameEvent : GameEvent {
	private ArrayList foods = new ArrayList(new string[] {
		"Coconuts", "Rodents", "Crayfish", "Mangoes"
	});

	private string food;
	private int amount;
	
	public FoodFoundGameEvent(){
		food = (string)foods [Random.Range (0, foods.Count)];
		amount = Random.Range (10, 30);
	}
	
	public override string text {
		get {
			return "The landing party returns with a bounty of " + food;
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Harvest " + amount + " " + food;
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.food += amount;
	}
}
