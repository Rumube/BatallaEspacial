using UnityEngine;

namespace Core.Serializers
{
    public class JsonUtilityAdapter : Serializer
    {
        public T FromJson<T>(string data)
        {
            return JsonUtility.FromJson<T>(data);
        }

        public string ToJson<T>(T data)
        {
            return JsonUtility.ToJson(data);
        }
    }
}
