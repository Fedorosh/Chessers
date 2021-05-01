using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SquareNames
{
    a8,
    b8,
    c8,
    d8,
    e8,
    f8,
    g8,
    h8,
    a7,
    b7,
    c7,
    d7,
    e7,
    f7,
    g7,
    h7,
    a6,
    b6,
    c6,
    d6,
    e6,
    f6,
    g6,
    h6,
    a5,
    b5,
    c5,
    d5,
    e5,
    f5,
    g5,
    h5,
    a4,
    b4,
    c4,
    d4,
    e4,
    f4,
    g4,
    h4,
    a3,
    b3,
    c3,
    d3,
    e3,
    f3,
    g3,
    h3,
    a2,
    b2,
    c2,
    d2,
    e2,
    f2,
    g2,
    h2,
    a1,
    b1,
    c1,
    d1,
    e1,
    f1,
    g1,
    h1,
}

public class SquarePositions : MonoBehaviour
{
    public static SquarePositions instance;
    bool waitingForAction;

    //public class Squares
    //{
    //    public Transform square;
    //    public bool isOccupied;
    //}

    [HideInInspector]
    public Transform[] squares;
    [HideInInspector]
    public SinglePawn[] pawns;

    SinglePawn singlePawn;

    RaycastHit hit;
    Ray ray;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
        squares = gameObject.GetComponentsInChildren<Transform>();
        pawns = new SinglePawn[64];
        Transform[] temp = new Transform[64];
        for (int i = 1; i < squares.Length; i++)
            temp[i - 1] = squares[i];
        squares = temp;
    }
    void Start()
    {
        waitingForAction = false;
    }
    
    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (hit.transform.tag == "Square")
        //        if (hit.transform.GetComponent<SpriteRenderer>() != null)
        //            hit.transform.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f, 0.8f);
        //}
        //if (Input.mousePosition != ray.origin)
        //    if (Physics.Raycast(ray, out hit))
        //        if (hit.transform.tag == "Square")
        //            if (hit.transform.GetComponent<SpriteRenderer>() != null)
        //                hit.transform.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f, 0);

        if (Input.GetMouseButtonDown(0))
        {
            if (!waitingForAction)
            {
                if (Physics.Raycast(ray, out hit))
                    if (hit.transform.tag == "Square")
                    {
                        if (pawns[Array.IndexOf(squares, hit.transform)] != null)
                        {
                            singlePawn = pawns[Array.IndexOf(squares, hit.transform)];
                            singlePawn.CountMoves();
                        }
                    }
            }
            if (waitingForAction)
            {
                if (Physics.Raycast(ray, out hit))
                    if (hit.transform.tag == "Square")
                    {
                        if(singlePawn != null)
                        singlePawn.WantedPosition = hit.transform;
                        if (pawns[Array.IndexOf(squares, hit.transform)] != null)
                        {
                            Destroy(pawns[Array.IndexOf(squares, hit.transform)].gameObject);
                        }
                    }
                if (singlePawn != null)
                singlePawn.MakeMove();
            }

        }
        if (Input.GetMouseButtonUp(0))
            waitingForAction = !waitingForAction;
    }
}
