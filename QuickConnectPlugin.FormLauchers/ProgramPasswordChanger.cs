﻿using System;
using System.Windows.Forms;
using QuickConnectPlugin.PasswordChanger.Services;
using QuickConnectPlugin.Tests;
using QuickConnectPlugin.Tests.PasswordChanger;

namespace QuickConnectPlugin.FormLauchers {

    static class ProgramPasswordChanger {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var pwDatabase = new MockPasswordDatabase();
            var hostPwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "pass",
                IPAddress = "host",
            };
            hostPwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);
            var pwChangerFactory = new FakePasswordChangerFactory(20000);
            var pwChangerServiceFactory = new PasswordChangerServiceFactory(pwDatabase, pwChangerFactory);

            var formPasswordChange = new FormPasswordChanger(hostPwEntry, pwChangerServiceFactory);
            Application.Run(formPasswordChange);
        }
    }
}
