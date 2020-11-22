using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{

    public int playerMana = 100;

    public int manaPackReserve = 0;

    [SerializeField] Slider manaSlider = null;
    [SerializeField] Text manaPackText = null;

    [SerializeField] AudioClip refillSound = null;

    public void SubtractMana(int manaAmount)
    {
        playerMana -= manaAmount;
        manaSlider.value = playerMana;
    }

    public void AddManaPack()
    {
        manaPackReserve += 1;
        manaPackText.text = manaPackReserve.ToString();
    }

    public void ReEquipMana()
    {
        if(manaPackReserve > 0)
        {
            playerMana = 100;
            manaPackReserve -= 1;
            manaPackText.text = manaPackReserve.ToString();
            AudioHelper.PlayClip2D(refillSound, 1f);
        }
    }

}
