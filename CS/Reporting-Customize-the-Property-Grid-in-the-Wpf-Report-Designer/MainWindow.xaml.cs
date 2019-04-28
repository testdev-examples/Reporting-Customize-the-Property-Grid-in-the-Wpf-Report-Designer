using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace CustomizePropertyGridCategories {
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            XtraReport.FilterComponentProperties += XtraReport_FilterComponentProperties;
            designer.OpenDocument(new XtraReport());
        }

        void XtraReport_FilterComponentProperties(object sender, FilterComponentPropertiesEventArgs e) {
            var paperKindDescriptor = e.Properties["PaperKind"] as PropertyDescriptor;
            if(paperKindDescriptor != null) {
                var attributes = new List<Attribute>(paperKindDescriptor.Attributes.Cast<Attribute>().Where(att => !(att is PropertyGridTabAttribute)));
                attributes.Add(new PropertyGridTabAttribute("My tab"));
                e.Properties["PaperKind"] = TypeDescriptor.CreateProperty(
                    paperKindDescriptor.ComponentType,
                    paperKindDescriptor,
                    attributes.ToArray());
            }
        }
    }
}
