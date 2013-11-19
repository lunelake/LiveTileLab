using System.Windows;
using Microsoft.Phone.Scheduler;
using System;
using Microsoft.Phone.Shell;
using System.Linq;

namespace LiveTileScheduledTaskAgent
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        private static volatile bool _classInitialized;

        /// <remarks>
        /// ScheduledAgent 생성자는 UnhandledException 처리기를 초기화합니다.
        /// </remarks>
        public ScheduledAgent()
        {
            if (!_classInitialized)
            {
                _classInitialized = true;
                // 관리되는 예외 처리기로 등록합니다.
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Application.Current.UnhandledException += ScheduledAgent_UnhandledException;
                });
            }
        }

        /// 처리되지 않은 예외에 대해 실행할 코드입니다.
        private void ScheduledAgent_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // 처리되지 않은 예외가 발생했습니다. 중단하고 디버거를 실행합니다.
                System.Diagnostics.Debugger.Break();
            }
        }

        /// <summary>
        /// 예약된 작업을 실행하는 에이전트입니다.
        /// </summary>
        /// <param name="task">
        /// 호출한 작업입니다.
        /// </param>
        /// <remarks>
        /// 이 메서드는 정기적 작업 또는 리소스를 많이 사용하는 작업이 호출될 때 호출됩니다.
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            //TODO: 백그라운드에서 작업을 수행하는 코드를 추가합니다.
            // some random number
            Random random = new Random();
            // get application tile

            ShellTile Tile = ShellTile.ActiveTiles.First();//Primary Tile
            if (null != Tile)
            {
                CycleTileData CycleTile = new CycleTileData();
                CycleTile.Title = "백그라운드 작동중";
                CycleTile.Count = random.Next(99);

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
            }
#if DEBUG_AGENT
            ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(30));
            System.Diagnostics.Debug.WriteLine("Periodic task is started again: " + task.Name);
#endif

            NotifyComplete();
        }
    }
}
