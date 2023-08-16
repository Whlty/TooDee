using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveSlot : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private ItemClass item;
    [SerializeField] private ItemClass defaultItem;
    [SerializeField] private TextMeshProUGUI cooldownText;
    [SerializeField] private GameObject panel;
    [SerializeField] private SpriteRenderer mainHandSprite;
    private PlayerManager player;
    private float curCooldown = 0;

    private void Start()
    {
        player = GetComponentInParent<PlayerManager>();
        ChangeItem(item);
        ChangeKey(key);
    }
    public void ChangeKey(KeyCode _key)
    {
        key = _key;
        cooldownText.text = key.ToString();
    }
    public ItemClass ChangeItem(ItemClass _item = null)
    {
        ItemClass curItem = item;

        if (_item == null)
        {
            _item = defaultItem;
        }

        if (curItem == defaultItem)
        {
            curItem = null;
        }

        item = _item;
        GetComponent<Image>().sprite = _item.itemIcon;

        if (mainHandSprite != null)
            mainHandSprite.sprite = _item.itemIcon;

        return curItem;
    }

    private void Update()
    {
        if (curCooldown > 0)
        {
            curCooldown -= Time.deltaTime;
            UpdateVisuals(curCooldown);
            return;
        }

        if (Input.GetKeyDown(key))
        {
            item.Use(player);
            curCooldown = item.cooldown;
        }
    }

    private void UpdateVisuals(float time)
    {
        if (time > 0)
        {
            cooldownText.text = time.ToString("F1");
            panel.SetActive(true);
        }
        else
        {
            cooldownText.text = key.ToString();
            panel.SetActive(false);
        }

    }
}
