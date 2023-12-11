using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5z5 : MonoBehaviour
{
    Vector3 playerVelocity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {          
            playerVelocity.y = 3 * other.GetComponent<MoveWithCharacterController>().jumpHeight;
            other.GetComponent<CharacterController>().Move(playerVelocity);
        }
    }
}
