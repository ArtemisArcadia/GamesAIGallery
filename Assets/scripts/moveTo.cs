    // MoveTo.cs
    using UnityEngine;
	using System.Collections.Generic;
    using System.Collections;
	using NPBehave;
	using UnityEngine.AI;
 	using System.Linq;

    public class moveTo : MonoBehaviour {
	const string target_position = "targetPosition";
	const string target = "currentTarget";
	const string agentPos = "agentPosition";
	const string distAway = "distanceAway";
	const string exhibitsNotSeen = "exhibitonsNotSeen";
	private List <GameObject> exhibitions = new List<GameObject>();
	public GameObject exit;
	private Root behaviourTree;
	private Blackboard blackboard;
	private int exhibitNumber;
	void Start () {
		//Destroy (this.gameObject);
		foreach(GameObject goal in GameObject.FindGameObjectsWithTag("goal")) {

			exhibitions.Add(goal);
		}


		//picks random exhibit 
		//exhibitNumber = UnityEngine.Random.Range(0, exhibitions.Length);
//		if (exhibitNumber == exhibitions.Length) {
//			exhibitNumber = 0;
//		}
		// moves to point, updates point, then moves to the next point
		//blackboard = behaviourTree.Blackboard;
		behaviourTree = new Root(
			new Service(0.5f, byeBye,
				
			new Repeater(
					
				new Sequence(
						
					new Action(NewViewPoint),
				    new NavMoveTo(GetComponent<NavMeshAgent>(), target, 2.0f),
					new Action(localAvoidance),
					new Wait(UnityEngine.Random.Range(2.0f, 3.0f)),
					new Action(seenExhibit)
//
				)
			)
			)

			//new Service(0.5f, Proximity,
//				new Repeater(
//				new Sequence(
//					new Action(NewViewPoint),
//
//					new NavMoveTo(GetComponent<NavMeshAgent>(), target),
//						new Wait(UnityEngine.Random.Range(0.0f, 6.0f))					
//
//					//move to viewing point, add if there's less people, add if not seen already
//				)
//				)
//			)
				

		);
		//for realtime debugging
		Debugger debugger = (Debugger)this.gameObject.AddComponent(typeof(Debugger));
		debugger.BehaviorTree = behaviourTree;

		//sets the first target to be the first point in the array
		//moved to GoToNewViewpoint
	    //behaviourTree.Blackboard.Set (target, exhibitions [exhibitNumber].transform.position);
		behaviourTree.Start ();


	}
    
	// Update is called once per frame
	void Update () {

		//UnityEngine.AI.NavMeshAgent 
	//	agent.destination = exhibits[exhibitToView].transform.position;

		//if (agent.nextPosition == exhibits[exhibitToView].transform.position) {
	//		exhibitToView++;
			
	//	}

	}


	//switches the agents navmeshagent off and turn the obstacle component on
	//when it gets to its destination, allowing other agents to avoid it.
	void localAvoidance(){
		GetComponent<NavMeshObstacle> ().enabled = true;
		GetComponent<NavMeshAgent> ().enabled = false;

	}
	//turns the navmesh back on and turns obstacle off, if both are on it tries to avoid itself,
	//a little buffer zone on the z-axis using stayAway,
	//if the agent has no exhbitions left to view, it moves to the exit point,
	//otherwise, it chooses a random exhibit it hasnt seen, and makes that it's target,
	//tempList for experimenting with how to store which exhibits have been seen
	void NewViewPoint(){
		GetComponent<NavMeshObstacle> ().enabled = false;
		GetComponent<NavMeshAgent> ().enabled = true;

	//List <GameObject> tempList = new List<GameObject> ();
		//uses stayaway to go to a point to view around the exhibit
		Vector3 stayAway = new Vector3(0,0, UnityEngine.Random.Range(5,10));
				if(exhibitions.Count == 0){
			leaveGallery ();
				}
				else{
			exhibitNumber = UnityEngine.Random.Range(0, exhibitions.Count);
			GetComponent<NavMeshAgent> ().SetDestination (exhibitions [exhibitNumber].transform.position - stayAway);
			behaviourTree.Blackboard.Set (target, exhibitions [exhibitNumber].transform.position - stayAway);


//			for (int i = 0; i < exhibitions.Count; i++) {
//				tempList.Add (exhibitions [i]);			
//			}			
//			exhibitions.RemoveAt (exhibitNumber);
//			exhibitions = tempList;
//			tempList.Clear();
				}
	}

	//if the exhibits list isnt empty, remove the currently selected exhibit from the target list,
	//set the blackboard exhibitsNotSeen to the amount of items in exhibitions
			void seenExhibit(){
		if(exhibitions.Count != 0){
		    exhibitions.RemoveAt (exhibitNumber);
			behaviourTree.Blackboard.Set (exhibitsNotSeen, exhibitions.Count);
			}
	}			//sets the target to the "exit"
				void leaveGallery(){

		behaviourTree.Blackboard.Set (target, exit.transform.position);


				}
	//destroy the agent once it reaches the exit
	void byeBye(){

		if (transform.position.x == exit.transform.position.x) {
						
					}

				}
	//calculates agents distance relative to others with agent tag; sees if its close to another, updates blackboard
    void Proximity()
	{
		Vector3 closeTo = this.transform.InverseTransformPoint(GameObject.FindGameObjectWithTag("agent").transform.position);
				behaviourTree.Blackboard.Set(agentPos, closeTo);
				behaviourTree.Blackboard.Set(distAway, closeTo.magnitude);
	}

	void Viewers(){
//		int viewers ;

	}
	


}





	

