using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float _walkSpeed;

    private PlayerManager _pm;

    #endregion PrivateVariables

    #region GettersAndSetters

    public float WalkSpeed { get => _walkSpeed; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
        _pm = FindObjectOfType<PlayerManager>();
    }

    private void Update()
    {
        Move();
    }

    #endregion InheritedFunctions

    #region Functions

    private void Move()
    {
        float dirX = 0f;
        float dirY = 0f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
        }

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            dirY = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            dirY = -1;
        }

        Vector2 dir = new Vector2(dirX, dirY);

        rb.velocity = dir.normalized * _walkSpeed * 10 * Time.deltaTime;
    }

    #endregion Functions
}