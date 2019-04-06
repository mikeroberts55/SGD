using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Text canvasText1;

    private void OnTriggerStay2D(Collider2D other)
    {
        canvasText1.enabled = false;

        if (other.CompareTag("ranger"))
        {
            canvasText1.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ranger"))
        {
            canvasText1.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ranger"))
        {
            canvasText1.enabled = true;
        }
    }

}
