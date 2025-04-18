using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class PlayerReachedCT : ConditionTask {

		public BBParameter<Transform> playerPosition;
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			Debug.Log("test");
			float Distance = Vector3.Distance(agent.transform.position, playerPosition.value.position);
			Debug.Log(Distance);
            if(Distance <= 2.5f)
			{
				Debug.Log("caught you");
				return true;
			}
			else { return false; }
			
		}
	}
}