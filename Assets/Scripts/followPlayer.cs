using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position + offset;
    }
}
