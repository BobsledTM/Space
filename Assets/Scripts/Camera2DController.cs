using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camera2DController : MonoBehaviour
{
	[SerializeField]
	private GameObject _objectToFollow;

	[SerializeField]
	private float _distanceFromObject;

	private bool _orientToObject = false;

	void Update()
	{
		Vector3 cameraPosition = _objectToFollow.transform.position;
		cameraPosition.z = -_distanceFromObject;
		transform.position = cameraPosition;
		
		if(_orientToObject)
		{
			transform.rotation = _objectToFollow.transform.rotation;
		}
	}

	/// <summary>
	/// Rotates the camera with the object.
	/// </summary>
	/// <param name="rotate"></param>
	public void OrientToObject(bool orient)
	{
		_orientToObject = orient;
	}

	/// <summary>
	/// Sets the camera's distance from the object.
	/// </summary>
	/// <param name="distance"></param>
	public void SetDistanceFromObject(float distance)
	{
		_distanceFromObject = distance;
	}
}