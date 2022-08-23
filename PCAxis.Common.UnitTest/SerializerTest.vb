Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports PCAxis.Paxiom



Namespace PCAxis.Common.UnitTest
    <TestClass>
    Public Class SerializerTest
        <TestMethod>
        Sub NoExceptiongFromCsv2WhenNoContentVariable()
            Dim builder As PXFileBuilder = New PXFileBuilder()

            'builder.SetPath("C:\github.com\statisticssweden\nugets\PCAxis.Common\PCAxis.Common.UnitTest\PxFiles\officialstatistics.px")
            Dim path As String = System.IO.Path.Combine(Environment.CurrentDirectory, "..\..\..\PxFiles\PR0101B3.px")
            builder.SetPath(path)

            builder.BuildForSelection()
            Dim selections As Selection() = Selection.SelectAll(builder.Model.Meta)
            builder.BuildForPresentation(selections)
            Dim model As PXModel = builder.Model

            Dim serializer As IPXModelStreamSerializer = New Csv2FileSerializer()

            Dim excepted = "This is a don't die test, so..."

            Dim actual As String
            Using ms As New System.IO.MemoryStream
                serializer.Serialize(model, ms)
                ms.Position = 0

                Dim sr As New IO.StreamReader(ms)
                actual = sr.ReadToEnd()
                Console.WriteLine(actual)
            End Using



            'Assert  :-)
            actual = excepted

            Assert.AreEqual(actual, excepted)

        End Sub
    End Class

End Namespace

