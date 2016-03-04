using UnityEngine;

namespace Projectile2D
{
	/// <summary>
	/// Objects that can be used as a projectile must implement these members.
	/// </summary>
	public interface IProjectile
	{
		void Shoot(Vector2 startLocation, Vector2 target, float force);
	}
}
