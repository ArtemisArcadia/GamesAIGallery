//    // MoveTo.cs
//    using UnityEngine;
//	using System.Collections.Generic;
//    using System.Collections;
//	using NPBehave;
//	using UnityEngine.AI;
// 	using System.Linq;
//
//    public class moveTocopy : MonoBehaviour {
//	public int exhibitNumber;
//	const string target_position = "targetPosition";
//	const string target = "currentTarget";
//	const string agentPos = "agentPosition";
//	const string distAway = "distanceAway";
//	const int[] exhibitsSeen = "exhibitonsSeen";
//	public GameObject[] exhibitions;
//	private Root behaviourTree;
//	private Blackboard blackboard;
//    void Start () {
//		//for realtime debugging
//
//
//
//		//picks random exhibit 
//		exhibitNumber = UnityEngine.Random.Range(0, exhibitions.Length);
////		if (exhibitNumber == exhibitions.Length) {
////			exhibitNumber = 0;
////		}
//		// moves to point, updates point, then moves to the next point
//		blackboard = behaviourTree.Blackboard;
//		behaviourTree = new Root (
//			new Service(0.5f, Proximity,
//				
//				new Selector(
//
//					//move to viewing point, add if there's less people, add if not seen already
//				)
//
//
//
//		);
//		//sets the first target to be the first point in the array
//		//moved to GoToNewViewpoint
//	    //behaviourTree.Blackboard.Set (target, exhibitions [exhibitNumber].transform.position);
//		behaviourTree.Start ();
//
//		#if UNITY_EDITOR
//		Debugger debugger = (Debugger)this.gameObject.AddComponent(typeof(Debugger));
//		debugger.BehaviorTree = behaviourTree;
//		#endif
//	}
//    
//	// Update is called once per frame
//	void Update () {
//		
//		//UnityEngine.AI.NavMeshAgent 
//	//	agent.destination = exhibits[exhibitToView].transform.position;
//
//		//if (agent.nextPosition == exhibits[exhibitToView].transform.position) {
//	//		exhibitToView++;
//			
//	//	}
//
//	}
//	//updates the target to be the next point
//	void NewViewPoint(){
//				
//		exhibitNumber = UnityEngine.Random.Range(0, exhibitions.Length);
//		behaviourTree.Blackboard.Set (target, exhibitions [exhibitNumber].transform.position);
//
//	}
//	//calculates agents distance relative to others with agent tag; sees if its close to another, updates blackboard
//    void Proximity()
//	{
//		Vector3 closeTo = this.transform.InverseTransformPoint(GameObject.FindGameObjectWithTag("agent").transform.position);
//				behaviourTree.Blackboard.Set(agentPosition, closeTo);
//				behaviourTree.Blackboard.Set(distAway, closeTo.magnitude);
//	}
//
//	void Viewers(){
//		int viewers ;
//
//	}
//
//}
//
//
//
//
//
//	
//
