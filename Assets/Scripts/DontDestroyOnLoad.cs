using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private bool isInstanceExists = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (!isInstanceExists)
        {
            isInstanceExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
