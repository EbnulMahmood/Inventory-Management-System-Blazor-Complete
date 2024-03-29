﻿using IMS.CoreBusiness.Entities;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Inventories
{
    public class EditInventoryBase : ComponentBase
    {
        [Parameter]
        public int InventoryId { get; set; }
        [Inject]
        public IEditInventoryUseCase EditInventoryUseCase { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IViewInventoryByIdUseCase ViewInventoryByIdUseCase { get; set; }
        protected Inventory inventory;
        private readonly string _inventoriesUrl = "/inventories";

        protected override async Task OnInitializedAsync()
        {
            inventory = await ViewInventoryByIdUseCase.ExecuteAsync(InventoryId);
        }

        protected async Task OnValidSubmit()
        {
            try
            {
                await EditInventoryUseCase.ExecuteAsync(inventory);
            }
            catch (Exception)
            {

                throw;
            }
            NavigateToInventories();
        }

        protected void NavigateToInventories()
        {
            NavigationManager.NavigateTo(_inventoriesUrl);
        }
    }
}
