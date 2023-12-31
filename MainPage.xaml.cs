using Microsoft.Maui.Controls;

namespace MAUISqliteDemo;

public partial class MainPage : ContentPage
{

    private readonly LocalDbService _dbService;
    private int _editBankID = 0;

    public MainPage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => listView.ItemsSource = await _dbService.GetBankInfo());


    }



    private async void AddButtonClicked(object sender, EventArgs e)
    {
        if (_editBankID == 0)
        {

            await _dbService.Create(new BankInfo
            {
                DepositAmount = Convert.ToDouble(DepositAmount.Text),
                CardNumber = CardNumber.Text,
                CardName = CardName.Text,
                // ExpDate = ExpDate.Text,
                // CVV = Convert.ToInt32(CVV.Text),
                // BillingAdd = BillingAdd.Text,



            });
        }
        else
        {
            await _dbService.Update(new BankInfo
            {
                Id = _editBankID,
                DepositAmount = Convert.ToDouble(DepositAmount.Text),
                CardNumber = CardNumber.Text,
                CardName = CardName.Text,
                // ExpDate = ExpDate.Text,
                // CVV = Convert.ToInt32(CVV.Text),
                // BillingAdd = BillingAdd.Text,
            });

            _editBankID = 0;

            DepositAmount.Text = string.Empty;
            CardNumber.Text = string.Empty;
            CardName.Text = string.Empty;
            // ExpDate.Text = string.Empty;
            // CVV.Text = string.Empty;
            // BillingAdd.Text = string.Empty;


        }

        listView.ItemsSource = await _dbService.GetBankInfo();

    }

    private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var bankInfo = (BankInfo)e.Item;
        var action = await DisplayActionSheet("Options", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                _editBankID = bankInfo.Id;
                DepositAmount.Text = bankInfo.DepositAmount.ToString();
                CardNumber.Text = bankInfo.CardNumber;
                CardName.Text = bankInfo.CardName;
                // ExpDate.Text = bankInfo.ExpDate;
                // CVV.Text = bankInfo.CVV.ToString();
                // BillingAdd.Text = bankInfo.BillingAdd;
                break;
            case "Delete":
                await _dbService.Delete(bankInfo);
                listView.ItemsSource = await _dbService.GetBankInfo();
                break;
        }
    }


}