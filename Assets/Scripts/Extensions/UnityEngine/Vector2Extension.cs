using UnityEngine;

public static class Vector2Extension
{
	public static Vector3 ToVector3(this Vector2 vector2)
	{
		Vector3 vector3;
		vector3.x = vector2.x;
		vector3.y = vector2.y;
		vector3.z = 0;
		return vector3;
	}
}