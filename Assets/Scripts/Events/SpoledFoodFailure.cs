using UnityEngine;
using System.Collections;

public class SpoiledFoodFailureGameEvent : GameEvent {
	private string food;
	private string crew;

	private ArrayList illnesses = new ArrayList (new string[] {
		"oozing boils", "trots", "piles", "chronic gas"
	});
	private string illness;
	
	public SpoiledFoodFailureGameEvent(string providedFood){
		food = providedFood;
		crew = Globals.Instance.RandomCrew ();
		illness = (string)illnesses [Random.Range (0, illnesses.Count)];
	}
	
	public override string text {
		get {
			return "While most of the crew finds the " + food + " agreeable enough, " + crew + " develops " + illness + " so offensive that they have to be thrown overboard.";
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Good Riddance";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
		Globals.Instance.DeleteCrew (crew);
	}
}
