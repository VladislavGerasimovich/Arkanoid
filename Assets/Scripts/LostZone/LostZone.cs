using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostZone : MonoBehaviour
{
    public event Action BallOutOfZone;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out BallMove ball))
        {
            BallOutOfZone?.Invoke();
        }
    }
}
