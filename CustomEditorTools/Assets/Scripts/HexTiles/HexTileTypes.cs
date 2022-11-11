using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileTypes : MonoBehaviour
{
    [Header("Wizard Element Materials")]
    public Material Ice;
    public Material Weather;
    public Material Fire;
    public Material Lava;
    public Material Earth;
    public Material Poison;

    [Header("Grass Element Materials")]
    public Material Grass;

    [Header("Water Element Materials")]
    public Material Water;

    [Header("Misc Materials")]
    public Material Temp;

    
    public Dictionary<Material, string> materialToTypeDict;

    void Start()
    {
        materialToTypeDict = new Dictionary<Material, string>
        {
            {Ice, "Ice"},
            {Weather, "Weather"},
            {Fire, "Fire"},
            {Lava, "Lava"},
            {Earth, "Earth"},
            {Poison, "Poison"},
            {Grass, "Grass"},
            {Water, "Water"},
            {Temp, "Misc"},
        };
    }
}
