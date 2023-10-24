using UnityEngine;

[CreateAssetMenu(fileName = "HullConfig", menuName = "Ship/Hull Configuration")]
public class HullConfig : ScriptableObject
{
    public string hullName;
    public float baseSpeed;
    public float hp;
}