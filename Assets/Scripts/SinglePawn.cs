using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePawn : MonoBehaviour
{
    public enum Color
    {
        white,
        black,
    }

    public enum TypeOfPawn
    {
        pawn,
        king,
        queen,
        bishop,
        knight,
        rook,
    }

    bool isA
    {
        get
        {
            return (
       pawnPosition == SquareNames.a1 || pawnPosition == SquareNames.a2 ||
       pawnPosition == SquareNames.a3 || pawnPosition == SquareNames.a4 ||
       pawnPosition == SquareNames.a5 || pawnPosition == SquareNames.a6 ||
       pawnPosition == SquareNames.a7 || pawnPosition == SquareNames.a8);
        }
    }
    //SquareNames isB = SquareNames.b1 | SquareNames.b2 | SquareNames.b3 | SquareNames.b4 | SquareNames.b5 | SquareNames.b6 | SquareNames.b7 | SquareNames.b8;
    //SquareNames isC = SquareNames.c1 | SquareNames.c2 | SquareNames.c3 | SquareNames.c4 | SquareNames.c5 | SquareNames.c6 | SquareNames.c7 | SquareNames.c8;
    //SquareNames isD = SquareNames.d1 | SquareNames.d2 | SquareNames.d3 | SquareNames.d4 | SquareNames.d5 | SquareNames.d6 | SquareNames.d7 | SquareNames.d8;
    //SquareNames isE = SquareNames.e1 | SquareNames.e2 | SquareNames.e3 | SquareNames.e4 | SquareNames.e5 | SquareNames.e6 | SquareNames.e7 | SquareNames.e8;
    //SquareNames isF = SquareNames.f1 | SquareNames.f2 | SquareNames.f3 | SquareNames.f4 | SquareNames.f5 | SquareNames.f6 | SquareNames.f7 | SquareNames.f8;
    //SquareNames isG = SquareNames.g1 | SquareNames.g2 | SquareNames.g3 | SquareNames.g4 | SquareNames.g5 | SquareNames.g6 | SquareNames.g7 | SquareNames.g8;
    bool isH { get { return (
                pawnPosition == SquareNames.h1 || pawnPosition == SquareNames.h2 || 
                pawnPosition == SquareNames.h3 || pawnPosition == SquareNames.h4 || 
                pawnPosition == SquareNames.h5 || pawnPosition == SquareNames.h6 || 
                pawnPosition == SquareNames.h7 || pawnPosition == SquareNames.h8); } }

    public Transform WantedPosition { get => wantedPosition; set => wantedPosition = value; }

    public SquareNames pawnPosition;
    public Color pawnColor;
    public TypeOfPawn pawnType;

    Transform wantedPosition;

    bool CanKill()
    {
        
        if (isA)
            if (SquarePositions.instance.pawns[(int)pawnPosition - 7] != null)
                return true;

        if (isH)
            if (SquarePositions.instance.pawns[(int)pawnPosition - 9] != null)
                return true;

        if (SquarePositions.instance.pawns[(int)pawnPosition - 9] != null || SquarePositions.instance.pawns[(int)pawnPosition - 7] != null)
            return true;

        return false;
    }

    public void CountMoves()
    {
        switch(pawnType)
        {
            case TypeOfPawn.pawn:
                if (pawnColor == Color.white)
                {
                    if ((int)pawnPosition - 8 >= 0)
                        if (CanKill())
                            wantedPosition = SquarePositions.instance.squares[(int)pawnPosition - 9];
                        else
                            wantedPosition = SquarePositions.instance.squares[(int)pawnPosition - 8];

                }

                else if (pawnColor == Color.black)
                    wantedPosition = ((int)pawnPosition + 8) <= 63 ? SquarePositions.instance.squares[(int)pawnPosition + 8] : wantedPosition;
                break;
            default:
                Debug.Log("nothing happened");
                break;
        }
            

    }

    public void MakeMove()
    {
        //change pawn position
        transform.position = wantedPosition.position;
        //clear previous pawn's square
        SquarePositions.instance.pawns[(int)pawnPosition] = null;
        //prepare new pawn's square
        pawnPosition = (SquareNames)Array.IndexOf(SquarePositions.instance.squares, wantedPosition);
        SquarePositions.instance.pawns[(int)pawnPosition] = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = SquarePositions.instance.squares[(int)pawnPosition].position;
        SquarePositions.instance.pawns[(int)pawnPosition] = this;
        if (pawnColor == Color.black) GetComponent<SpriteRenderer>().color = UnityEngine.Color.black;
        wantedPosition = SquarePositions.instance.squares[(int)pawnPosition];
    }

    

    // Update is called once per frame
    void Update()
    {

    }
}
