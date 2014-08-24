using UnityEngine;
using System.Collections;

public class IntroductionBGameEvent : GameEvent {
	public override string text {
		get {
			var ret = "I have provisioned the good ship Curmudgeon with a store of ale, salt fish and sea biscuits for the journey. But be cautious, for running short of men or food will end thy journey. ";
			ret += "A fine crew consisting of ";
			for(int ii = 0; ii < Globals.Instance.crewMembers.Count; ii++){
				if(ii > 0 && ii < Globals.Instance.crewMembers.Count - 1){
					ret += ", ";
				}
				
				if(ii == Globals.Instance.crewMembers.Count - 1){
					ret += " and ";
				}
				
				ret += Globals.Instance.crewMembers[ii];
			}
			ret += " will join you on your journey.\n\n";

			ret += "It will be arduous and fraught with danger, but if thou curry my meats, thou will curry my favor.\n\n" +
			"Go forth and find my spices!";
			
			return ret;
		}
	}
	
	public override string buttonAText {
		get {
			return "";
		}
	}
	
	public override string buttonBText {
		get {
			return "Anchors Aweigh!";
		}
	}
	
	public override void OnButtonAClicked() {
	}
	
	public override void OnButtonBClicked() {
	}
}
