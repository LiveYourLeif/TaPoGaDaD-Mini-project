using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad2 : MonoBehaviour
{
    private static bool isInstanceExists = false;

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
