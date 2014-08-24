using UnityEngine;
using System.Collections;

public class FoodForSaleGameEvent : GameEvent {
	private int amount;
	private int price;
	private string food;
	private string shortFood;

	private ArrayList foods = new ArrayList(new string[] {
		"Delicious Stew of Goat and Tubers", "Unctuous Brew of Fermented Fruit"
	});

	private ArrayList shortFoods = new ArrayList(new string[] {
		"Goat Stew", "Fruit Brew"
	});

	public FoodForSaleGameEvent(){
		amount = Random.Range (5, 10);
		price = Random.Range (10, 100);

		int index = Random.Range (0, foods.Count);
		food = (string)foods [index];
		shortFood = (string)shortFoods [index];
	}
	
	public override string text {
		get {
			string ret = "A small tribe of islanders meets ye at the beach, offering " + amount + " " + food + " in exchange for " + price + " gold.";
			if(Globals.Instance.gold < price){
				ret += "\n\nSadly, ye are running low on funds.";
			}else{
				ret += "\n\nDo ye partake??";
			}
			return ret;
		}
	}
	
	public override string buttonAText {
		get {
			if(Globals.Instance.gold >= price){
				return "Purchase " + amount + " " + shortFood + " for " + price + " gold";
			}
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Sail On";
		}
	}
	
	public override void OnButtonAClicked() {
		if(Globals.Instance.gold >= price){
			Globals.Instance.gold -= price;
			Globals.Instance.food += amount;
		}
	}
	
	public override void OnButtonBClicked() {
	}
}
