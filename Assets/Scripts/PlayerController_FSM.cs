using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_FSM : MonoBehaviour
{
    #region Player Variables

    public float jumpForce;
    public Transform head;
    public Transform weapon01;
    public Transform weapon02;


    public readonly PlayerIdleState idleState = new PlayerIdleState();
    public readonly PlayerJumpingState jumpingState = new PlayerJumpingState();
    public readonly PlayerDuckingState duckingState = new PlayerDuckingState();

    public Sprite idleSprite;
    public Sprite duckingSprite;
    public Sprite jumpingSprite;
    public Sprite spinningSprite;

    private SpriteRenderer face;
    private Rigidbody rbody;
    public Rigidbody Rigidbody{
        get {return rbody;}
    }
    private PlayerBaseState currentState;
    public PlayerBaseState CurrentState{
        get {return currentState;}
    }

    #endregion


    private void Awake()
    {
        face = GetComponentInChildren<SpriteRenderer>();
        rbody = GetComponent<Rigidbody>();
        SetExpression(idleSprite);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        TransitionToState(idleState);
    }
    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this);
    }
    public void TransitionToState(PlayerBaseState state){
        currentState = state;
        currentState.EnterState(this);
    }
    public void SetExpression(Sprite newExpression)
    {
        face.sprite = newExpression;
    }
}
