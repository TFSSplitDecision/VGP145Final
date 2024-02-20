using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

/// <summary>
/// Saveable data must extend the ISaveable interface and be marked as [Serializable]
/// (and mark the parts that shouldn't be serialized as [NonSerialized],
/// but why would u if class only holds data)
/// Designed as a single file system
/// </summary>
public static class SaveLoad {
    private static Dictionary<Type, LinkedList<ISaveable>> _allData = null;
    private static Dictionary<Type, LinkedList<ISaveable>> allData {
        set {
            _allData = value;
        }
        get {
            if (_allData == null) Load();
            return _allData;
        }
    }
    private static Dictionary<string, string> testData = new Dictionary<string, string>();
    private const string fileName = "vgp145_saveFile.bin";

    // Dummy encryption stuff
    private static readonly byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 };
    private static readonly byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };
    /// <summary>
    /// Update the saveFile to reflect the serialized data that has been added
    /// https://stackoverflow.com/questions/5869922/c-sharp-encrypt-serialized-file-before-writing-to-disk
    /// </summary>
    public static void Save() {
        string saveFilePath = Path.Combine(UnityEngine.Application.persistentDataPath, fileName);
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        FileStream fs = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write);
        CryptoStream cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, allData);
        //formatter.Serialize(cryptoStream, allData);
    }

    /// <summary>
    /// Load the saveFile to load the seralized data. Don't forget to instantiate objects
    /// https://stackoverflow.com/questions/5869922/c-sharp-encrypt-serialized-file-before-writing-to-disk
    /// </summary>
    public static void Load() {
        string saveFilePath = Path.Combine(UnityEngine.Application.persistentDataPath, fileName);
        if (!File.Exists(saveFilePath)) {
            _allData = new Dictionary<Type, LinkedList<ISaveable>>();
            return;
        }
        FileStream fs = new FileStream(saveFilePath, FileMode.Open, FileAccess.Read);
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        CryptoStream cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read);
        BinaryFormatter formatter = new BinaryFormatter();
        try {
            // _allData = (Dictionary<Type, LinkedList<ISaveable>>) formatter.Deserialize(cryptoStream);
            _allData = (Dictionary<Type, LinkedList<ISaveable>>) formatter.Deserialize(fs);
        } catch {
            // Bad format, trying again
            UnityEngine.Debug.Log("Issue decyphering save file. Restarting from scratch");
            _allData = new Dictionary<Type, LinkedList<ISaveable>>();
        }
    }

    /// <summary>
    /// List of objects that can be saved.
    /// </summary>
    /// <param name="obj">The object to be saved implementing ISerializable</param>
    public static void addSaveable(ISaveable obj) {
        if (!allData.ContainsKey(obj.GetType()))
            allData.Add(obj.GetType(), new LinkedList<ISaveable>());
        allData.TryGetValue(obj.GetType(), out LinkedList<ISaveable> linkedList);
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
    public static LinkedList<ISaveable>.Enumerator getObjects(Type type) {
        LinkedList<ISaveable> linkedList = allData.GetValueOrDefault(type, new LinkedList<ISaveable>());
        return linkedList.GetEnumerator();
    }
}