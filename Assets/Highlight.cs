using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseEnter()
    {
        if(GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = new UnityEngine.Color(0.8f, 0.8f, 0.8f, 0.8f);
    }

    private void OnMouseExit()
    {
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = new UnityEngine.Color(0f, 0f, 0f, 0f);
    }
}
