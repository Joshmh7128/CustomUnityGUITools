using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
//namespace HexTiles
{
    [SerializeField]
    //public HexTiles.HexPosition[,] HexTileList;
    public WorldManager.HexTileL HexTileList;
    public HexTileTypes hexTileTypes;
    public int minQval;
    public int maxQval;
    public int minRval;
    public int maxRval;
    public int randomTileQ;
    public int randomTileR;
    
    [Header("Wizard Prefabs")]
    public GameObject wizardPrefab1;
    public GameObject wizardPrefab2;
    public GameObject wizardPrefab3;
    public GameObject wizardPrefab4;
    public GameObject wizardPrefab5;
    public GameObject wizardPrefab6;
    public Dictionary<string, Material> wizardMaterialDict;

    void Start()
    {
       // Debug.Log("Hello World");
        // HexTileList = new HexTiles.HexPosition[this.transform.childCount];
        hexTileTypes = gameObject.transform.GetChild(0).GetComponent<HexTileTypes>();
        wizardMaterialDict = new Dictionary<string, Material>
        {
            {"Ice", hexTileTypes.Ice},
            {"Weather", hexTileTypes.Weather},
            {"Fire", hexTileTypes.Fire},
            {"Lava", hexTileTypes.Lava},
            {"Earth", hexTileTypes.Earth},
            {"Poison", hexTileTypes.Poison}
        };
        minQval = 0;
        maxQval = 0;
        minRval = 0;
        maxRval = 0;
        getMapBounds();
        // HexTileList = new HexTiles.HexPosition[maxQval+1, maxRval+1];
        // **** HexTileList = new HexTiles.HexChunk[maxQval + 1, maxRval + 1];
        HexTileList = new WorldManager.HexTileL(maxQval + 1, maxRval + 1, minQval, minRval);
        getPositions();
        Debug.Log("Finished filling in the Hex positions with possible values");
        //fillInBlanks();
        SetUpTileTypes();
        Debug.Log("Finished filling in the empty values of the hex map");
        RandomTile();
       /* for (int i = 0; i <= 1; i++)
        {
            if (HexTileList[randomTileQ, randomTileR] != null)
            {
                Debug.Log("About to spawn wizard");
                //spawnWizard(0,1);
                spawnWizard(randomTileQ, randomTileR);
            }
            else
            {
                Debug.Log("Tile (" + randomTileQ + "," + randomTileR + ") Not a tile on map");
                Debug.Log("Tile not found randomizing tile again");
                RandomTile();
            }
            RandomTile();
        }*/
    }
    void getPositions()
    {
        for (int i =1; i< this.transform.childCount;i++)
        {

           HexTileList[this.gameObject.transform.GetChild(i).GetComponent<HexTiles.HexChunk>().Tiles[0].Coordinates.Q, 
                       this.gameObject.transform.GetChild(i).GetComponent<HexTiles.HexChunk>().Tiles[0].Coordinates.R] = 
                       this.gameObject.transform.GetChild(i).GetComponent<HexTiles.HexChunk>();
        }
    }
    void getMapBounds()
    {
        for (int i = 1; i < this.transform.childCount; i++)
        {
            HexTiles.HexCoords coords = this.gameObject.transform.GetChild(i).GetComponent<HexTiles.HexChunk>().Tiles[0].Coordinates;
            if (coords.R > maxRval)
            {
                maxRval = coords.R;
            }
            else if (coords.R < minRval)
            {
                minRval = coords.R;
            }
            if (coords.Q > maxQval)
            {
                maxQval = coords.Q;
            }
            else if (coords.Q < minQval)
            {
                minQval = coords.Q;
            }
        }
    }

    void fillInBlanks()
    {
        for(int i = minQval; i < maxQval; i++)
        {
            for(int j = minRval; j < maxRval; j++)
            {
                
                if (HexTileList[i,j] == null)
                {
                    HexTileList[i, j] = null;
                 //   Debug.Log("Followng Position is null Q=" + i + "R =" + j);
                }
                else
                {
                 //   Debug.Log(HexTileList[i, j].transform.position);
                }
            }
        }
    }

    //void spawnWizard(HexTiles.HexChunk Tile)
    void spawnWizard(int Q, int R)
    {
        Debug.Log("Spawn Wizard at Q=" + Q + "R=" + R);

        //var position = HexTiles.hexMap.HexPositionToWorldPosition(tile.Position);
        //return Tile.transform.TransformPoint(position.GetPositionVector(tileDiameter));
        //HexTileList[Q, R].Tiles[0].GetPositionVector(1.0f);
        //transform.TransformPoint(HexTileList[Q, R].Tiles[0].GetPositionVector(1.0f));
        Instantiate(wizardPrefab1, HextoWorldSpace(Q,R), Quaternion.identity);
    }

    void RandomTile()
    {
        Debug.Log("In the RandomTile Function");
        randomTileQ = Random.Range(minQval, maxQval);
        randomTileR = Random.Range(minRval, maxRval);
    }

    public Vector3 HextoWorldSpace(int Q, int R)
    {
      return transform.TransformPoint(HexTileList[Q, R].Tiles[0].GetPositionVector(1.0f));
    }

    public void CountTiles()
    {
        int tileCount = 0;
        for (int i = minQval; i < maxQval+1; i++)
        {
            for (int j = minRval; j < maxRval+1; j++)
            {
                if(HexTileList[i,j] != null)
                {
                    tileCount++;
                }
            }
        }
        Debug.Log(tileCount);
    }

    void SetUpTileTypes()
    {
        for (int i = minQval; i < maxQval+1; i++)
        {
            for (int j = minRval; j < maxRval+1; j++)
            {
                if (HexTileList[i,j] != null && HexTileList[i,j].Material != null && hexTileTypes.materialToTypeDict.ContainsKey(HexTileList[i,j].Material))
                {
                    HexTileList[i,j].hexTileType = hexTileTypes.materialToTypeDict[HexTileList[i,j].Material];
                }
            }
        }
    }
}
