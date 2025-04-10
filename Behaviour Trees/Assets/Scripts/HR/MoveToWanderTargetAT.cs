using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToWanderTargetAT : ActionTask {

		public BBParameter<Transform> WanderTarget;
		public BBParameter<float> speed;
		public BBParameter<float> timeElapsed;	
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {                                           //this is in execute and not update so that it can be interrupted by the player detection
            timeElapsed.value += 1 * Time.deltaTime; //increases time elapsed
            Vector3 moveDirection = (WanderTarget.value.position - agent.transform.position); //sets the movement direction to be the direction towards the wander target
			agent.transform.position += moveDirection.normalized * speed.value * Time.deltaTime; //move the HR enemy towards the wonder target
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
   
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}