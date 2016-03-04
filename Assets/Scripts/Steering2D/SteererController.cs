using UnityEngine;
using System.Collections.Generic;

namespace Steering2D
{
	/// <summary>
	/// Takes steering commands in order to control a steerer.
	/// 
	/// Invoker class for steering commands.
	/// </summary>
	// TODO: Potentially abstract out steerer controller to make ISteererController and have specific implementations.
	[RequireComponent(typeof(Rigidbody2D))]
	public class SteererController : MonoBehaviour
	{
		private List<ISteeringCommand> _activeCommands;

		private Rigidbody2D _rigidbody;

		private Vector2 _force;

		private float _maxForce = 0f;

		public void Init(float maxForce)
		{
			_maxForce = maxForce;
			_force = Vector2.zero;
		}

		private void OnEnable()
		{
			_activeCommands = new List<ISteeringCommand>();
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void OnDisable()
		{
			_activeCommands = null;
			_rigidbody = null;
		}

		private void FixedUpdate()
		{
			if (_activeCommands != null)
			{
				for (int i = 0; i < _activeCommands.Count; ++i)
				{
					_force += _activeCommands[i].GetCommandForce(CommandComplete);
				}
			}

			// If final force is greater than the max force, clamp it.
			if (_force.magnitude > _maxForce)
			{
				_force = _force.normalized * _maxForce;
			}

			_rigidbody.AddForce(_force);

			// Reset forces before adding up new forces.
			_force = Vector2.zero;
		}

		public void OverwriteAllCommands(ISteeringCommand steeringCommand)
		{
			if (_activeCommands != null)
			{
				_activeCommands.Clear();
				_activeCommands.Add(steeringCommand);
			}
		}

		public void AddCommand(ISteeringCommand steeringCommand)
		{
			if (_activeCommands != null)
			{
				_activeCommands.Add(steeringCommand);
			}
		}

		public void RemoveCommand(ISteeringCommand steeringCommand)
		{
			if (_activeCommands != null)
			{
				_activeCommands.Remove(steeringCommand);
			}
		}

		/// <summary>
		/// Used as a callback for commands that are completed.
		/// Removes the completed command from the fixed update.
		/// </summary>
		private void CommandComplete(ISteeringCommand steeringCommand)
		{
			if (_activeCommands != null)
			{
				RemoveCommand(steeringCommand);
			}
		}
	}
}