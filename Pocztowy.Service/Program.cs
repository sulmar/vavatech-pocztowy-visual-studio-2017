using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace Pocztowy.Service
{
    // Install-Package TopShelf

    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(
                s =>
                {
                    s.SetServiceName("MyService");
                    s.SetDisplayName("My Service");
                    s.SetDescription("My description");
                    s.StartAutomatically();
                    s.Service<MyService>(service =>
                    {
                        service.ConstructUsing(p => new MyService());
                        service.WhenStarted(p => p.Start());
                        service.WhenStopped(p => p.Stop());
                    });
                });

            MyService myService = new MyService();
            myService.Start();
        }
    }


    public class MyService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        volatile private bool isStarted;

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken token;

        public MyService()
        {
            token = cancellationTokenSource.Token;

        }

        public void Start()
        {
           
            isStarted = true;
            Logger.Debug("Started.");

            Task.Run(() => DoWork(token));
        }

        private void DoWork(CancellationToken cancellationToken = default(CancellationToken))
        {
            while (isStarted)
            {
                Logger.Debug("Tick!");

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        public void Stop()
        {
            isStarted = false;

            Logger.Debug("Stopped.");
        }
    }
}
