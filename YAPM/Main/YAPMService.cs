using System.ServiceProcess;
using System.Threading;

namespace YAPMLauncherService
{
    partial class InteractiveProcess : ServiceBase
    {
        public InteractiveProcess()
        {
            InitializeComponent();
        }

        protected new override void OnStart(string[] args)
        {
            ThreadPool.QueueUserWorkItem(LaunchService);
        }

        public void LaunchService(object context)
        {

            // Parse port text file from resources
            cNetwork.ParsePortTextFile();

            // Enable some privileges
            cEnvironment.RequestPrivilege(cEnvironment.PrivilegeToRequest.DebugPrivilege);
            cEnvironment.RequestPrivilege(cEnvironment.PrivilegeToRequest.ShutdownPrivilege);

            // Instanciate 'forms'
            Program._frmServer = new frmServer();
            Program._frmServer.Show();
        }
    }
}
