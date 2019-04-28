Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows

Namespace CustomizePropertyGridCategories
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            AddHandler XtraReport.FilterComponentProperties, AddressOf XtraReport_FilterComponentProperties
            designer.OpenDocument(New XtraReport())
        End Sub

        Private Sub XtraReport_FilterComponentProperties(ByVal sender As Object, ByVal e As FilterComponentPropertiesEventArgs)
            Dim paperKindDescriptor = TryCast(e.Properties("PaperKind"), PropertyDescriptor)
            If paperKindDescriptor IsNot Nothing Then
                Dim attributes = New List(Of Attribute)(paperKindDescriptor.Attributes.Cast(Of Attribute)().Where(Function(att) Not (TypeOf att Is PropertyGridTabAttribute)))
                attributes.Add(New PropertyGridTabAttribute("My tab"))
                e.Properties("PaperKind") = TypeDescriptor.CreateProperty(paperKindDescriptor.ComponentType, paperKindDescriptor, attributes.ToArray())
            End If
        End Sub
    End Class
End Namespace
