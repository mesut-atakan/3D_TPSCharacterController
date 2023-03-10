using UnityEngine;


namespace mesut_atakan
{
    namespace karakter_Kontrolleri
    {
        public class AnimationKontrol : MonoBehaviour
        {
            [Header("Components")]
            public KarakterScript karakterScript;

            [Tooltip("KarkterScript icerisindeki Karakter sinifinda bulunan karakterAnimatorController buraya referans olarak gelecek")]
            public Animator animatorController;

            public animatorTusKontrol animatorTusKontrol;

            public BoxCollider silahBoxCollider;


            

            private void Awake()
            {
                if (this.karakterScript == null) this.karakterScript = this.gameObject.GetComponentInParent<KarakterScript>();
                if (this.animatorController == null) this.animatorController = this.karakterScript.karakter.karakterAnimator;
                
            }


            private void Start()
            {
                if (this.silahBoxCollider == null) this.silahBoxCollider = this.karakterScript.silahPoint.gameObject.GetComponentInChildren<BoxCollider>();

            }

            private void Update()
            {
                animationKontrolSistemi();
            }

            /// <summary>
            /// oyuncunun yaptigi haraketlerin animasyonlarini veren metot
            /// </summary>
            public void animationKontrolSistemi()
            {
                this.animatorController.SetBool(this.animatorTusKontrol.beklemeKey, this.animatorTusKontrol._bekleme);
                this.animatorController.SetBool(this.animatorTusKontrol.yurumeKey, this.animatorTusKontrol._yurume);
                this.animatorController.SetBool(this.animatorTusKontrol.kosmaKey, this.animatorTusKontrol._kosma);
                this.animatorController.SetBool(this.animatorTusKontrol.egilmeKey, this.animatorTusKontrol._egilme);
                this.animatorController.SetBool(this.animatorTusKontrol.atakKey, this.animatorTusKontrol._atak);
                this.animatorController.SetBool(this.animatorTusKontrol.nisanKey, this.animatorTusKontrol._nisan);
            }






            public bool atackStart()
            {
                if (this.silahBoxCollider == null) this.silahBoxCollider = this.karakterScript.silahPoint.gameObject.GetComponentInChildren<BoxCollider>();

                
                karakterScript.attack = true;

                return true;
            }

            /*
            public bool attackEnd()
            {
                if (silahKontrolleri.silah.silahTuru != silahTuru.Menzilli)
                {
                    silahBoxCollider.enabled = true;
                }

                karakterScript.attack = false;
                return false;
            }
            */
        }

        [System.Serializable]
        public class animatorTusKontrol
        {
            //oyuncu eger hicbir tusa basmiyorsa bu boolen true dondurecek
            public bool _bekleme { get; set; }

            //oyuncu eger yurumek icin tanimlanan tuslardan herhangi birine basarsa bile bu boolean true dondurecek
            public bool _yurume { get; set; }

            //oyuncu eger yurume tuslarindan herhangi birine ve kosma tusuna basmasi durumunda bu boolean true dondurecek ve kosma animasyonu calistirilacak

            public bool _kosma { get; set; }

            //oyuncu eger egilme tusuna basarsa bu boolean degerini true dondurecek
            public bool _egilme { get; set; }

            //oyuncu eger savasmak icin gereken tusa basarsa bu degisken degerini true olarak donderecektir.
            public bool _atak { get; set; }

            //oyuncu eger nisan almak icin gereken tusa basarsa bu degisken degeri true olarak donecektir.
            public bool _nisan { get; set; }




            [Tooltip("Animator Ziplama parametresi adini buraya giriniz")]
            public string ziplamaKey = "ziplama";

            [Tooltip("Animator yurume parametresi adini buraya giriniz")]
            public string yurumeKey = "yurume";

            [Tooltip("Animator kosma parametresi adini buraya giriniz")]
            public string kosmaKey = "kosma";

            [Tooltip("Animator bekleme parametresi adini buraya giriniz")]
            public string beklemeKey = "bekleme";

            [Tooltip("Animator egilme parametresi adini buraya giriniz")]
            public string egilmeKey = "egilme";

            [Tooltip("Animator atak parametresi adini buraya giriniz")]
            public string atakKey = "atak";

            [Tooltip("Animator atak parametresi adini buraya giriniz")]
            public string nisanKey = "nisan";
        }
    }
}

