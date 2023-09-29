using UnityEngine;

[CreateAssetMenu(fileName = "ThrusterConfig", menuName = "Ship/Thruster Configuration")]
public class ThrusterConfig : ScriptableObject
{
    public string thrusterName;
    public float baseSpeed;
    public float baseFuelConsumption;
}