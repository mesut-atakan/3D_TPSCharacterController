using UnityEngine;

namespace mesut_atakan
{
    namespace karakter_Kontrolleri
    {
        public class Silah : MonoBehaviour
        {
            SilahOzellikleri silah;
        }


        [System.Serializable]
        public struct SilahOzellikleri
        {
            public string isim;
            public string aciklama;
            public int hasarMiktari;
            public bool hasarVerebilir;
            public SilahTipi silahTipi;
        }

        public enum SilahTipi
        {
            hancer,
            kilic,
            mizrak,
            yay
        }
    }
}