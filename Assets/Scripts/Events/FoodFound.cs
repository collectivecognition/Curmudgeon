using UnityEngine;
using System.Collections;

public class FoodFoundGameEvent : GameEvent {
	private ArrayList foods = new ArrayList(new string[] {
		"Coconuts", "Rats", "Crayfish", "Mangoes"
	});

	private string food;
	private int amount;
	
	public FoodFoundGameEvent(){
		food = (string)foods [Random.Range (0, foods.Count)];
		amount = Random.Range (1, 6);
	}
	
	public override string text {
		get {
			return "The landing party returns from foraging in dense jungle on the island with a bounty of " + food + ".";
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
