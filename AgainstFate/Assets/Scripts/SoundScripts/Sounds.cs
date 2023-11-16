using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds; // массив категорий
    public SoundArrays[] randSound; // массив звуков кате

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySound(int index, float volume = 1f, bool random = false, bool destroyed = false, float p1 = 1f, float p2 = 1f)
    {
        AudioClip clip = random ? randSound[index].soundArray[Random.Range(0, randSound[index].soundArray.Length)] : sounds[index];
        audioSrc.pitch = Random.Range(p1, p2);               //спасибо паскалю за сокращенную запись функций и элсы в виде вопросов
                                                             //это дофига крутая функция выбора звуков из заколхоженного массива массивов (спасибо Станиславу Станиславовичу)
        if (destroyed)                                       //ну и в ней выбирается рандомный звук из промежутка от нуля до длины массива в массивах
            AudioSource.PlayClipAtPoint(clip, transform.position);
        else
            audioSrc.PlayOneShot(clip, volume);
        //следовательно в главном массиве я смогу задать тип нужных мне звуков, а в меньших по "классу" - выбор случайных звуков
        //тогда бульки лавы будут так же рандомиться и каждый раз быть разными (я думаю что смогу набрать еще больше бульков
    }                                          // с оружием и прыжками история такая же. да и впринципе со всем, где должны быть случайные звуки
                                               // в событии, например, пробела я должен задавать номер звука и рандом, чтобы выбор был случайным
                                               //к слову, чтобы задать звук уничтожения объекта, нужно просто написать событие, привязать звук и написать Destroy(gameObject)
    [System.Serializable]
    public class SoundArrays
    {
        public AudioClip[] soundArray;
    }

    public void PlayToggleEvent(int index) 
    {
        PlaySound(index, 1f, true);
    
    }



}


/// 0 - звуки менюшки (00 - наведение, 01 - клик);
///

