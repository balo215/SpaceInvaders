using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankThrusters : MonoBehaviour
{

    // Properties
    public float initialSpeed = 5f;
    public float initialFuelConsumption;

    // Upgrade rates (can be modified by the ShipBuilderManager)
    [HideInInspector]
    public float speedUpgradeRate;
    [HideInInspector]
    public float fuelConsumptionUpgradeRate;

    // Current values
    private float currentSpeed;
    private float currentFuelConsumption;

    private void Start()
    {
        currentSpeed = initialSpeed;
        currentFuelConsumption = initialFuelConsumption;
    }

    // Function to apply upgrades
    public void ApplyUpgrade()
    {
        currentSpeed += speedUpgradeRate;
        currentFuelConsumption += fuelConsumptionUpgradeRate;
    }

    // Function to reset values (for example, when swapping parts)
    public void ResetValues()
    {
        currentSpeed = initialSpeed;
        currentFuelConsumption = initialFuelConsumption;
    }

    // Function to retrieve current values
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public float GetCurrentFuelConsumption()
    {
        return currentFuelConsumption;
    }
}
