﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedUIExtensionsAndHelpers.AdditionalControls.Html;
using CodedUIExtensionsAndHelpers.Fluent;
using CodedUIExtensionsAndHelpers.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace HerokuTest
{
    public class VeryFirstCheckBoxesOnTheInternetPageModel : HtmlPageModelBase<HtmlDiv>
    {
        public VeryFirstCheckBoxesOnTheInternetPageModel(BrowserWindow bw) : base(bw)
        {
        }

        protected override HtmlDiv Me
        {
            get { return base.DocumentWindow.Find<HtmlDiv>("content"); }
        }

        #region Properties

        protected IEnumerable<HtmlCheckBox> CheckBoxes
        {
            get { return Me.FindAll<HtmlCheckBox>(); }
        }

        public IEnumerable<CheckboxChildModel> CheckboxModels
        {
            get { return this.CheckBoxes.Select(x => new CheckboxChildModel(this.parent, x)); }
        }

        protected HtmlHeading3 PageHeading
        {
            get { return Me.Find<HtmlHeading3>(); }
        }

        public string HeadingOfPage
        {
            get { return PageHeading.InnerText; }
        }

        #endregion

        #region Behaviours

        public VeryFirstCheckBoxesOnTheInternetPageModel CheckFirstCheckBox()
        {
            if (!this.CheckBoxes.First().Checked)
            {
                this.CheckBoxes.First().Checked = true;
            }
            return new VeryFirstCheckBoxesOnTheInternetPageModel(parent);
        }

        public Boolean IsFirstCheckBoxChecked()
        {
            return this.CheckBoxes.First().Checked;
        }

        #endregion
    }

    public class CheckboxChildModel : HtmlChildPageModelBase<HtmlCheckBox>
    {
        public CheckboxChildModel(BrowserWindow bw, HtmlCheckBox box) : base(bw, box)
        {

        }

        public bool IsChecked
        {
            get { return this.Me.Checked; }
        }

        public CheckboxChildModel SetChecked(bool checkedTrue)
        {

            this.Me.Checked = checkedTrue;
            return this;
        }
    }
}
