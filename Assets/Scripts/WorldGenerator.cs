using UnityEngine;
using System;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	public GameObject islandPrefab;

	private float minIslandDistance = 40.0f;
	private float maxIslandDistance = 80.0f;

	private ArrayList gameEvents = new ArrayList (new Type[] {
		typeof(FoodForSaleGameEvent),
		typeof(FoodFoundGameEvent),
		typeof(SailorHireGameEvent),
		typeof(OverboardGameEvent),
		typeof(PiratesGameEvent),
		typeof(SpoiledFoodGameEvent),
		typeof(ShipwreckGameEvent),
		typeof(SpiceAFoundGameEvent),
		typeof(SpiceBFoundGameEvent),
		typeof(SpiceCFoundGameEvent),
		typeof(SpiceDFoundGameEvent),
		typeof(StealVillageGameEvent),
		typeof(TreasureFoundGameEvent),
		typeof(OverboardGameEvent),
		typeof(PiratesGameEvent),
		typeof(SpoiledFoodGameEvent)
	});

	private ArrayList islands = new ArrayList();

	void Start () {

		// Shuffle events

		System.Random random = new System.Random();

		for (int i = 0; i < 10000; i++){
			var eventA = random.Next(gameEvents.Count);
			var eventB = random.Next(gameEvents.Count);
			
			var temp = gameEvents[eventA];
			gameEvents[eventA] = gameEvents[eventB];
			gameEvents[eventB] = temp;
		}

		// Generate islands for each event
		// FIXME: Ugly as ***k, brute force.. Just.. ew..

		foreach(var gameEventType in gameEvents){
			GameObject island = (GameObject)Instantiate (islandPrefab);
			island.GetComponent<IslandGenerator>().gameEvent = (GameEvent)((Type)gameEventType).GetConstructor(new Type[]{}).Invoke(new object[]{});

			bool done = false;
			Vector3 pos = Vector3.zero;

			while(!done){

				// Pick a random island to be next to

				Vector3 neighborPos = Vector3.zero;
				if(islands.Count > 0){
					neighborPos = ((GameObject)islands[UnityEngine.Random.Range (0, islands.Count)]).transform.position;
				}
				Vector3 randomPos = UnityEngine.Random.insideUnitSphere * maxIslandDistance;
				randomPos = new Vector3(randomPos.x, 0, randomPos.y);
				randomPos += neighborPos;

				// Make sure we're not too close to another island (or home)

				bool tooClose = false;

				if(Vector3.Distance(randomPos, Vector3.zero) < minIslandDistance){
					tooClose = true;
				}else{
					foreach(GameObject checkIsland in islands){
						if(Vector3.Distance(randomPos, checkIsland.transform.position) < minIslandDistance){
							tooClose = true;
						}
					}
				}

				if(!tooClose){
					pos = randomPos;
					done = true;
				}
			}

			island.transform.position = pos;

			islands.Add(island);
		}
	}
}
