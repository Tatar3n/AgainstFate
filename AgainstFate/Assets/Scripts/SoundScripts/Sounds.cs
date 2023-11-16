using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds; // ������ ���������
    public SoundArrays[] randSound; // ������ ������ ����

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySound(int index, float volume = 1f, bool random = false, bool destroyed = false, float p1 = 1f, float p2 = 1f)
    {
        AudioClip clip = random ? randSound[index].soundArray[Random.Range(0, randSound[index].soundArray.Length)] : sounds[index];
        audioSrc.pitch = Random.Range(p1, p2);               //������� ������� �� ����������� ������ ������� � ���� � ���� ��������
                                                             //��� ������ ������ ������� ������ ������ �� �������������� ������� �������� (������� ���������� ��������������)
        if (destroyed)                                       //�� � � ��� ���������� ��������� ���� �� ���������� �� ���� �� ����� ������� � ��������
            AudioSource.PlayClipAtPoint(clip, transform.position);
        else
            audioSrc.PlayOneShot(clip, volume);
        //������������� � ������� ������� � ����� ������ ��� ������ ��� ������, � � ������� �� "������" - ����� ��������� ������
        //����� ������ ���� ����� ��� �� ����������� � ������ ��� ���� ������� (� ����� ��� ����� ������� ��� ������ �������
    }                                          // � ������� � �������� ������� ����� ��. �� � ��������� �� ����, ��� ������ ���� ��������� �����
                                               // � �������, ��������, ������� � ������ �������� ����� ����� � ������, ����� ����� ��� ���������
                                               //� �����, ����� ������ ���� ����������� �������, ����� ������ �������� �������, ��������� ���� � �������� Destroy(gameObject)
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


/// 0 - ����� ������� (00 - ���������, 01 - ����);
///

