﻿using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Controls
{
    public class SearchInventoryComponentBase : ComponentBase
    {
        protected string inventoryNameToSearch = string.Empty;
        [Parameter]
        public EventCallback<string> OnSearchInventory { get; set; }

        protected async Task OnSearch()
        {
            await OnSearchInventory.InvokeAsync(inventoryNameToSearch);
        }
    }
}
