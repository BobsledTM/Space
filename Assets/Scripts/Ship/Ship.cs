using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Represents a ship and all of the components that belong to a ship.
/// </summary>
public abstract class Ship : MonoBehaviour
{
	protected List<ShipComponent> _shipComponents;
	protected Cargo _cargo;

	public void AddShipComponent(ShipComponent component)
	{
		_shipComponents.Add(component);
	}

	public void RemoveShipComponent(ShipComponent component)
	{
		_shipComponents.Remove(component);
	}
}
