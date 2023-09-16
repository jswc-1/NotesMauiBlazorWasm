using NotesMauiBlazorWasm.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesMauiBlazorWasm.Common.Services
{
    public class AuthServices
    {
        private readonly IAlertService _alertService;
        private readonly IStorageService _storageService;

        public AuthServices(IAlertService alertService, IStorageService storageService) 
        {
            _alertService = alertService;
            _storageService = storageService;
        }

        public async Task<string?> GetUserName()
        {
            var strName = await _storageService.GetAsync(AppConstants.StorageKeys.Username);

            if (string.IsNullOrWhiteSpace(strName))
            {
                int maxRetry = 3;
                do
                {
                    strName = await _alertService.PromptAsync("Welcome", "Please enter your name");
                }
                while (string.IsNullOrWhiteSpace(strName) && (--maxRetry) > 0);

                if (string.IsNullOrWhiteSpace(strName))
                {
                    await _alertService.AlertAsync("Your name is required to continue with the applicaion", "Error", "OK");
                    return null;
                }

                await _storageService.SaveAsync(AppConstants.StorageKeys.Username, strName);   
            }

            return strName;
        }
    }
}
