using UnityEngine;

[CreateAssetMenu(fileName = "ExtraConfig", menuName = "Ship/Extra Configuration")]
public class ExtraConfig : ScriptableObject
{
    public string propertyLabel;
    public float damage;
    public float fireRate;
    public string extraName;
    public float fuelCons;
}