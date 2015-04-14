using System;
using System.ComponentModel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HerokuTest
{
    [CodedUITest]
    public class MostImportantInternetTestsEver
    {
        private readonly Lazy<BrowserWindow> _windowLazy = new Lazy<BrowserWindow>(() =>
        {
            var w = BrowserWindow.Launch("http://the-internet.herokuapp.com/");
            w.Maximized = true;
            return w;
        });

        protected BrowserWindow Window
        {
            get
            {
                return this._windowLazy.Value;
            }
        }

        [TestMethod]
        public void GivenBrowserLoadsWelcomePageSuccessfullyThenWelcomeVerbiageShouldExist()
        {
            var welcomePage = new TheStartOfTheInternetModel(Window)
                .HeadingOfPage()
                .Should()
                .Contain("Welcome to the Internet");
        }
        [TestMethod]
        public void GivenBrowserLoadsWelcomePageSuccessfullyThenClickingCheckBoxesLinkShouldLoadPageWhichHasCheckboxesVerbiage()
        {
            var homePageTitle = new TheStartOfTheInternetModel(Window)
                .ClickOnCheckBoxesLink()
                .HeadingOfPage
                .Should()
                .Contain("Checkboxes");
        }
        [TestMethod]
        public void GivenCheckBoxesPageLoadedWhenFirstCheckBoxClickedCheckBoxShouldNotBeChecked()
        {
            var homePageModel = new TheStartOfTheInternetModel(Window);
            homePageModel.
                ClickOnCheckBoxesLink()
                .IsFirstCheckBoxChecked()
                .Should()
                .Be(false);
        }

        [TestMethod]
        public void GivenCheckBoxesPageLoadedWhenFirstCheckBoxClickedCheckBoxShouldBeAbleToBeChecked()
        {
            throw new NotImplementedException();
        }
        
        [TestCleanup]
        public void CleanUp()
        {
            Window.Close();
        }

    }

}
