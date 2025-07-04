using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    #region 单例模式
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        // DontDestroyOnLoad(gameObject);
    }
    #endregion

    public const float soundVolume = .03f;

    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private void Start()
    {
        OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
        CuttingCounter.OnRecipeCut += CuttingCounter_OnRecipeCut;
        KitchenObjectHolder.OnDrop += KitchenObjectHolder_OnDrop;
        KitchenObjectHolder.OnPickup += KitchenObjectHolder_OnPickup;
        TrashCounter.OnObjectTrashed += TrashCounter_OnObjectTrashed;
    }

    

    private void TrashCounter_OnObjectTrashed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.trash);
    }

    private void KitchenObjectHolder_OnPickup(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickup);
    }

    private void KitchenObjectHolder_OnDrop(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectDrop);
    }

    private void CuttingCounter_OnRecipeCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.chop);
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.dekiveryFail);
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliverySuccess);
    }

    public void PlayStepSound(float _volume = soundVolume)
    {
        PlaySound(audioClipRefsSO.footStep,_volume);
    }

    private void PlaySound(AudioClip[] _clips, float _volume = soundVolume)
    {
        PlaySound(_clips, Camera.main.transform.position, _volume);
    }

    private void PlaySound(AudioClip[] _clips, Vector3 _position, float _volume = soundVolume)
    {
        int index = Random.Range(0, _clips.Length);

        AudioSource.PlayClipAtPoint(_clips[index], _position, _volume);
    }


}
