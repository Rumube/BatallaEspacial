using Patterns.Adapter;
using UnityEngine;

namespace Assets.Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        private DataStore _fileDataStoreAdapter;

        private void Awake()
        {
            _fileDataStoreAdapter = new PlayerPrefsDataStoreAdapter();
            var data = new Data("Dato1", 123);
            _fileDataStoreAdapter.SetData(data, "Data1");
        }

        private void Start()
        {
            var data = _fileDataStoreAdapter.GetData<Data>("Data1");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}
