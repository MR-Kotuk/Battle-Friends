using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private GameValues _gameValues;

    [SerializeField] private bool isMinus;

    private float dirX, dirZ;
    private bool isJump;

    private void OnValidate()
    {
        _rb ??= GetComponent<Rigidbody>();

        if (_rb == GetComponent<Rigidbody>())
            _rb.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        dirX = _joystick.Horizontal * _gameValues.GetSpeedPlayers();
        dirZ = _joystick.Vertical * _gameValues.GetSpeedPlayers();

        if(!isMinus)
            _rb.velocity = new Vector3(dirX, _rb.velocity.y, dirZ);
        else
            _rb.velocity = new Vector3(-dirX, _rb.velocity.y, -dirZ);

        if (dirX != 0 || dirZ != 0)
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
    }

    public void OnJump()
    {
        if (isJump)
            _rb.AddForce(new Vector3(0, 1, 0) * _gameValues.GetPowerJumpPlayers());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.position.y < gameObject.transform.position.y - 0.5)
            isJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.position.y < gameObject.transform.position.y - 0.5)
            isJump = false;
    }
}
