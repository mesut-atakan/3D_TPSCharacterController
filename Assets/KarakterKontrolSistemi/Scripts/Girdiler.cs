using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace mesut_atakan
{
    namespace karakter_Kontrolleri
    {
        [CreateAssetMenu(fileName = "Girdi_Listesi", menuName = "Karakter_Kontrol/GirdiListesi")]

        public class Girdiler : ScriptableObject
        {
            [Header("Karakter Girdileri")]
            [Header("Ileri Gitme Tuslari")]

            [Tooltip("Karkterin Ileri Gitmesi icin kullanilacak ana tus")]
            public KeyCode ileriTusuA = KeyCode.W;

            [Tooltip("Karkterin Ileri Gitmesi icin kullanilacak ikinci tus")]
            public KeyCode ileriTusuB = KeyCode.UpArrow;



            [Header("Geri Gitme Tuslari")]

            [Tooltip("Karkterin Geri Gitmesi icin kullanilacak ana tus")]
            public KeyCode geriTusuA = KeyCode.S;

            [Tooltip("Karkterin Geri Gitmesi icin kullanilacak ikinci tus")]
            public KeyCode geriTusuB = KeyCode.DownArrow;




            [Header("Saga Gitme Tuslari")]

            [Tooltip("Karkterin Sag Gitmesi icin kullanilacak ana tus")]
            public KeyCode sagTusuA = KeyCode.D;

            [Tooltip("Karkterin Sag Gitmesi icin kullanilacak ikinci tus")]
            public KeyCode sagTusuB = KeyCode.RightArrow;





            [Header("Sola Gitme Tuslari")]

            [Tooltip("Karkterin Sol Gitmesi icin kullanilacak ana tus")]
            public KeyCode solTusuA = KeyCode.A;

            [Tooltip("Karkterin Sol Gitmesi icin kullanilacak ikinci tus")]
            public KeyCode solTusuB = KeyCode.LeftArrow;



            [Header("Karakter Kosma Tuslari")]

            [Tooltip("Karkterin kosmasi icin kullanilacak ana tus")]
            public KeyCode kosmaTusuA = KeyCode.LeftShift;

            [Tooltip("Karkterin kosmasi icin kullanilacak ikinci tus")]
            public KeyCode kosmaTusuB = KeyCode.RightShift;



            [Header("Karakter Egilme Tuslari")]

            [Tooltip("Karkterin egilmesi icin kullanilacak ana tus")]
            public KeyCode egilmeTusuA = KeyCode.LeftControl;

            [Tooltip("Karkterin egilmesi icin kullanilacak ikinci tus")]
            public KeyCode egilmeTusuB = KeyCode.RightControl;




            [Space(30f)]

            [Header("Ates Etme Girdileri")]

            [Tooltip("karakterin vurus yapabilmesi icin kullanilan ana tus")]
            public KeyCode atesEtmeTusuA = KeyCode.Mouse0;

            [Tooltip("karakterin vurus yapabilmesi icin kullanilan ikinci tus (deffault olarak bu tus bos birakilmistur (KeyCode.None)")]
            public KeyCode atesEtmeTusuB = KeyCode.None;


            [Space(5f)]

            [Header("Nisan Alma Girdileri")]

            [Tooltip("karakterin Nisan almasi icin kullanilan ana tusu giriniz")]
            public KeyCode nisanAlmaTusuA = KeyCode.Mouse1;

            [Tooltip("karakterin Nisan almasi icin kullanilan ikinci tusu giriniz")]
            public KeyCode nisanAlmaTusuB = KeyCode.None;
        }
    }
}

