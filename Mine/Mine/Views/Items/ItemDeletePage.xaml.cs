using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mine.Models;
using Mine.ViewModels;

namespace Mine.Views
{

    public partial class ItemDeletePage : ContentPage
    {
        ItemReadViewModel viewModel;

        public ItemDeletePage(ItemReadViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDeletePage()
        {

        }

        /// <summary>
        /// Cancel the Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CancelItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Open the Delete page for this item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteItem", viewModel.Item);

            await Navigation.PopModalAsync();
        }
    }
}