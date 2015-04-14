using CodedUIExtensionsAndHelpers.AdditionalControls.Html;
using CodedUIExtensionsAndHelpers.PageModeling;
using CodedUIExtensionsAndHelpers.Fluent;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace HerokuTest
{
    public class TheStartOfTheInternetModel : HtmlPageModelBase<HtmlDiv>
    {
        public TheStartOfTheInternetModel(BrowserWindow bw) : base(bw)
        {
        }

        protected override HtmlDiv Me
        {
            get { return base.DocumentWindow.Find<HtmlDiv>("content"); }
        }

        #region Properties

        protected HtmlHyperlink CheckBoxesPageLink
        {
            get
            {
                return this.Me.Find<HtmlHyperlink>(HtmlControl.PropertyNames.InnerText, "Checkboxes",
                    PropertyExpressionOperator.Contains);
            }
        }

        protected HtmlHeading1 PageHeading
        {
            get { return Me.Find<HtmlHeading1>(); }
        }

        public string HeadingOfPage()
        {
            return PageHeading.InnerText;
        }

        #endregion

        #region Behaviours

        public VeryFirstCheckBoxesOnTheInternetPageModel ClickOnCheckBoxesLink()
        {
            Mouse.Click(this.CheckBoxesPageLink);
            return new VeryFirstCheckBoxesOnTheInternetPageModel(this.parent);
        }

        #endregion
    }
}