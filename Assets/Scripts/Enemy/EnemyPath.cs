using UnityEngine;
using System.Collections.Generic;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _points; 

    public IReadOnlyList<Transform> Points => _points.AsReadOnly();

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int pointCount = transform.childCount;
        _points = new List<Transform>();

        for (int i = 0; i < pointCount; i++)
            _points.Add(transform.GetChild(i));
    }
#endif
}