using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropData", menuName = "Data/DropData", order = 1)]
public class DropData : ScriptableObject
{
    [System.Serializable]
    public class DropEntry
    {
        public GameObject prefab;
        public float chance;
    }
    [SerializeField] private DropEntry[] dropTable;

    [SerializeField, SceneEditOnly] private bool validate;

    private void OnValidate()
    {
        if (Application.isPlaying)
            return;

        if (validate == false)
            return;

        validate = false;


        // Normalize chances
        float sum = 0.0f;
        for (int i = 0; i < dropTable.Length; i++)
            sum += dropTable[i].chance;

        if (sum <= float.Epsilon)
            return;

        for (int i = 0; i < dropTable.Length; i++)
            dropTable[i].chance /= sum;
    }

    private GameObject GetRandomPrefab()
    {
        // Select drop object using 'accumulator' method
        float accum = 0.0f;
        for (int i = 0; i < dropTable.Length; i++)
        {
            float chance = dropTable[i].chance;
            float rand = Random.value;
            if (rand > chance + accum)
                return dropTable[i].prefab;

             accum += dropTable[i].chance;
        }
        return dropTable[0].prefab;
    }

    public void DropAt( Transform dropper )
    {
        GameObject prefab = GetRandomPrefab();
        GameObject.Instantiate(prefab, dropper.position, Quaternion.identity);
    }

}
