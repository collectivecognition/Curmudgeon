using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Globals : MonoBehaviour {
	
	private static Globals m_Instance;
	public static Globals Instance { get { return m_Instance; } }

	public EventManager eventManager;
	
	public Text crewValue;
	public Text goldValue;
	public Text foodValue;
	public Text spiceAValue;
	public Text spiceBValue;
	public Text spiceCValue;
	public Text spiceDValue;

	public CanvasGroup inventoryCanvas;

	[System.NonSerialized] public bool inputActive = false;
	[System.NonSerialized] public int crew = 1;
	[System.NonSerialized] public int gold = 200;
	[System.NonSerialized] public int food = 40;
	[System.NonSerialized] public bool spiceA = false;
	[System.NonSerialized] public bool spiceB = false;
	[System.NonSerialized] public bool spiceC = false;
	[System.NonSerialized] public bool spiceD = false;
	
	public ArrayList crewNames = new ArrayList(new string[] {
		"Bob",
		"Will",
		"Sarah",
		"Ted",
		"Jim",
		"Charlie",
		"Emma",
		"Max",
		"Lionel"
	});
	public ArrayList crewMembers = new ArrayList();

	public string AddRandomCrew(){
		int index = Random.Range (0, crewNames.Count);
		string name = (string)crewNames [index];
		crewMembers.Add (name);
		crewNames.RemoveAt (index);
		return name;
	}

	public string AddCrew(string name){
		crewNames.Remove (name);
		crewMembers.Add (name);
		crew++;
		return name;
	}

	public string RandomCrewName(){
		return (string)crewNames [Random.Range (0, crewNames.Count)];
	}

	public string RandomCrew(){
		return (string)crewMembers [Random.Range (0, crewMembers.Count)];
	}

	public void DeleteCrew(string name){
		crewMembers.Remove (name);
		crew--;
	}
	
	public string DeleteRandomCrew(){
		crew --;
		int index = Random.Range (0, crewMembers.Count);
		string name = (string)crewMembers [index];
		crewMembers.RemoveAt (index);
		return name;
	}
	
	void Awake()
	{
		m_Instance = this;

		for(int ii = 0; ii < crew; ii++){
			AddRandomCrew ();
		}
	}
	
	void OnDestroy()
	{
		m_Instance = null;
	}

	void Start(){

	}
	
	void Update(){
		crewValue.text = crew.ToString ();
		goldValue.text = gold.ToString ();
		foodValue.text = food.ToString ();
		spiceAValue.text = spiceA ? "X" : "-";
		spiceBValue.text = spiceB ? "X" : "-";
		spiceCValue.text = spiceC ? "X" : "-";
		spiceDValue.text = spiceD ? "X" : "-";
	}
}
