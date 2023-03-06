using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    // Start is called before the first frame update
    private static int score = 0;

    public static int Score => score;
    private void OnMouseDown()
    {
        Destroy(gameObject);
        score++;
        Debug.Log($"Score: {score}");
    }
}