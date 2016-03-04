using UnityEngine;

public static class Vector3Extension
{
	public static Vector2 ToVector2(this Vector3 vector3)
	{
		Vector2 vector2;
		vector2.x = vector3.x;
		vector2.y = vector3.y;
		return vector2;
	}
}