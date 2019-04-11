
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Text canvasText1;

    public void Start()
    {
        canvasText1.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ranger"))
        {
            canvasText1.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ranger"))
        {
            canvasText1.enabled = true;
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
