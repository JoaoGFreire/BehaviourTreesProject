using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class NavigateAT : ActionTask {

		public BBParameter<SteeringData> steerdata; 

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			steerdata.value.velocity += steerdata.value.acceleration;
			float groundSpeed = Mathf.Sqrt(steerdata.value.velocity.x * steerdata.value.velocity.x + steerdata.value.velocity.z * steerdata.value.velocity.z);
			if (steerdata.value.maxSpeed < groundSpeed)
			{
				float cappedX = steerdata.value.velocity.x / groundSpeed * steerdata.value.maxSpeed;
				float cappedZ = steerdata.value.velocity.z / groundSpeed * steerdata.value.maxSpeed;
				//float velocity = new Vector3(cappedX, steerdata.value.velocity.y, cappedZ);
			}
			agent.transform.position += steerdata.value.velocity * Time.deltaTime;

			steerdata.value.acceleration = Vector3.zero;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}