using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    float mouseYMove = 0;
    float mouseXMove = 0;
    void Start()
    {
        // zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy warto�ci dla obu osi ruchu myszy
        mouseXMove += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseXMove = Mathf.Clamp(mouseXMove, -90f, 90f);
        mouseYMove = Mathf.Clamp(mouseYMove, -90f, 90f);
        // wykonujemy rotacj� wok� osi Y
        player.transform.rotation = Quaternion.Euler(0f, mouseXMove, 0f);
        this.transform.rotation = Quaternion.Euler(-mouseYMove, mouseXMove, 0f);
        //player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamer� dla lokalnych koordynat�w
        // -mouseYMove aby unikn�� ofektu mouse inverse
        //transform.Rotate(new Vector3(-mouseYMove, 0f, 0f), Space.Self);

    }
}