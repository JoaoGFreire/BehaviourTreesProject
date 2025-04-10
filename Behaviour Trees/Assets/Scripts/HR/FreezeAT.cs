using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FreezeAT : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		public BBParameter<Transform> player;

		private Vector3 frozenPosition;
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			frozenPosition = player.value.position;
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			player.value.position = frozenPosition;	
		}

		

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}