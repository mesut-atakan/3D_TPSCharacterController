using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mesut_atakan
{
    namespace karakter_Kontrolleri
    {
        public class GameManager : MonoBehaviour
        {
            //[Header("Oyun Ayarlari")]

            /*[Tooltip("Olusturdugunuz Scriptable Object turundeki girdiler sinifini buraya surukleyin. Oyun mekanikleriniz bu siniftaki tus sistemine gore oynanacaktir.")]
            public Girdiler girdiler;*/













            /// <summary>
            /// oyuncu ekranda herhangi bir noktaya 'mouse 0' ile bastiginda ne olacagini gosterir.
            /// </summary>
            private void OnMouseDown()
            {
                MouseVisible(false);
            }


            /// <summary>
            /// Oyun duraklatildiginda bu metot otomatik olarak cagrilacak
            /// </summary>
            /// <param name="pause">oyunun durup durmadigini kontrol edecek olan parametre</param>
            private void OnApplicationPause(bool pause)
            {
                MouseVisible(pause);
            }


            /// <summary>
            /// Mousenin ekrandaki gorunurlugunu kapatacak olan metot!
            /// </summary>
            /// <param name="_able"></param>
            public void MouseVisible(bool _able)
            {
                Cursor.visible = _able;

                if (_able) Cursor.lockState = CursorLockMode.None;
                else Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
