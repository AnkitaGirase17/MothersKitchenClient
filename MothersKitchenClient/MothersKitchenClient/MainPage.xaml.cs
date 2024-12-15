using MothersKitchenClient.onLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MothersKitchenClient
{
    public partial class MainPage : ContentPage
    {
        private Entry[] otpEntries;
        public MainPage()
        {
            InitializeComponent();
            AppLogo_Image.Source = ImageSource.FromResource("MothersKitchenClient.img.mk.png");
            otpEntries = new Entry[] { FN, SN, TN, FTN };
        }

        private void otpEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry =(Entry)sender;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                int index = System.Array.IndexOf(otpEntries, entry);
                if (index < otpEntries.Length - 1)
                {
                    otpEntries[index +1].Focus();
                }
                else
                {
                    VerifyOTP_Button.IsVisible =true;
                }
                

            }
            else
            {
                int index = System.Array.IndexOf(otpEntries,entry);
                if (index > 0)
                {
                    otpEntries[index -1].Focus();
                }
            }
        }
        private void Login_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Mobile_Entry.Text.Length == 10)
                {
                    MobileStack.IsVisible = false;
                    OTPStack.IsVisible = true;
                }
                else
                {
                    DisplayAlert("Alert", "Invalid Mobile Number", "Ok");
                }
            }
            catch (Exception EE) { }
        }

        private void VerifyOTP_Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FN.Text) != true && string.IsNullOrEmpty(SN.Text) != true && string.IsNullOrEmpty(TN.Text) != true && string.IsNullOrEmpty(FTN.Text) != true)
            {
                var OTP = otpEntries[0].Text + otpEntries[1].Text + otpEntries[2].Text + otpEntries[3].Text;
                if (OTP == "1234")
                {
                    Application.Current.Properties["UID"] = Mobile_Entry.Text;
                    
                    Navigation.PushAsync(new HomePage());
                }
                else
                {
                    DisplayAlert("Alert", "Invalid OTP", "Ok");
                }
            }
            else
            {
                DisplayAlert("Alert", "OTP Cannot Be Null", "Ok");
            }
        }

        private void CancelOTP_Button_Clicked(object sender, EventArgs e)
        {
            MobileStack.IsVisible = true;
            OTPStack.IsVisible = false;
        }

        
    }
}
