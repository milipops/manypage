using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Threading;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using TestManyPage.Models;

namespace TestManyPage.ViewModels
{
    internal class Page1ViewModel : ViewModelBase
    {
        public void ToPageMain()
        {
            MainWindowViewModel.Instance.Uc = new Page2();
        }

        private string _currentLogin = string.Empty;
        private string _currentPassword = string.Empty;
        public string GetLogin
        {
            get => _currentLogin;
            set => this.RaiseAndSetIfChanged(ref _currentLogin, value);
        }
        public string GetPassword
        {
            get => _currentPassword;
            set => this.RaiseAndSetIfChanged(ref _currentPassword, value);
        }    

        private bool _isAvalibleLogin = true;
        public async void Sucsees()
        {
            Registr.Login = GetLogin;
            Registr.Password = GetPassword;

            if (GetLogin == UserDataTrue.CorrectLogin && GetPassword == UserDataTrue.CorrectPassword)
            {
                await SucseesRegister();
            }
            else
            {
                IsVisibleLogin = false;
                await ShowError();
            }
        }
        public async Task SucseesRegister()
        {
            var box = MessageBoxManager
                .GetMessageBoxStandard("Окно", "Вход", ButtonEnum.Ok, Icon.Success);
            var result = await box.ShowAsync();
            switch (result)
            {
                case ButtonResult.Ok:
                    MainWindowViewModel.Instance.Uc = new Page2();
                    break;
            }
        }
        public string captchaGenerated;
        public string capchaInput;
        public int CapthCountSumm;
        public async Task ShowError()
        {
            CrateCaptcha();
        }

        Canvas canvas1;
        public Canvas Capt
        {
            get => canvas1;
            set => this.RaiseAndSetIfChanged(ref canvas1, value);
        }
        private bool _isCaptchaVisible = false;

        int GenerateSymolsIntOrChar;

        public void CrateCaptcha()
        {
            Random rnd = new Random();
            int countsymbols = rnd.Next(7, 11);

            SolidColorBrush color = new SolidColorBrush(Color.FromRgb(
                Convert.ToByte(rnd.Next(256)), (byte)rnd.Next(256), (byte)rnd.Next(256)));

            captchaGenerated = "";
            for (int i = 0; i < countsymbols; i++)
            {
                int type = rnd.Next(0, 2); 
                if (type == 0)
                    captchaGenerated += (char)rnd.Next('A', 'Z' + 1);            
                else
                    captchaGenerated += rnd.Next(10).ToString();
            }
            CaptchaDebugText = captchaGenerated;

            Canvas canvas = new Canvas()
            {
                Width = 400,
                Height = 300,
                Background = Brushes.LightGray,

            };

            for (int i = 0; i < countsymbols; i++)
            {
                int rndStyle = rnd.Next(0, 4);

                FontWeight weight = FontWeight.Normal;
                FontStyle style = FontStyle.Normal;

                if (rndStyle == 1)
                {
                    weight = FontWeight.Bold; 
                }
                else if (rndStyle == 2)
                {
                    style = FontStyle.Italic;
                }
                else if (rndStyle == 3)
                {
                    weight = FontWeight.Bold; 
                    style = FontStyle.Italic;
                }

                double startX = 70;
                double stepX = (canvas.Width - 110) / countsymbols;

                TextBlock textBlock = new TextBlock()
                {
                    Text = captchaGenerated[i].ToString(),
                    FontSize = 25,
                    Foreground = Brushes.Black,
                    FontWeight = weight,
                    FontStyle = style
                };
                double x = startX + i * stepX;
                double y = rnd.Next(30, 70);

                Canvas.SetLeft(textBlock, x);
                Canvas.SetTop(textBlock, y);

                canvas.Children.Add(textBlock);
            }


            for (int i = 0; i < 15; i++)
            {
                Line line = new Line()
                {
                    StartPoint = new Point(rnd.Next(401), rnd.Next(301)),
                    EndPoint = new Point(rnd.Next(401), rnd.Next(301)),
                    Stroke = color,
                    StrokeThickness = 5,
                };
                canvas.Children.Add(line);
            }
            Capt = canvas;
            isCaptchaVisible = true;
        }
        public bool isCaptchaVisible
        {
            get => _isCaptchaVisible;
            set => this.RaiseAndSetIfChanged(ref _isCaptchaVisible, value);
        }
        public bool IsVisibleLogin
        {
            get => _isAvalibleLogin;
            set => this.RaiseAndSetIfChanged(ref _isAvalibleLogin, value);
        }
        public string GetCapcha
        {
            get => capchaInput;
            set => this.RaiseAndSetIfChanged(ref capchaInput, value);
        }
        public async void CheckCapt()
        {
            if (capchaInput == captchaGenerated)
            {
                await SucseesRegister();
                IsVisibleLogin = true;
                isCaptchaVisible = false;
            }
            else
            {
                CapthCountSumm += 1;
                var box = MessageBoxManager
                .GetMessageBoxStandard("Ошиибка", "Неверная капча", ButtonEnum.Ok, Icon.Error);
                await box.ShowAsync();

                CrateCaptcha();
                
                capchaInput = "";
                GetCapcha = "";

                if (CapthCountSumm > 1)
                {
                    StartTimer();
                    IsVisibleLogin = false;
                    isCaptchaVisible = false;
                    CapthCountSumm = 0;

                }
            }
        }


        DispatcherTimer timer = new DispatcherTimer();
        public Page1ViewModel()
        {
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler(DisTimer_Tick);
        }
        private void DisTimer_Tick(object sender, EventArgs e)
        {
            var box = MessageBoxManager
           .GetMessageBoxStandard("Уведомление", "Время вышло, попробуйте заново", ButtonEnum.Ok);

            var result = box.ShowAsync();
            timer.Stop();
            IsVisibleLogin = true;
            isCaptchaVisible = false;
        }
        public void StartTimer()
        {
            timer.Start();
        }

        private string _captchaDebugText;
        public string CaptchaDebugText
        {
            get => _captchaDebugText;
            set => this.RaiseAndSetIfChanged(ref _captchaDebugText, value);
        }


    }
}
