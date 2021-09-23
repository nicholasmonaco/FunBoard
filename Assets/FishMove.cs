using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float Speed = 5;
    public Rigidbody2D RB;
    public SpriteRenderer Sprite;

    float timer = 0;
    const float duration = 5;

    Vector2 dir = new Vector2(1, 0);


    private void Start() {
        RB.velocity = dir * Speed;
    }


    private void FixedUpdate() {
        timer -= Time.fixedDeltaTime;

        if(timer <= 0) {
            NewFlip();
        }
    }

    private void Flip() {
        timer = duration;
        dir.x *= -1;
        Sprite.flipX = !Sprite.flipX;
        RB.velocity = dir * Speed;
    }

    private void NewFlip() {
        timer = duration;
        dir *= -1;
        dir.Normalize();
        Sprite.flipX = dir.x < 0;
        RB.velocity = dir * Speed;
    }

    private void NewNewFlip(Vector2 vec) {
        timer = duration;
        dir *= -1;
        dir.Normalize();
        Sprite.flipX = dir.x < 0;
        RB.velocity = vec;
    }


    public void OnCollisionEnter2D(Collision2D collision) {
        NewNewFlip(collision.contacts[0].normal * Speed);
    }
}
