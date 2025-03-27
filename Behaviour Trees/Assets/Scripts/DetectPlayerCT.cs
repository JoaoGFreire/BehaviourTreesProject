using NodeCanvas.Framework;
using ParadoxNotion.Design;
using static UnityEngine.GraphicsBuffer;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class DetectPlayerCT : ConditionTask {

        public BBParameter<float> rangeRadius;
        public BBParameter<Transform> target;

		public LayerMask playerLayer;
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
            Collider[] hitPlayers = Physics.OverlapSphere(agent.transform.position, rangeRadius.value,playerLayer);
            foreach (Collider player in hitPlayers)
            {
                target.value = player.transform;
            }
			if (hitPlayers == null)
			{
				return false;
			}
			else
			{
                return true;
            }
            //return true;
		}
	}
}