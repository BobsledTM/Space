using UnityEngine;
using Steering2D;

public class PlayerShipInputHandler : ShipInputHandler
{
	[SerializeField]
	private float _stopRadius;

	/// <summary>
	/// Handles player input.
	/// </summary>
	protected override void HandleInput()
	{
		// Right click. Move to target.
		if (Input.GetMouseButtonDown(1))
		{
			float zDistance = -Camera.main.transform.position.z;
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = zDistance;
			Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition).ToVector2();
			ISteeringCommand moveToCommand = new MoveToSteeringCommand(_steerer, target, _stopRadius);
			_steererController.OverwriteAllCommands(moveToCommand);
		}
	}
}