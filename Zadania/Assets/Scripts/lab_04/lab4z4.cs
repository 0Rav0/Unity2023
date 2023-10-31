using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    float mouseYMove = 0;
    float mouseXMove = 0;
    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        mouseXMove += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseXMove = Mathf.Clamp(mouseXMove, -90f, 90f);
        mouseYMove = Mathf.Clamp(mouseYMove, -90f, 90f);
        // wykonujemy rotacjê wokó³ osi Y
        player.transform.rotation = Quaternion.Euler(0f, mouseXMove, 0f);
        this.transform.rotation = Quaternion.Euler(-mouseYMove, mouseXMove, 0f);
        //player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamerê dla lokalnych koordynatów
        // -mouseYMove aby unikn¹æ ofektu mouse inverse
        //transform.Rotate(new Vector3(-mouseYMove, 0f, 0f), Space.Self);

    }
}