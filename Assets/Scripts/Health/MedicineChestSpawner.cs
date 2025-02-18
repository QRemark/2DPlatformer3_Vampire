using UnityEngine;

public class MedicineChestSpawner : Spawner<MedicineChest>
{
    protected override Pool<MedicineChest> CreatePool()
    {
        return GetComponent<Pool<MedicineChest>>() ?? gameObject.AddComponent<Pool<MedicineChest>>();
    }
}


//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(MedicineChestPool))]
//public class MedicineChestSpawner : MonoBehaviour
//{
//    [SerializeField] private MedicineChest _prefab;
//    [SerializeField] private List<Transform> _spawnPoints;

//    private int _poolCapacity = 5;

//    private MedicineChestPool _medicienceChestPool;

//    private void Awake()
//    {
//        _medicienceChestPool = gameObject.GetComponent<MedicineChestPool>();
//        _medicienceChestPool.Initialize(_prefab, _poolCapacity);
//    }

//    private void Start()
//    {
//        SpawnMedicineChest();
//    }

//    public void SpawnMedicineChest()
//    {
//        for (int i = 0; i < _spawnPoints.Count; i++)
//        {
//            MedicineChest medicineChest = _medicienceChestPool.GetObject();

//            if (medicineChest != null)
//            {
//                medicineChest.transform.position = _spawnPoints[i].position;
//                medicineChest.OnCollected += ReturnMedicineChestInPool;
//            }
//        }
//    }

//    public void ReturnMedicineChestInPool(MedicineChest medicineChest)
//    {
//        medicineChest.OnCollected -= ReturnMedicineChestInPool;
//        _medicienceChestPool.ReleaseObject(medicineChest);
//    }

//#if UNITY_EDITOR
//    [ContextMenu("Refresh Child Array")]
//    private void RefreshChildArray()
//    {
//        int pointCount = transform.childCount;
//        _spawnPoints = new List<Transform>();

//        for (int i = 0; i < pointCount; i++)
//            _spawnPoints.Add(transform.GetChild(i));
//    }
//#endif
//}
