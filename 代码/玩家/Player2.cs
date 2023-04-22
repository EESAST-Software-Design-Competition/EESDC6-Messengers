using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float armor = 4f;
    public float totaltime = 5.0f;
    public float bailedOutTime = 7f;
    public PlayerDestroyed2 tankDestroyed;
    public Transform turret;
    public CanvasGroup Map;
    // Start is called before the first frame update
    void Start()
    {
        Map.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Map.alpha == 0)
            { Map.alpha = 1; }
            else if (Map.alpha == 1)
            { Map.alpha = 0; }
        }
    }
}
