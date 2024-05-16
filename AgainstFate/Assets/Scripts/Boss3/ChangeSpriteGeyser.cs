using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteGeyser : MonoBehaviour
{
	[SerializeField] private Sprite smallGeyser;
    [SerializeField] private Sprite bigGeyser; 

	private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    public void activateSmallGeyserSprite()
    {
        spriteRenderer.sprite = smallGeyser;
    }

    public void activateBigGeyserSprite()
    {
        spriteRenderer.sprite = bigGeyser;
    }

    public void DeactivateSprite()
    {
        spriteRenderer.sprite = null;
    }
}
