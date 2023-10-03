using System;

namespace Patterns.Adapter
{
    [Serializable]
    public class Data
    {
        public string Dato1;
        public int Dato2;

        public Data(string Dato1, int Dato2)
        {
            this.Dato1 = Dato1;
            this.Dato2 = Dato2;
        }
    }
}