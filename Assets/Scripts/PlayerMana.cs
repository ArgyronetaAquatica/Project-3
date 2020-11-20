using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{

    public int playerMana = 100;

    [SerializeField] Slider manaSlider = null;

    public void SubtractMana(int manaAmount)
    {
        playerMana -= manaAmount;
        manaSlider.value = playerMana;
    }

}
