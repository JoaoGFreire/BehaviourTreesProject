using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChangeTargetEmployeeAT : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise

		public BBParameter<Transform> currentEmployee;

		public Transform[] Employees;

		private int currentEmployeeIndex = 0;


		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			currentEmployeeIndex++;

			if(currentEmployeeIndex >= Employees.Length)
			{
				currentEmployeeIndex = 0;
			}

			currentEmployee.value = Employees[currentEmployeeIndex];




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