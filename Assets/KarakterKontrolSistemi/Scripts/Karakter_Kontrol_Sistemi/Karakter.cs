using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace mesut_atakan
{
    namespace karakter_Kontrolleri
    {
        [CreateAssetMenu(fileName = "Karakter Olustur", menuName = "Karakter_Kontrol/KarakterOlustur")]

        public class Karakter : ScriptableObject
        {
            #region karakterin kimligini olusturan degiskenler
            [Header("Karakter Kimligi")]

            [Tooltip("Karakterin ismini buraya giriniz")]
            public string karakterIsim;




            [Tooltip("Karakter Aciklamasini Giriniz")]
            public string karakterAciklama;






            [Space(15f)]








            [Header("Karakter Tasarimi")]

            [Tooltip("Karakter Modelini Buraya Atiniz")]
            public GameObject karakterPrefab;



            [Tooltip("Karakter Gorselini Buraya Atiniz")]
            public Sprite karakterGorsel;




            [Tooltip("Karakter Animator komponentini buraya atiniz")]
            public Animator karakterAnimator;
            #endregion





            [Space(15f)]






            #region karakterin fiziksel ozellikleri
            [Header("Karakter Ozellikleri")]

            [Tooltip("Karakter Max Can Miktari")]
            public float karakterMaxCanMiktari;




            [Space(7f)]
            [Header("Hiz degiskenleri")]
            [Tooltip("Karakterin yurume hizini giriniz")]
            public float karakterYurumeHizi;



            [Tooltip("Karakterin kosma hizini giriniz")]
            public float karakterKosmaHizi;



            [Tooltip("Karakterin egilme hizini giriniz")]
            public float karakterEgilmeHizi;




            [Space(7f)]




            [Header("diger hiz degiskenleri")]
            [Tooltip("Karakter ne kadar Yuksege Ziplayabilir")]
            public float karakterZiplamaYuksekligi;




            [Tooltip("Karakterin donus hizi")]
            public float karakterDonmeHizi = 0.1f;
            #endregion




            [Space(15f)]




            #region Karakterin ekstra ozelliklri
            [Header("karakter Extra")]
            public List<Yetenekler> yetenekler = new List<Yetenekler>();
            #endregion
        }

#if UNITY_EDITOR

        [CustomEditor(typeof(Karakter))]
        public class KarakterScriptableObjectEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
                Karakter karakterSCO = (Karakter)target;
                karakterSCO.karakterAnimator = (Animator)EditorGUILayout.ObjectField("Animator", karakterSCO.karakterAnimator, typeof(Animator), true);
            }
        }
#endif
    }
}
