using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldManager
{
    static public GameObject gameManager; // gamemanager object ref
    static public GameObject hexTileMapRef; // map ref
    static public GameObject camera; // camera ref
    static public GameObject mousedOverWizard = null; // wizard currently being moused over (stats to show)

    public class HexTileL
    {
        public HexTiles.HexChunk[,] insideArray;
        private int offsetQ;
        private int offsetR;
        public HexTileL(int maxQ, int maxR, int minQ, int minR)
        {
            offsetQ = (minQ < 0) ? minQ * -1 : 0;
            offsetR = (minR < 0) ? minR * -1 : 0;
            insideArray = new HexTiles.HexChunk[maxQ + offsetQ, maxR + offsetR];
        }
        public HexTiles.HexChunk this[int Q, int R]
        {
            get
            {
                return insideArray[Q+offsetQ, R+offsetR];
            }
            set
            {
                insideArray[Q+offsetQ, R+offsetR] = value;
            }
        }
    }
}
