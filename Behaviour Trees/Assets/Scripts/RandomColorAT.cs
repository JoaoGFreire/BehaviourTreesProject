using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RandomColorAT : ActionTask {

		public BBParameter<Color> currentColor;
		public MeshRenderer meshRenderer;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			int i = Random.Range(1, 4);
			if(i == 1)
			{
				currentColor.value = Color.yellow;
				meshRenderer.material.color = currentColor.value;
			}
            if (i == 2)
            {
                currentColor.value = Color.red;
                meshRenderer.material.color = currentColor.value;
            }
            if (i == 3)
            {
                currentColor.value = Color.green;
                meshRenderer.material.color = currentColor.value;
            }
            if (i == 4)
            {
                currentColor.value = Color.blue;
                meshRenderer.material.color = currentColor.value;
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