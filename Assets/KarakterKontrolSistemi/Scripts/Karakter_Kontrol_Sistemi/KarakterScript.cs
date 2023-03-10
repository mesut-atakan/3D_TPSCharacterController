using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

namespace mesut_atakan 
{
    namespace karakter_Kontrolleri
    {
        [RequireComponent(typeof(CharacterController))]
        [RequireComponent(typeof(CapsuleCollider))]
        [RequireComponent(typeof(SilahKontrolleri))]
        public class KarakterScript : MonoBehaviour
        {
            [Header("Karakter")]
            [Tooltip("bu karakteri kontrol edebilmek icin kullancagimiz tum verileri bu siniftan cekecegiz")]
            public Karakter karakter;


            //karakteri haraket ettirebilmek icin gereken her turlu component degiskenini buraya yazacagiz
            [Header("COMPONENTS")]

            [Tooltip("karakterin haraket etmesini saglayabilmek icin 'CharacterController' componentini buraya atiniz (bu component zaten bu scriptin bulundugu objenin icerisinde mevcut!")]
            public CharacterController characterController;





            [Tooltip("oyun ayarlarinin bulundugu Script 'GameManager'")]
            public GameManager gameManager;

            [Tooltip("Bu girdiler sinifi GameManager icerisinde bulunan girdiler sinifindan referans alacaktir.")]
            public Girdiler girdiler;

            public SilahKontrolleri silahKontrolleri;




            [Space(10f)]









            [Header("Transforms")]

            [Tooltip("Sahnede bulunan kameranin Transform componenti.")]
            public new Transform camera;
            





            [Space(20f)]







            [Header("Karakter Haraket Degiskenleri")]

            [Tooltip("bu degisken karakterin anlik olarak hizini gostermektedir")]
            public float karakterHizi;

            [Tooltip("Karakterin icerisindeki donme hizini bu degisken referans olarak alacak")]
            public float donmeHizi;




            [Space(10f)]



            [Tooltip("Oyunun gercekci olabilmesi icin dunyadaki yercekimi kuvveti referans alinmistir bu degerde degisiklik yapmaniz tavsiye edilmez!")]
            public const float yercekimi = -9.81f;


            [Tooltip("Karakterin yere dusmesini saglamak icin kullanilacak sinif")]
            public Vector3 velocity;

            [Space(20f)]


            [Tooltip("karaktere bagli olan Animator Componenti")]
            public Animator animator;

            [Space(7f)]

            [Tooltip("Animator kontrollerini saglayan Script")]
            public AnimationKontrol animationKontrol;








            [Space(20f)]








            [Header("Silah")]

            [Tooltip("Silahin tutulacagi nokta (bu degisken bos bir GameObjecte baglanmak zorundadir ve bu GameObject karakterin avuc icinde durmalidir. Silah bu GameObjectin icinde olusturulacaktir boylelikle karakter silahini elinde tutacaktir.")]
            public GameObject silahPoint;

            [Tooltip("Yayin tutulacagi nokta (bu degisken bos bir GameObjecte baglanmak zorundadir ve bu GameObject karakterin avuc icinde durmalidir. Silah bu GameObjectin icinde olusturulacaktir boylelikle karakter silahini elinde tutacaktir.")]
            public GameObject yayPoint;

            [Tooltip("Oyun icerisinde karakterin vurus yapip yapamayacagini kontrol eder")]
            public bool attack = false;










            [Space(20f)]

            [Header("Karakter Ozellikleri")]

            [Tooltip("karakterin can miktarini bu script uzerinden ozellestirecegiz. NOT: bu deger oyun basinda eger save load islemi olmayacaksa scriptable turundeki karakter sinifindan karakter can miktarini cekecektir ve oyun basinda karakterin degeri o deger olacaktir.")]
            public float canMiktari;





            /// <summary>
            /// gerekli tanimlama islemlerini burada yapiyoruz.
            /// </summary>
            private void Awake()
            {
                //Dethis.giskenlerin ve componentlerin tanimlama islemlerini burada yapacagiz
                if (this.characterController == null) this.characterController = this.gameObject?.GetComponent<CharacterController>();
                if (this.karakter == null) karakter = this.gameObject?.GetComponent<Karakter>(); donmeHizi = karakter.karakterDonmeHizi;
                if (this.animator == null) animator = this.gameObject?.GetComponentInChildren<Animator>();
                if (this.gameManager == null) this.gameManager = GameObject.FindObjectOfType<GameManager>();

                if (this.girdiler == null || GameObject.FindObjectOfType<mesut_atakan.karakter_Kontrolleri.GameManager>() != null) {
                    //girdiler = gameManager.girdiler;
                }
                else {
                    Debug.LogError($"<color=white>mesut_atakan.cs</color><color=red>ERROR!</color> Sahnede GameManager Scripti bulunmadi.\nBu sorunu cozmek icin sahneye bir GameManager objei olusturun ve icinde GameManager Componentini atayin.", gameObject);
                }

                //if (this.camera == null) this.camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>(); else Debug.LogError($"<color=white>mesut_atakan</color> <color=red>ERROR</color> Sahnenizdeki kameranizi bu scriptte bali olan 'camera' degiskeninin icerisine atiniz.", gameObject);
                if (this.animationKontrol == null) this.animationKontrol = this.gameObject?.GetComponentInChildren<AnimationKontrol>();



                if (this.karakter != null)
                {
                    this.canMiktari = this.karakter.karakterMaxCanMiktari;
                }
                else
                {
                    Debug.LogError($"<color=white>mesut_atakan/Karakter_Kontrolleri</color> <color=red>ERROR!</color> bu obje icerisinde bulunan <color=yellow>KarakterScript</color> componenti icerisindeki karakter degiskeni bos!");
                }


                if (this.silahKontrolleri == null)
                {
                    if (this.gameObject.GetComponent<SilahKontrolleri>() != null) this.silahKontrolleri = this.gameObject.GetComponent<SilahKontrolleri>();
                }
            }




