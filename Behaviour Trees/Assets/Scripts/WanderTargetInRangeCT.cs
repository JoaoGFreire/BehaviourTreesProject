using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class WanderTargetInRangeCT : ConditionTask {

		public BBParameter<Transform> WanderTarget;
		public BBParameter<float> timeElapsed;
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
            float Distance = Vector3.Distance(agent.transform.position, WanderTarget.value.position);
            Debug.Log(Distance);
            if (Distance <= 2f || timeElapsed.value > 5f)
            {
				timeElapsed.value = 0;
				return true;
            }
			
            return false;
		}
	}
}