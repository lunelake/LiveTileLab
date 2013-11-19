using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LiveTileLab.Resources;
using Microsoft.Phone.Scheduler;

namespace LiveTileLab
{
    public partial class MainPage : PhoneApplicationPage
    {
        ShellTileSchedule SampleTileSchedule = new ShellTileSchedule();
        bool TileScheduleRunning = false;
        
        // 생성자
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddFlipLiveTile_Click(object sender, RoutedEventArgs e)//Flip Tile 추가하기 및 타일 업데이트하는 방법
        {
            ShellTile Tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("flip".ToString()));

            if (Tile != null && Tile.NavigationUri.ToString().Contains("flip"))//타일 업데이트
            {
                FlipTileData Fliptile = new FlipTileData();
                Fliptile.Title = "Hello Everybody";
                Fliptile.Count = 10;
                Fliptile.BackTitle = "Update Flip Tile";
                Fliptile.BackContent = "back of tile";
                Fliptile.WideBackContent = " back of the wide tile";

                Fliptile.SmallBackgroundImage = new Uri("Assets/Tiles/BaramLogo159.png", UriKind.Relative);
                Fliptile.BackgroundImage = new Uri("Assets/Tiles/BaramLogo336.png", UriKind.Relative);
                Fliptile.WideBackgroundImage = new Uri("Assets/Tiles/BaramLogo691.png", UriKind.Relative);

                Fliptile.BackBackgroundImage = new Uri("Assets/Tiles/A159.png", UriKind.Relative);
                Fliptile.WideBackBackgroundImage = new Uri("Assets/Tiles/A691.png", UriKind.Relative);
                Tile.Update(Fliptile);
                MessageBox.Show("Flip Tile이 업데이트 되었습니다.");
            }
            else//타일 처음으로 생성
            {
                Uri tileUri = new Uri("/MainPage.xaml?tile=flip", UriKind.Relative);
                ShellTileData tileData = this.CreateFlipTileData();
                ShellTile.Create(tileUri, tileData, true);
            }
        }

        private ShellTileData CreateFlipTileData()//메서드를 통해 생성 가능
        {
            return new FlipTileData()
            {
                Title = "Hi Flip Tile",
                BackTitle = "This is Wp8 flip tile",
                BackContent = "Live Tile Demo",
                WideBackContent = "Hello Baram Lab",
                Count = 8,
                SmallBackgroundImage = new Uri("Assets/Tiles/A159.png", UriKind.Relative),
                BackgroundImage = new Uri("Assets/Tiles/A336.png", UriKind.Relative),
                WideBackgroundImage = new Uri("Assets/Tiles/A691.png", UriKind.Relative)
            };
        }
        
        private void AddCycleTile_Click(object sender, RoutedEventArgs e)//Cycle Tile 추가하기
        {
            CycleTileData CycleTile = new CycleTileData();
            CycleTile.Title = "Hello Cycle Icon!";
            CycleTile.Count = 9;

            CycleTile.SmallBackgroundImage = new Uri("Assets/Tiles/A159.png", UriKind.Relative);

            CycleTile.CycleImages = new Uri[]//이미지 배열 생성. 9개까지만 생성 가능
            {
                new Uri("Assets/Tiles/Cycle/001.jpg", UriKind.Relative),
                new Uri("Assets/Tiles/Cycle/002.jpg", UriKind.Relative),
                new Uri("Assets/Tiles/Cycle/003.jpg", UriKind.Relative),
                new Uri("Assets/Tiles/Cycle/004.jpg", UriKind.Relative),
                new Uri("Assets/Tiles/Cycle/005.jpg", UriKind.Relative),
                new Uri("Assets/Tiles/Cycle/006.jpg", UriKind.Relative),
                new Uri("Assets/Tiles/Cycle/007.jpg", UriKind.Relative),
                new Uri("Assets/Tiles/Cycle/008.jpg", UriKind.Relative),
                new Uri("Assets/Tiles/Cycle/009.jpg", UriKind.Relative),
            };

            ShellTile Tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("cycle"));