            private void Update()
            {
                KarakterKontrolSistem();
                KarakterHaraketSistemi();
            }







            /// <summary>
            /// Karakteri haraket etmesini saglayacak metot
            /// </summary>
            public void KarakterKontrolSistem()
            {
                #region yurume kontrol
                if (yurume() == true && kosma() == false)
                {
                    karakterHizi = karakter.karakterYurumeHizi;
                    this.animationKontrol.animatorTusKontrol._yurume = true;
                }
                else // yurume == false
                {
                    this.animationKontrol.animatorTusKontrol._yurume = false;
                }

                if (yurume() == false && kosma() == false && egilme() == false)
                {
                    karakterHizi = 0;
                }
                #endregion

                #region kosma kontrol
                if (kosma() == true && yurume() == true)
                {
                    karakterHizi = karakter.karakterKosmaHizi;
                    this.animationKontrol.animatorTusKontrol._kosma = true;
                    this.animationKontrol.animatorTusKontrol._yurume = true;
                }
                else //kosma == false
                {
                    this.animationKontrol.animatorTusKontrol._kosma = false;
                }
                #endregion

                #region egilme kontrol
                if (egilme() == true && kosma() == false)
                {
                    this.animationKontrol.animatorTusKontrol._egilme = true;

                    if (yurume() == true)
                    {
                        karakterHizi = karakter.karakterEgilmeHizi;

                    }
                    else // egilme == true && yurume == false
                    {
                        karakterHizi = 0;
 
                    }
                }
                else if (egilme() == false)
                {
                    this.animationKontrol.animatorTusKontrol._egilme = false;
                }
                #endregion

                #region atak kontrol
                silahKontrolleri.AtakKontrol(girdiler.atesEtmeTusuA, girdiler.atesEtmeTusuB);
                #endregion

                #region nisan kontrol
                silahKontrolleri.AtakKontrol(girdiler.nisanAlmaTusuA, girdiler.nisanAlmaTusuB);
                #endregion
            }


            /// <summary>
            /// Bu metot ile karakterimiz haraket ediyor.
            /// </summary>
            public void KarakterHaraketSistemi()
            {
                float xEkseni = karakterHizi * xAxisControl();
                float zEkseni = karakterHizi * zAxisControl();
                Vector3 haraket = new Vector3(xEkseni, 0f, zEkseni);

                if (haraket.magnitude >= 0.1f && attack == false)
                {
                    float takipAcisi = Mathf.Atan2(haraket.x, haraket.z) * Mathf.Rad2Deg + this.camera.eulerAngles.y;
                    float aci = Mathf.SmoothDampAngle(transform.localEulerAngles.y, takipAcisi, ref donmeHizi, karakter.karakterDonmeHizi);
                    transform.rotation = Quaternion.Euler(0f, aci, 0f);

                    Vector3 haraketDir = Quaternion.Euler(0f, takipAcisi, 0f) * Vector3.forward;
                    characterController.Move(haraketDir.normalized * karakterHizi * Time.deltaTime);
                }

            }


            #region zAxisControl
            /// <summary>
            /// karakterin z ekseninde bastigi tuslara gore ileri veya geri gittigini anlayacagimiz bir metot yazdik
            /// </summary>
            /// <returns>Oyuncu ileri tusuna basiyorsa +1, geri tusuna basiyorsa -1, bu tuslara basmiyorsa 0 degerini dondurecek</returns>
            public int zAxisControl()
            {
                if (Input.GetKey(girdiler.ileriTusuA) && Input.GetKey(girdiler.ileriTusuB))
                {
                    return 1;
                }
                else if (Input.GetKey(girdiler.ileriTusuA) || Input.GetKey(girdiler.ileriTusuB))
                {
                    return 1;
                }
                else if (Input.GetKey(girdiler.geriTusuA) || Input.GetKey(girdiler.geriTusuB))
                {
                    return -1;
                }
                else if (Input.GetKey(girdiler.geriTusuA) && Input.GetKey(girdiler.geriTusuB))
                {
                    return -1;
                }
                else return 0;
            }

