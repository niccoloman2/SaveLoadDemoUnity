using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //we have to include this to be able to serialize the entire class
public class PlayerData
{
    //Note: We can only serialize native data types. Any variable that's Unity-specific won't be serializable
    public string name;
    public int level;
    public double money;

    public int strength;
    public int agility;
    public int intelligence;

    public PlayerData(string p_name, int p_level, double p_money, int p_strength, int p_agility, int p_intelligence)
    {
        name = p_name;
        level = p_level;
        money = p_money;
        strength = p_strength;
        agility = p_agility;
        intelligence = p_intelligence;
    }
}
