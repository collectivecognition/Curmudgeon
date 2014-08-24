using UnityEngine;
using System.Collections;

public class StealVillageGameEvent : GameEvent {
	public override string text {
		get {
			return "A small settlement sits off the beach with the embers of a fire still smoking.\n\n" +
				"It appears deserted, but the islanders may return at any time. Ye may loot the village for food and treasure. ";
		}
	}
	
	public override string buttonAText {
		get {
			return "Take a Chance";
		}
	}
	
	public override string buttonBText {
		get {
			return "Ignore the Village";
		}
	}
	
	public override void OnButtonAClicked() {
		if(Random.Range (0, 2) == 1){
			Globals.Instance.eventManager.SetGameEvent(new StealVillageSuccessGameEvent());
		}else{
			Globals.Instance.eventManager.SetGameEvent(new StealVillageFailureGameEvent());
		}
	}
	
	public override void OnButtonBClicked() {
	}
}
