using UnityEngine;
using System;

namespace Steering2D
{
	public class MoveToSteeringCommand : ISteeringCommand
	{
		private Vector2 _target;

		private float _stopRadius;

		private Steerer _steerer;

		private bool _stop = false;

		public MoveToSteeringCommand(Steerer steerer, Vector2 target, float stopRadius)
		{
			_target = target;
			_stopRadius = stopRadius;
			_steerer = steerer;
		}

		public Vector2 GetCommandForce(Action<ISteeringCommand> complete)
		{
			float distanceToTarget = (_target - _steerer.transform.position.ToVector2()).magnitude;
			if (distanceToTarget <= _stopRadius)
			{
				_stop = true;
			}

			if(_stop)
			{
				if (_steerer.Speed == 0)
				{
					complete(this);
				}
				return _steerer.Stop();
			}
			else
			{
				return _steerer.Seek(_target);
			}
		}
	}
}