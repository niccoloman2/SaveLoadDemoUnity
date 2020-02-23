using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DemoManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characterDisplayPanel;

    [SerializeField]
    private Text nameLabel;

    [SerializeField]
    private Text levelLabel;

    [SerializeField]
    private Text moneyLabel;

    [SerializeField]
    private Text strLabel;

    [SerializeField]
    private Text agiLabel;

    [SerializeField]
    private Text intLabel;

    [SerializeField]
    private GameObject startMenu;

    [SerializeField]
    private InputField characterNameInput;

    PlayerData currentPlayerData;

    public void NewCharacter()
    {
        currentPlayerData = new PlayerData(characterNameInput.text, 1, 0, 5, 5, 5);

        UpdateCharacterDisplay();

        startMenu.SetActive(false);
        characterDisplayPanel.SetActive(true);
    }

    public void LoadCharacter()
    {
        PlayerData dataToLoad = SaveDataManager.LoadPlayerData();

        if(dataToLoad != null)
        {
            currentPlayerData = dataToLoad;
        }
        else
        {
            Debug.Log("no save file found");
            return;
        }

        UpdateCharacterDisplay();

        startMenu.SetActive(false);
        characterDisplayPanel.SetActive(true);
    }

    public void LevelUp()
    {
        currentPlayerData.level += 1;
        currentPlayerData.strength += Random.Range(5, 10);
        currentPlayerData.agility += Random.Range(5, 10);
        currentPlayerData.intelligence += Random.Range(5, 10);
        currentPlayerData.money += Random.Range(100, 500);

        UpdateCharacterDisplay();
    }

    public void SaveCharacter()
    {
        SaveDataManager.SavePlayerData(currentPlayerData);
    }

    private void UpdateCharacterDisplay()
    {
        nameLabel.text = "Name: " + currentPlayerData.name;
        levelLabel.text = "Level: " + currentPlayerData.level.ToString();
        moneyLabel.text = "Money: " + currentPlayerData.money.ToString();
        strLabel.text = "STR: " + currentPlayerData.strength.ToString();
        agiLabel.text = "AGI: " + currentPlayerData.agility.ToString();
        intLabel.text = "INT: " + currentPlayerData.intelligence.ToString();
    }
}
