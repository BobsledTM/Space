
using UnityEngine;

namespace Steering2D
{
	/// <summary>
	/// Contains functionality for steering a 2D rigidbody using forces.
	/// 
	/// Receiver class for the steering commands.
	/// </summary>
	// TODO: Potentially abstract the steerer class to make it ISteerable and have specific implementations for steerable
	[RequireComponent(typeof(Rigidbody2D))]
	public class Steerer : MonoBehaviour
	{
		public float Speed { get { return _rigidbody.velocity.magnitude; } }

		protected float _maxSpeed;

		protected Rigidbody2D _rigidbody;

		protected Vector2 _position;

		public void Init(float maxSpeed)
		{
			_maxSpeed = maxSpeed;
		}

		private void OnEnable()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void OnDisable()
		{
			_rigidbody = null;
		}

		private void FixedUpdate()
		{
			_position = transform.position.ToVector2();
		}

		public virtual Vector2 Stop()
		{
			return -_rigidbody.velocity.normalized * _maxSpeed;
		}

		public virtual Vector2 Seek(Vector2 positionToSeek)
		{
			Vector2 desiredVelocity = positionToSeek - _position;

			// Scale desired velocity by max speed.
			desiredVelocity = desiredVelocity.normalized * _maxSpeed;

			desiredVelocity -= _rigidbody.velocity;

			return desiredVelocity;
		}

		public virtual Vector2 Flee(Vector2 positionToFlee)
		{
			Vector2 desiredVelocity = _position - positionToFlee;
			desiredVelocity = desiredVelocity.normalized * _maxSpeed;
			desiredVelocity -= _position * _rigidbody.velocity.magnitude;
			return desiredVelocity;
		}

		public virtual Vector2 Orbit(Vector2 position, float desiredDistance, bool clockwise)
		{
			// TODO: Implement.
			return Vector2.zero;
		}
	}
}