using UnityEngine;
using System.Collections;

namespace RootMotion.Demos {

	// Using the Unity's built in Animator IK to adjust the target pose of the Puppet.
	[RequireComponent(typeof(Animator))]
	public class AnimatorIKDemo : MonoBehaviour {

		public Transform IKTransform;

		private Animator animator;

		private bool _isActive = false;

		void Start() {
			animator = GetComponent<Animator>();
		}

		void OnAnimatorIK(int layer) {

			if(!_isActive) return;

			animator.SetIKPosition(AvatarIKGoal.LeftHand, IKTransform.position);
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
			animator.SetIKPosition(AvatarIKGoal.RightHand, IKTransform.position);
			animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
		}
	public void SwitchPos()
	{
		_isActive = !_isActive;
	}
	}

}
