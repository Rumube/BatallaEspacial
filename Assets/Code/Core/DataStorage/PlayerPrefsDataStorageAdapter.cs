using UnityEngine;
using Patterns.Adapter;
using Core.Serializers;


namespace Core.DataStorage
{
    public class PlayerPrefsDataStorageAdapter : DataStore
    {
        private readonly Serializer _serializer;

        public PlayerPrefsDataStorageAdapter(Serializer serializer)
        {
            _serializer = serializer;
        }

        public void SetData<T>(T data, string name)
        {
            var json = _serializer.ToJson(data);
            PlayerPrefs.SetString(name, json);
            PlayerPrefs.Save();
        }

        public T GetData<T>(string name)
        {
            var json = PlayerPrefs.GetString(name);
            return _serializer.FromJson<T>(json);
        }
    }
}

