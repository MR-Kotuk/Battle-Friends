using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameValues", menuName = "GameSettings/GameValues")]
public class GameValues : ScriptableObject
{
    [SerializeField] private float _speedPlayers;
    [SerializeField] private float _powerJumpPlayers;

    [SerializeField] private float _maxSpeedPlayers, _maxJumpPlayers;

    public void OnValidate()
    {
        SetSpeedPlayers(_speedPlayers);
        SetPowerJumpPlayers(_powerJumpPlayers);
    }

    public float GetSpeedPlayers()
    {
        return _speedPlayers;
    }
    public float GetPowerJumpPlayers()
    {
        return _powerJumpPlayers;
    }

    public void SetSpeedPlayers(float newSpeed)
    {
        if (newSpeed < _maxSpeedPlayers && newSpeed >= 0)
            _speedPlayers = newSpeed;
        else
            Debug.LogError($"New players speed is a lot of {_maxSpeedPlayers} or a let of 0");
    }
    public void SetPowerJumpPlayers(float newPowerJump)
    {
        if (newPowerJump < _maxJumpPlayers && newPowerJump >= 0)
            _powerJumpPlayers = newPowerJump;
        else
            Debug.LogError($"New players power jump is a lot of {_maxJumpPlayers} or a let of 0");
    }
}
