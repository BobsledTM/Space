using UnityEngine;
using Steering2D;

/// <summary>
/// Takes player input and sends it to the steerer controller to be handled.
/// 
/// Client for steering commands.
/// </summary>
public abstract class ShipInputHandler : MonoBehaviour
{
	private float _maxForce;

	private float _maxSpeed;

	protected SteererController _steererController;
	protected Steerer _steerer;

	public void Init(float maxForce, float maxSpeed)
	{
		_maxForce = maxForce;
		_maxSpeed = maxSpeed;
		_steererController = gameObject.AddComponent<SteererController>();
		_steererController.Init(_maxForce);
		_steerer = gameObject.AddComponent<Steerer>();
		_steerer.Init(_maxSpeed);
	}

	private void Update()
	{
		HandleInput();
	}

	protected abstract void HandleInput();
}