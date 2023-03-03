using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingLogic : MonoBehaviour
{
    public GameObject endCanvas;
    public GameObject successCanvas;

    private void Start()
    {
        endCanvas.SetActive(false); successCanvas.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Parked Cars"))
        {
            Time.timeScale = 0;
            endCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (collision.gameObject.CompareTag("Parking Area"))
        {
            successCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}
