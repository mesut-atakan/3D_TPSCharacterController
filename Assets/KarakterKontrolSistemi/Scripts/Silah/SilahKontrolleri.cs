using Unity.VisualScripting;
using UnityEngine;

namespace mesut_atakan
{
    namespace karakter_Kontrolleri
    {
        public class SilahKontrolleri : MonoBehaviour
        {
            public KarakterScript karakterScript;

            private void Awake()
            {
                if (karakterScript == null)
                {
                    if (FindObjectOfType<KarakterScript>() != null)
                    {
                        karakterScript = FindObjectOfType<KarakterScript>();
                        return;
                    }
                    else
                    {
                        Debug.LogError($"<color=red>ERROR!</color> sahnede <KarakterScript> Bulunamadi!", this.gameObject); 
                        return;
                    }
                }
            }




            #region Tus Kontrolleri


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
        }
    }
}