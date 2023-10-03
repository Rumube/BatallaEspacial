using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Strategy
{
    public class Consumer
    {
        private readonly DataStore _dataStore;

        public Consumer(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Save()
        {
            object data = new Data("Hola", 324);
            _dataStore.SetData(data, "data2");
        }

        public void Load()
        {
            var data = _dataStore.GetData<Data>("data2");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}