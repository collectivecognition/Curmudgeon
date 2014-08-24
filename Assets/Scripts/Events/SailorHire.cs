using UnityEngine;
using System.Collections;

public class SailorHireGameEvent : GameEvent {
	private int amount;
	private string crew;
	
	public SailorHireGameEvent(){
		crew = Globals.Instance.RandomCrewName ();
		amount = Random.Range (10, 100);
	}
	
	public override string text {
		get {
			string ret = "A young ruffian named " + crew + " offers to join your crew in exchange for fair pay of " + amount + " gold. He is slightly odiferous but looks beefy enough to rig a sail.";
			if(Globals.Instance.gold < amount){
				ret += "\n\nUnfortunately ye are ill equipped to pay them.";
			}else{
				ret += "\n\nWhat say you?";
			}
			return ret;
		}
	}
	
	public override string buttonAText {
		get {
			if(Globals.Instance.gold >= amount){
				return "Hire " + crew + " for " + amount + " gold";
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
		if(Globals.Instance.gold >= amount){
			Globals.Instance.gold -= amount;
			Globals.Instance.AddCrew (crew);
		}
	}
	
	public override void OnButtonBClicked() {
	}
}
