using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHit : MonoBehaviour
{
    private int hitCount = 0;

    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            hitCount = hitCount + 1;
        }
        if(hitCount >= 3 && other.name == "Player")
        {
            if(!canvas.activeSelf)
            {
                canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
        }
    }

    public void OnClick(string buttonName)
    {
        if(buttonName == "Exit")
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
