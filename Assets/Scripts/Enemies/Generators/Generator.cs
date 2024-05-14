using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    public abstract void Generate();

    public abstract void RestoreAll();

    public abstract void OnDied(int score);
}
