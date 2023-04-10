using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameScreenMenu _gameScreenMenu;

    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemSO;
    public GameObject[] shopPanelsGo;
    public ShopTemplate[] shopPanels;
    public Button returnButton;
    public Button[] myPurchaseBtns;
    public Button menu;
    public Player player;


    [SerializeField] private Button _buyDesertButton;
    [SerializeField] private Button _buyWinterButton;
    [SerializeField] private Button _buyBigManButton;
    [SerializeField] private Button _buyNinjaButton;
    [SerializeField] private Button[] _buysButton;

    private int _desertAcsess;
    private int _winterAcsess;
    private int _bigManAcsess;
    private int _ninjaAcsess;

    private CanvasGroup _shopCanvas;


    private void Awake()
    {
        _desertAcsess = PlayerPrefs.GetInt("desertLevel");
        _winterAcsess = PlayerPrefs.GetInt("winterLevel");
        _bigManAcsess = PlayerPrefs.GetInt("bigMan");
        _ninjaAcsess = PlayerPrefs.GetInt("ninja");
    }

    private void OnEnable()
    {
        returnButton.onClick.AddListener(OnReturnButtonClick);
        menu.onClick.AddListener(ReturnToMenu);
        _buyDesertButton.onClick.AddListener(BuyDesertLevel);
        _buyWinterButton.onClick.AddListener(BuyWinterLevel);
        _buyBigManButton.onClick.AddListener(OnBuyBigMan);
        _buyNinjaButton.onClick.AddListener(OnBuyNinja);
    }

    private void OnDisable()
    {
        returnButton.onClick.RemoveListener(OnReturnButtonClick);
        menu.onClick.RemoveListener(ReturnToMenu);
        _buyDesertButton.onClick.RemoveListener(BuyDesertLevel);
        _buyWinterButton.onClick.RemoveListener(BuyWinterLevel);
        _buyNinjaButton.onClick.RemoveListener(OnBuyNinja);
        _buyBigManButton.onClick.RemoveListener(OnBuyBigMan);
    }

    private void Start()
    {
        AddCoins();
        int totalCoins = PlayerPrefs.GetInt("coin");
        coins = PlayerPrefs.GetInt("coins") + totalCoins;
        PlayerPrefs.SetInt("coins", coins);
        _shopCanvas = GetComponent<CanvasGroup>();
        _shopCanvas.alpha = 0;
        _shopCanvas.blocksRaycasts = false;
        coinUI.text = coins.ToString();

        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanelsGo[i].SetActive(true);
        }

        if (_desertAcsess != 0)
        {
            myPurchaseBtns[1].enabled = false;
            LevelBuiyng(_buyDesertButton);
        }
        if (_winterAcsess != 0)
        {
            LevelBuiyng(_buyWinterButton);
            myPurchaseBtns[0].enabled = false;
        }
        if (_bigManAcsess != 0)
        {
            LevelBuiyng(_buyBigManButton);
            myPurchaseBtns[3].enabled = false;
        }
        if (_ninjaAcsess != 0)
        {
            LevelBuiyng(_buyNinjaButton);
            myPurchaseBtns[4].enabled = false;
        }
        LoadPanels();
        CheckPurchaseable();
    }

    private void Update()
    {
        //AddCoins();
    }

    public void AddCoins()
    {
        coinUI.text = coins.ToString();
        CheckPurchaseable();
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanels[i].titleText.text = shopItemSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemSO[i].description;
            shopPanels[i].costTxt.text = shopItemSO[i].baseCost.ToString();
            shopPanels[i]._imageItem.sprite = shopItemSO[i].sprite;
        }
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (coins >= shopItemSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
    }

    //public void PurchaseItem(int BtnNo)
    //{
    //    if (coins >= shopItemSO[BtnNo].baseCost)
    //    {
    //        coins = coins - shopItemSO[BtnNo].baseCost;
    //        PlayerPrefs.SetInt("coins", coins);
    //        coinUI.text = coins.ToString();
    //        CheckPurchaseable();
    //        myPurchaseBtns[BtnNo].enabled = false;
    //        myPurchaseBtns[BtnNo].GetComponentInChildren<TMP_Text>().text = "Куплено";
    //        myPurchaseBtns[BtnNo].image.color = Color.blue;
    //    }
    //}

    private void OnReturnButtonClick()
    {
        _shopCanvas.alpha = 0;
        Time.timeScale = 1;
        _shopCanvas.blocksRaycasts = false;
    }

    public void OpenShopScreen()
    {
        _shopCanvas.blocksRaycasts = true;
        _shopCanvas.alpha = 1;
        CheckPurchaseable();
    }

    private void ReturnToMenu()
    {
        _shopCanvas.alpha = 0;
        Time.timeScale = 1;
        _shopCanvas.blocksRaycasts = false;
        _gameScreenMenu.OpenScreen();
    }

    //private void BuyDesertLevel(int number)
    //{
    //    if (coins >= shopItemSO[number].baseCost)
    //    {
    //        coins = coins - shopItemSO[number].baseCost;
    //        PlayerPrefs.SetInt("coins", coins);
    //        coinUI.text = coins.ToString();
    //        _buysButton[number].image.color = Color.blue;
    //    }
    //}

    private void BuyWinterLevel()
    {
        if (coins >= shopItemSO[0].baseCost)
        {
            coins = coins - shopItemSO[0].baseCost;
            PlayerPrefs.SetInt("coins", coins);
            coinUI.text = coins.ToString();
            //_buyWinterButton.GetComponentInChildren<TMP_Text>().text = "Куплено";
            //_buyWinterButton.interactable = false;
            //_buyWinterButton.image.color = Color.blue;
            ChangeInteractableAndColor(_buyWinterButton);
            PlayerPrefs.SetInt("winterLevel", 1);
        }
    }

    private void BuyDesertLevel()
    {
        if (coins >= shopItemSO[1].baseCost)
        {
            coins = coins - shopItemSO[1].baseCost;
            PlayerPrefs.SetInt("coins", coins);
            coinUI.text = coins.ToString();
            //_buyDesertButton.GetComponentInChildren<TMP_Text>().text = "Куплено";
            //_buyDesertButton.interactable = false;
            //_buyDesertButton.image.color = Color.blue;
            ChangeInteractableAndColor(_buyDesertButton);
            PlayerPrefs.SetInt("desertLevel", 1);
        }
    }

    private void OnBuyBigMan()
    {
        if (coins >= shopItemSO[3].baseCost)
        {
            coins = coins - shopItemSO[3].baseCost;
            PlayerPrefs.SetInt("coins", coins);
            coinUI.text = coins.ToString();
            //_buyBigManButton.GetComponentInChildren<TMP_Text>().text = "Куплено";
            //_buyBigManButton.interactable = false;
            //_buyBigManButton.image.color = Color.blue;
            ChangeInteractableAndColor(_buyBigManButton);
            PlayerPrefs.SetInt("bigMan", 1);
        }
    }

    private void OnBuyNinja()
    {
        if (coins >= shopItemSO[4].baseCost)
        {
            coins = coins - shopItemSO[4].baseCost;
            PlayerPrefs.SetInt("coins", coins);
            coinUI.text = coins.ToString();
            //_buyNinjaButton.GetComponentInChildren<TMP_Text>().text = "Куплено";
            //_buyNinjaButton.interactable = false;
            //_buyNinjaButton.image.color = Color.blue;
            ChangeInteractableAndColor(_buyNinjaButton);
            PlayerPrefs.SetInt("ninja", 1);
        }
    }

    private void LevelBuiyng(Button button)
    {
        button.GetComponentInChildren<TMP_Text>().text = "Куплено";
        button.interactable = false;
        button.image.color = Color.blue;
    }

    private void ChangeInteractableAndColor(Button button)
    {
        button.GetComponentInChildren<TMP_Text>().text = "Куплено";
        button.interactable = false;
        button.image.color = Color.blue;
    }
}
