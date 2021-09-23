using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _wasMoving = false;
    private Vector2 _lastMoveVec = Vector2.zero;

    private float _movementSpeed = 5;
    private float _movementSpeedMult = 1;

    public bool CanMove = true;

    public Rigidbody2D PlayerRB;
    public SpriteRenderer PlayerSprite;

    public float SpinThreshold = 2500;
    public Sprite NormalSprite;
    public Sprite SpinSprite;


    private void Update() {
        GetInput();

        ChangeSpite();
    }

    public void ChangeSpite() {
        if(Mathf.Abs(PlayerRB.angularVelocity) >= SpinThreshold) {
            PlayerSprite.sprite = SpinSprite;
        } else {
            PlayerSprite.sprite = NormalSprite;
        }
    }

    private void FixedUpdate() {
        Move();
    }


    private Vector2 in_moveVec;
    private void GetInput() {
        in_moveVec = Game.Input.Player.Move.ReadValue<Vector2>();
    }


    private void Move() {
        Vector2 moveVec = CanMove ? in_moveVec : Vector2.zero;
        Vector2 velMoveVec = moveVec;

        if (moveVec.x != 0 || moveVec.y != 0) {
            // We're moving now
            velMoveVec = in_moveVec.normalized * _movementSpeed * _movementSpeedMult;

            PlayerSprite.flipX = moveVec.x > 0;
        } 


        PlayerRB.velocity = velMoveVec;

        _lastMoveVec = moveVec;
    }
}
