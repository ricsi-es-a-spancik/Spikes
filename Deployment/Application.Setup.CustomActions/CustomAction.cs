using Microsoft.Deployment.WindowsInstaller;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Application.Setup.CustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            session.Log("Begin CustomAction1");
            MessageBox.Show("Executing CustomAction1 only when NOT Installed.");
            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult ShowCustomMessage(Session session)
        {
            session.Log("Executing ShowCustomMessage");

            var msg = session["CUSTOMMESSAGE"];
            MessageBox.Show(msg, "Your custom message was:");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult SelectATxtFile(Session session)
        {
            try
            {
                session.Log("Begin SelectATxtFile Custom Action");

                var task = new Thread(() => GetFile(session));
                task.SetApartmentState(ApartmentState.STA);
                task.Start();
                task.Join();

                session.Log("End SelectATxtFile Custom Action");
            }
            catch (Exception ex)
            {
                session.Log("Exception occurred as Message: {0}\r\n StackTrace: {1}", ex.Message, ex.StackTrace);
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }

        private static void GetFile(Session session)
        {
            var fileDialog = new OpenFileDialog { Filter = "Text File (*.txt)|*.txt" };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                session["SELECTEDFILE"] = fileDialog.FileName;
            }
        }

        [CustomAction]
        public static ActionResult ValidateSelectedDirectryAndSelectedFile(Session session)
        {
            var directory = session["SELECTEDDIRECTORY"];
            var file = session["SELECTEDFILE"];

            if (SelectedDirectoryIsValie(directory) && SelectedFileIsValid(file))
                session["SELECTEDPATHSAREVALID"] = "True";
            else
                session["SELECTEDPATHSAREVALID"] = "False";

            return ActionResult.Success;
        }

        private static bool SelectedDirectoryIsValie(string directory)
        {
            try
            {
                if (directory == null)
                    return false;

                var di = new DirectoryInfo(directory);

                return di.Exists && !di.Attributes.HasFlag(System.IO.FileAttributes.ReadOnly);
            }
            catch
            {
                return false;
            }
        }

        private static bool SelectedFileIsValid(string file)
        {
            try
            {
                if (file == null)
                    return false;

                var fi = new FileInfo(file);

                return fi.Exists && !fi.Attributes.HasFlag(System.IO.FileAttributes.ReadOnly) && fi.Extension == ".txt";
            }
            catch
            {
                return false;
            }
        }
    }
}
