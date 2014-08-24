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
	public Texture2D cursorTexture;

	public CanvasGroup inventoryCanvas;

	[System.NonSerialized] public bool inputActive = false;
	[System.NonSerialized] public int crew = 4;
	[System.NonSerialized] public int gold = 200;
	[System.NonSerialized] public int food = 10;
	[System.NonSerialized] public bool spiceA = false;
	[System.NonSerialized] public bool spiceB = false;
	[System.NonSerialized] public bool spiceC = false;
	[System.NonSerialized] public bool spiceD = false;
	
	public ArrayList crewNames = new ArrayList(new string[] {
		"Will",
		"Sarah",
		"Charlie",
		"Emma",
		"Max",
		"Gus",
		"Eugene",
		"Archibald",
		"Humphrey",
		"Gibbs",
		"Twarby",
		"Dunham",
		"Mowfurth",
		"Stubb",
		"Simeon",
		"Guybrush",
		"Gilmere",
		"Otis",
		"Tobias",
		"Hugh",
		"Maxwell",
		"Ludsthorp",
		"Codsworth",
		"Culpeper",
		"Burt",
		"Lloyd",
		"Yate",
		"Pygott",
		"Hammer",
		"Shotbolt",
		"Al",
		"Scruggs",
		"Jerome",
		"John",
		"Bill",
		"Heth",
		"Smithee",
		"Barbery",
		"Goose",
		"Hardmeat",
		"Cornfoot",
		"Lech",
		"Palfrey",
		"Bonefat",
		"Rattlebag",
		"Loretta",
		"Gertrude",
		"Edith",
		"Marion",
		"Gillian",
		"Ursula",
		"Ruth"
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
		Cursor.SetCursor (cursorTexture, new Vector2 (32f, 32f), CursorMode.Auto);
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
