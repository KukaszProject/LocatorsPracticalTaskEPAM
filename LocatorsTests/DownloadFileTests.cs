﻿using Core.Utilities;
using Business.Pages;
using Tests.Base;

namespace Tests.TAF
{
    public class DownloadFileTests : TestBase
    {
        [TestCase("EPAM_Corporate_Overview*.pdf")]
        public void DownloadFileTest(string fileName)
        {
            var home = new HomePage(Driver);
            var fileHelper = new FileHelper();

            home.AcceptCookies()
                .GoToAbout()
                .DownloadButtonClicked();

            Assert.That(fileHelper
                .WaitForFileDownload(Path.Combine(Directory.GetCurrentDirectory(),
                "Downloads"), fileName, 10), "File was not downloaded successfully.", true);
        }
    }
}
