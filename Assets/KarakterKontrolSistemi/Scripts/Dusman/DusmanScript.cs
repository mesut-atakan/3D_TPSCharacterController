using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace mesut_atakan
{
    namespace karakter_Kontrolleri
    {

        public class DusmanScript : MonoBehaviour
        {
            public Karakter karakter;

            public float canMiktari;


            

            private void Awake()
            {
                if (karakter != null)
                {
                    canMiktari = karakter.karakterMaxCanMiktari;
                }
                else
                {
                    Debug.LogError($"<color=white>mesut_atakan.Karakter_Kontrolleri</color> <color=red>ERROR!</color> Bu scriptte Karakter sinifi bos birakilamaz! Bunun icin Project penceresine sag tiklayarak yeni bir karakter olusturunuz ve bu dusmanu gecerli scriptteki degiskene atayiniz!");
                }
            }
        }
    }
}
