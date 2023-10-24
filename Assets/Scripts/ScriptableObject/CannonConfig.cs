using UnityEngine;

[CreateAssetMenu(fileName = "CannonConfig", menuName = "Ship/Cannon Configuration")]
public class CannonConfig : ScriptableObject
{
    public string CannonName;
    public float damage;
    public float fireRate;
}