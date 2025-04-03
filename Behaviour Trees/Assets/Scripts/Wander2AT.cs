using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class Wander2AT : ActionTask {

		public NavMeshAgent myNavMeshAgent;
		public BBParameter<float> wanderRadius;
		public float timeSinceLastWanderPosition;
		public float wanderMaxDuration;
		public Vector3 wanderTarget;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
		
            myNavMeshAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            wanderTarget = RandomMeshPosition(wanderRadius.value);
            myNavMeshAgent.SetDestination(wanderTarget);
            //EndAction(true);
        }
		public Vector3 RandomMeshPosition(float wanderRadius)
		{
			Vector3 finalPosition = Vector3.zero;

			Vector3 randomPoint = Random.insideUnitCircle * wanderRadius;
			NavMeshHit hit;
			if(NavMesh.SamplePosition(randomPoint,out hit, wanderRadius, 1))
			{
				finalPosition = randomPoint;
				Debug.Log(finalPosition);
			}
			//randomPoint = finalPosition;


			return finalPosition;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            Debug.Log(wanderTarget);
            timeSinceLastWanderPosition += 1 * Time.deltaTime;
			if(timeSinceLastWanderPosition >= wanderMaxDuration)
			{

				wanderTarget = RandomMeshPosition(wanderRadius.value);
				
				timeSinceLastWanderPosition = 0;

			}
			myNavMeshAgent.SetDestination(wanderTarget);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}