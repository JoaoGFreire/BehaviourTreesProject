using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ChangeWanderTargetAT : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise

		public NavMeshAgent navagent;
		public BBParameter<float> RadiusWander;
		public BBParameter<Transform> target;


		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            if (target.value == null || target.value == null)
            {
                Debug.LogWarning("Target is null, retrying next frame...");
				StartCoroutine(delayedAction());
                return;
            }
            target.value.position = RandomPointOnMesh(RadiusWander.value);
			
			EndAction(true);
		}
		public Vector3 RandomPointOnMesh(float wanderRadius)
		{
			Vector3 targetPoint = Vector3.zero;

            Vector3 randomPoint = Random.insideUnitCircle * wanderRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, wanderRadius, 1))
            {
                if(randomPoint != null)
				{
					targetPoint = randomPoint;
				}
                Debug.Log(targetPoint);
            }

			return targetPoint;
        }
		private IEnumerator delayedAction()
		{
			yield return new WaitForSeconds(0.1f);
			OnExecute();
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