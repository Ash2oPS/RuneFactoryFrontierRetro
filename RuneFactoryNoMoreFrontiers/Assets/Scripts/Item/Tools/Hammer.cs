using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_Hammer", menuName = "Item/Tool/Hammer", order = 0)]
public class Hammer : Tool
{
    public List<Rock> rocksThatCanBeDestroyed;
    public int force;
}