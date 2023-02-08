using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeBomjour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const float TimeUnit = 1.05556f;

        private static float Rand
        {
            get
            {
                Random r = new();
                return (float)Math.Round(r.NextDouble(), 2);
            }
        }

        public MainWindow()
        {
            Data.LoadData();
            InitializeComponent();
            UpdateText();
            PB_Gray.Width = Data.Time;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Data.SaveData();
        }

        public static void GiveMoney(float amount, float mult = 1) => Data.Money += amount * mult;
        public static void TakeMoney(float amount, float mult = 1) => Data.Money -= amount * mult;
        public static void GiveXP(float amount, float mult = 1) => Data.XP += amount * mult;
        public static string GetMoney() => Data.Money.ToString("N2");
        public static string GetXP() => Data.XP.ToString("N2");
        public static string GetDays() => Data.Days.ToString();

        private void UpdateText()
        {
            Text_Money.Text = GetMoney();
            Text_XP.Text = GetXP();
            Text_Days.Text = GetDays();
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            Data.ResetData();
            UpdateText();
            PB_Gray.Width = Data.Time;
        }

        private void Button_Work_Click(object sender, RoutedEventArgs e)
        {
            GiveMoney(Rand, Data.MoneyMult);
            GiveXP(Rand, Data.XPMult);
            AddTime(Data.TimeMult);
            UpdateText();
        }

        private void AddTime(float mult = 1)
        {
            float time = TimeUnit * mult;
            if (PB_Gray.Width - time <= 0)
            {
                PB_Gray.Width = 380;
                Data.Days++;
            }
            PB_Gray.Width -= time;
            Data.Time = PB_Gray.Width;
        }

        private void ScrollToBottom()
        {
            if (LV_Events.Items.Count >= 20) LV_Events.Items.RemoveAt(0);
            if (VisualTreeHelper.GetChildrenCount(LV_Events) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(LV_Events, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }
        }

        private void Button_Explore_Click(object sender, RoutedEventArgs e)
        {
            LV_Events.Items.Add("Погулял");
            ScrollToBottom();
        }

        private void Button_Sleep_Click(object sender, RoutedEventArgs e)
        {
            LV_Events.Items.Add("Поспал");
            ScrollToBottom();
        }

        private void Button_Shop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
