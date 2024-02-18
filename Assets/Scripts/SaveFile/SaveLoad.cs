using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Runs off of the ISerializable object.
/// Can mark a class as [SerializableAttribute]
/// and mark the parts that shouldn't be serialized as [NonSerialized]
/// </summary>
public static class SaveLoad {
    private static Dictionary<System.Type, LinkedList<ISerializable>> allData;
    private const string fileName = "vgp145_saveFile.bin";

    // Dummy encryption stuff
    private static readonly byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 };
    private static readonly byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };
    /// <summary>
    /// Update the saveFile to reflect the serialized data that has been added
    /// https://stackoverflow.com/questions/5869922/c-sharp-encrypt-serialized-file-before-writing-to-disk
    /// </summary>
    public static void Save() {
        string saveFilePath = Path.Combine(Application.persistentDataPath, fileName);
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        FileStream fs = new FileStream(saveFilePath, FileMode.CreateNew, FileAccess.Write);
        CryptoStream cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(cryptoStream, allData);
    }

    /// <summary>
    /// Load the saveFile to load the seralized data. Don't forget to instantiate objects
    /// https://stackoverflow.com/questions/5869922/c-sharp-encrypt-serialized-file-before-writing-to-disk
    /// </summary>
    public static void Load() {
        string saveFilePath = Path.Combine(Application.persistentDataPath, fileName);
        FileStream fs = new FileStream(saveFilePath, FileMode.OpenOrCreate, FileAccess.Read);
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        CryptoStream cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read);
        BinaryFormatter formatter = new BinaryFormatter();
        allData = (Dictionary<System.Type, LinkedList<ISerializable>>) formatter.Deserialize(cryptoStream);
    }

    /// <summary>
    /// List of objects that can be saved.
    /// </summary>
    /// <param name="obj">The object to be saved implementing ISerializable</param>
    public static void addSaveable(ISerializable obj) {
        if (!allData.ContainsKey(obj.GetType()))
            allData.Add(obj.GetType(), new LinkedList<ISerializable>());
        allData.TryGetValue(obj.GetType(), out LinkedList<ISerializable> linkedList);
        linkedList.AddLast(obj);
    }

    /// <summary>
    /// Remove type from save object (in preperation for new data)
    /// </summary>
    /// <param name="obj">The</param>
    public static void resetType(Type type) {
        if (allData.ContainsKey(type))
            allData.Remove(type);
    }

    /// <summary>
    /// Returns an Enumerator to iterate through all the objects of defined type.
    /// Anticipated to be used for MonoBehavior objects that need to be Instantiated.
    /// https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
    /// </summary>
    /// <param name="type">System.Type of object.</param>
    /// <returns>Enumerator. Will need "while MoveNext: Current" loop</returns>
    public static LinkedList<ISerializable>.Enumerator getObjects(Type type) {
        allData.TryGetValue(type, out LinkedList<ISerializable> linkedList);
        return linkedList.GetEnumerator();
    }
}