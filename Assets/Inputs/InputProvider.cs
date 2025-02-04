using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider : MonoBehaviour
{
	private static PlayerInput _playerInput;

	private void Awake()
	{
		if (_playerInput == null)
		{
			_playerInput = GetComponent<PlayerInput>();
		}
		else
			Destroy(this.gameObject);
	}

	public static PlayerInput GetPlayerInput()
	{
		if (_playerInput == null)
		{
			Debug.LogError("Player input not set, either not on scene or component not available on game object.");
		}
		return _playerInput;
	}
}
