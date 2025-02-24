using UnityEngine;

public class MedicineChestSpawner : Spawner<MedicineChest>
{
    protected override Pool<MedicineChest> CreatePool()
    {
        return GetComponent<Pool<MedicineChest>>() ?? gameObject.AddComponent<Pool<MedicineChest>>();
    }
}