            #endregion

            #region xAxisControl
            /// <summary>
            /// karakterin x ekseninde bastigi tuslara gore ileri veya geri gittigini anlayacagimiz bir metot yazdik
            /// </summary>
            /// <returns>Oyuncu sag tusuna basiyorsa +1, sol tusuna basiyorsa -1, bu tuslara basmiyorsa 0 degerini dondurecek</returns>
            public int xAxisControl()
            {
                if (Input.GetKey(girdiler.sagTusuA) && Input.GetKey(girdiler.sagTusuB))
                {
                    return 1;
                }
                else if (Input.GetKey(girdiler.sagTusuA) || Input.GetKey(girdiler.sagTusuB))
                {
                    return 1;
                }
                else if (Input.GetKey(girdiler.solTusuA) || Input.GetKey(girdiler.solTusuB))
                {
                    return -1;
                }
                else if (Input.GetKey(girdiler.solTusuA) && Input.GetKey(girdiler.solTusuB))
                {
                    return -1;
                }
                else return 0;
            }
            #endregion


            #region Tus Kontrolleri

            #region yurume Tus Kontrolu
            /// <summary>
            /// karakterin yuruyup yurumedigini kontrol eden metot
            /// </summary>
            /// <returns>eger karakter yurumeye bagli tuslara basiyorsa bu metot true degerini geri donderecektir</returns>
            public bool yurume()
            {
                if ((Input.GetKey(girdiler.ileriTusuA) || Input.GetKey(girdiler.ileriTusuB))
                    || (Input.GetKey(girdiler.geriTusuA) || Input.GetKey(girdiler.geriTusuB))
                    || (Input.GetKey(girdiler.sagTusuA) || Input.GetKey(girdiler.sagTusuB))
                    || (Input.GetKey(girdiler.solTusuA) || Input.GetKey(girdiler.solTusuB)))
                {
                    return true;
                }
                else if ((Input.GetKey(girdiler.ileriTusuA) && Input.GetKey(girdiler.ileriTusuB))
                    && (Input.GetKey(girdiler.geriTusuA) && Input.GetKey(girdiler.geriTusuB))
                    && (Input.GetKey(girdiler.sagTusuA) && Input.GetKey(girdiler.sagTusuB))
                    && (Input.GetKey(girdiler.solTusuA) && Input.GetKey(girdiler.solTusuB))) return true;
                else return false;
            }
            #endregion


            #region kosma Tus Kontrolu
            /// <summary>
            /// karakterini kosup kosmadigini kontrol edecek geri dondurulebilir metot
            /// </summary>
            /// <returns>karakterin kostugunu veya kosmadigini geri donderecek.</returns>
            public bool kosma()
            {
                if (Input.GetKey(girdiler.kosmaTusuA) || Input.GetKey(girdiler.kosmaTusuB))   return true;
            
                else if (Input.GetKey(girdiler.kosmaTusuA) && Input.GetKey(girdiler.kosmaTusuB))   return true;
                
                else return false;
            }
            #endregion


            #region egilme Tus Kontrolu
            /// <summary>
            /// bu metot karakterin egilip egilmedigini kontrol edicek
            /// </summary>
            /// <returns>eger karakter egilme tuslarina basiyorsa bu metot geriye true degerini donderecek</returns>
            public bool egilme()
            {
                if (Input.GetKey(girdiler.egilmeTusuA) || Input.GetKey(girdiler.egilmeTusuB)) return true;

                else if (Input.GetKey(girdiler.egilmeTusuA) && Input.GetKey(girdiler.egilmeTusuB)) return true;

                else return false;
            }
            #endregion


            #region Atak Tus Kontrolu

            /// <summary>
            /// Ates etme, nisan alma, kilic sallama gibi tuslarin kontrolunu yapan boolean metot
            /// </summary>
            /// <param name="atakKeyA"> girdiler sinifinda olusturdugunuz ataktusu A veya Nisan Tusu A kullanabilirsiniz </param>
            /// <param name="atakKeyB"> girdiler sinifinda olusturdugunuz ataktusu B veya Nisan Tusu B kullanabilirsiniz </param>
            /// <returns></returns>
            public bool AtakKontrol(KeyCode atakKeyA, KeyCode atakKeyB)
            {
                if (Input.GetKeyDown(atakKeyA) && Input.GetKeyDown(atakKeyB))
                {
                    return true;
                }

                if (Input.GetKeyDown(atakKeyA) || Input.GetKeyDown(atakKeyB))
                {
                    return true;
                }

                if (Input.GetKeyUp(atakKeyA) && Input.GetKeyUp(atakKeyB))
                {
                    return false;
                }

                if (Input.GetKeyUp(atakKeyA) || Input.GetKeyUp(atakKeyB))
                {
                    return false;
                }

                else return false;
            }


            #endregion

            #endregion
        }
    }
}
