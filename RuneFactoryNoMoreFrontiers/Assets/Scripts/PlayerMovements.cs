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

    #endregion PrivateVariables

    #region GettersAndSetters

    public float WalkSpeed { get => _walkSpeed; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
    }

    private void Update()
    {
        Move();
    }

    #endregion InheritedFunctions

    #region Functions

    private void Move()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(dirX, dirY);

        rb.velocity = dir.normalized * _walkSpeed * 10 * Time.deltaTime;
    }

    #endregion Functions
}