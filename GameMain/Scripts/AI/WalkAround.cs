using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

namespace RPGGame.AI
{
	public class WalkAround : Action
	{
		public Transform pos1;
		public Transform pos2;
		public NavMeshAgent nav;
		public override void OnStart()
		{
			nav = GetComponent<NavMeshAgent>();
			nav.SetDestination(pos1.position);
		}

		public override TaskStatus OnUpdate()
		{
			if (Vector3.Distance(transform.position, pos1.position) <= 1f)
			{
				nav.SetDestination(pos2.position);
			}
			if(Vector3.Distance(transform.position, pos2.position) <= 1f) 
			{
				nav.SetDestination(pos1.position);
			}
			return TaskStatus.Running;
		}
	}
}