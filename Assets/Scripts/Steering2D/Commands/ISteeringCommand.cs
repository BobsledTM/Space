using System;
using UnityEngine;

namespace Steering2D
{
	/// <summary>
	/// Steering command interface.
	/// </summary>
	public interface ISteeringCommand
	{
		/// <summary>
		/// Returns the desired force for the given command.
		/// </summary>
		Vector2 GetCommandForce(Action<ISteeringCommand> complete);
	}
}