            if (Tile != null && Tile.NavigationUri.ToString().Contains("cycle"))
            {
                Tile.Delete();
                ShellTile.Create(new Uri("/MainPage.xaml?id=cycle", UriKind.Relative), CycleTile, true);

            }
            else
            {
                ShellTile.Create(new Uri("/MainPage.xaml?id=cycle", UriKind.Relative), CycleTile, true);
            }
        }

        private void AddIconicLiveTile_Click(object sender, RoutedEventArgs e)//Iconic Tile 추가하기
        {
            IconicTileData IconTile = new IconicTileData();
            IconTile.Title = "Hello Iconic Tile";
            IconTile.Count = 7;

            IconTile.IconImage = new Uri("Assets/Tiles/Iconic/202x202.png", UriKind.Relative);
            IconTile.SmallIconImage = new Uri("Assets/Tiles/Iconic/110x110.png", UriKind.Relative);

            IconTile.WideContent1 = "윈도우폰8 라이브 타일";
            IconTile.WideContent2 = "Icon Tile";
            IconTile.WideContent3 = "바람연구소";

            IconTile.BackgroundColor = System.Windows.Media.Colors.Blue;//일반적으론 액센트 컬러를 따름

            ShellTile Tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("Iconic"));

            if (Tile != null && Tile.NavigationUri.ToString().Contains("Iconic"))
            {
                Tile.Delete();
                ShellTile.Create(new Uri("/MainPage.xaml?id=Iconic", UriKind.Relative), IconTile, true);
            }
            else
            {
                ShellTile.Create(new Uri("/MainPage.xaml?id=Iconic", UriKind.Relative), IconTile, true);
            }
        }

        private void ChangeAppBasicTile_Click(object sender, RoutedEventArgs e)//Primary Tile 업데이트
        {
            ShellTile Tile = ShellTile.ActiveTiles.First();//Primary Tile
            if (null != Tile)
            {
                CycleTileData CycleTile = new CycleTileData();
                CycleTile.Title = "Primary Tile Update!";
                CycleTile.Count = 9;

                CycleTile.SmallBackgroundImage = new Uri("Assets/Tiles/A159.png", UriKind.Relative);

                CycleTile.CycleImages = new Uri[]//이미지 배열 생성. 9개까지만 생성 가능
                {
                    new Uri("Assets/Tiles/Cycle/001.jpg", UriKind.Relative),
                    new Uri("Assets/Tiles/Cycle/002.jpg", UriKind.Relative),
                    new Uri("Assets/Tiles/Cycle/003.jpg", UriKind.Relative),
                    new Uri("Assets/Tiles/Cycle/004.jpg", UriKind.Relative),
                    new Uri("Assets/Tiles/Cycle/005.jpg", UriKind.Relative),
                    new Uri("Assets/Tiles/Cycle/006.jpg", UriKind.Relative),
                    new Uri("Assets/Tiles/Cycle/007.jpg", UriKind.Relative),
                    new Uri("Assets/Tiles/Cycle/008.jpg", UriKind.Relative),
                    new Uri("Assets/Tiles/Cycle/009.jpg", UriKind.Relative),
                };

                Tile.Update(CycleTile);
                MessageBox.Show("Primary 타일이 업데이트 되었습니다.");
            }
        }

        private void MakeImage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MakeImage.xaml", UriKind.Relative));
        }

        // 라이브타일을 업데이트 하기 위한 periodic agent 시작 (예약된 작업 시작)
        private PeriodicTask periodicTask;
        private string periodicTaskName = "LiveTilePeriodicAgent";
        private void StartPeriodicAgent()
        {
            // 태스크가 이미 시작되고 있다면 제거
            periodicTask = ScheduledActionService.Find(periodicTaskName) as PeriodicTask;//현재 실행되고 있는 태스크
            if (periodicTask != null)
            {
                try
                {
                    ScheduledActionService.Remove(periodicTaskName);//현재 실행되고 있는 테스크 제거
                }
                catch (Exception)
                {
                }
            }
            // 새로운 태스크 생성
            periodicTask = new PeriodicTask(periodicTaskName);
            // 작업 설명
            periodicTask.Description = "This is LiveTile application update agent.";
            // 작업이 만료되는 시간 설정
            periodicTask.ExpirationTime = DateTime.Now.AddDays(14);
            try
            {
                // add thas to scheduled action service
                ScheduledActionService.Add(periodicTask);
                // 매 30초마다 디버그
//#if(DEBUG_AGENT)
                ScheduledActionService.LaunchForTest(periodicTaskName, TimeSpan.FromSeconds(10));
                System.Diagnostics.Debug.WriteLine("Periodic task is started: " + periodicTaskName);
//#endif

            }
            catch (InvalidOperationException exception)
            {
                if (exception.Message.Contains("BNS Error: The action is disabled"))
                {
                    // load error text from localized strings
                    MessageBox.Show("Background agents for this application have been disabled by the user.");
                }
                if (exception.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added."))
                {
                    // No user action required. The system prompts the user when the hard limit of periodic tasks has been reached.
                }
            }
            catch (SchedulerServiceException)
            {
                // No user action required.
            }
        }

        private void BackGround_Click(object sender, RoutedEventArgs e)
        {
            StartPeriodicAgent();
        }



    }
}