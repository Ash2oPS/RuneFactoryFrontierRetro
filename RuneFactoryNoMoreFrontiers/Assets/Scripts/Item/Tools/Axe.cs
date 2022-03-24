using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_Axe", menuName = "Item/Tool/Axe", order = 0)]
public class Axe : Tool
{
    public List<Log> logsThatCanBeDestroyed;
    public int force;
}