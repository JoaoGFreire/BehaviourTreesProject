using NodeCanvas.Framework;
using NodeCanvas.Tasks.Conditions;
using ParadoxNotion.Design;
using System;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RecruitAT : ActionTask {

		public BBParameter<float> detectionRadius;
		public LayerMask EmployeeLayer;

		public BBParameter<Boolean> reachedEmployee;
		public BBParameter<Boolean> Exploited;
		public BBParameter<Boolean> Unionized;
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            Collider[] hitEmployee = Physics.OverlapSphere(agent.transform.position, detectionRadius.value, EmployeeLayer);
            foreach (Collider employee in hitEmployee)
			{
     //           //Debug.Log(employee.gameObject);
     //           if (employee.CompareTag("Exploited")){
					//Debug.Log("this employee is exploited");

					//Exploited.value = true;
     //               reachedEmployee.value = false;
     //               //Debug.Log(employee.tag);
     //           }
				if(employee.CompareTag("Untagged"))
				{
					Exploited.value = false;
					
					employee.SendMessage("Unionize");
                    Debug.Log("this employee can be unionized");
					reachedEmployee.value = false;
                    Unionized.value = true;
                    EndAction(true);
                }
			}
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