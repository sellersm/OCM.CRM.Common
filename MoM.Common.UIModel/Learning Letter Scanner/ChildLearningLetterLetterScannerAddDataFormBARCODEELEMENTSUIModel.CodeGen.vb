﻿Option Strict On
Option Explicit On
Option Infer On

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by BBUIModelLibrary
'     Version:  2.93.2034.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
''' <summary>
''' Represents the UI model for the 'BarCodeAddDataFormBARCODEELEMENTS' data form
''' </summary>
Partial Public Class [ChildLearningLetterLetterScannerAddDataFormBARCODEELEMENTSUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.UIModel

#Region "Extensibility methods"

	Partial Private Sub OnCreated()
	End Sub

#End Region

	Private WithEvents _barcode As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _scanstatus As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _sponsorlookupid As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _childlookupid As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _childProjectLookupId As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _resultsok As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
	Private WithEvents _scanmessage As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _exception As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	'Add a column for letter stack:
	Private WithEvents _letterstack As Global.Blackbaud.AppFx.UIModeling.Core.StringField


	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public Sub New()
		MyBase.New()

		_barcode = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_scanstatus = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_sponsorlookupid = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_childlookupid = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_childProjectLookupId = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_resultsok = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		_scanmessage = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_exception = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_letterstack = New Global.Blackbaud.AppFx.UIModeling.Core.StringField

		'
		'_letterstack
		'
		_letterstack.Caption = "Letter stack"
		_letterstack.Name = "LETTERSTACK"
		_letterstack.MaxLength = 25
		Me.Fields.Add(_letterstack)

		'
		'_resultsok
		'
		_resultsok.Name = "RESULTSOK"
		_resultsok.Caption = "OK"
		_resultsok.Visible = False
		Me.Fields.Add(_resultsok)

		'
		'_scanstatus
		'
		_scanstatus.Name = "SCANSTATUS"
		_scanstatus.Caption = "Scan status"
		_scanstatus.Multiline = True
		_scanstatus.MaxLength = 1105
		_scanstatus.AllowZoom = True
		_scanstatus.Multiline = True
		Me.Fields.Add(_scanstatus)

		'
		'_scanmessage
		'
		_scanmessage.Name = "SCANMESSAGE"
		_scanmessage.Caption = "Message"
		_scanmessage.MaxLength = 1200
		_scanmessage.AllowZoom = True
		_scanmessage.Multiline = True
		Me.Fields.Add(_scanmessage)

		'
		'_exception
		'
		_exception.Name = "EXCEPTION"
		_exception.Caption = "Exception"
		_exception.MaxLength = 2000
		_exception.AllowZoom = True
		_exception.Multiline = True
		Me.Fields.Add(_exception)
		'
		'_sponsorlookupid
		'
		_sponsorlookupid.Name = "SPONSORLOOKUPID"
		_sponsorlookupid.Caption = "Sponsor ID"
		_sponsorlookupid.MaxLength = 100
		Me.Fields.Add(_sponsorlookupid)
		'
		'_childlookupid
		'
		_childlookupid.Name = "CHILDLOOKUPID"
		_childlookupid.Caption = "Child ID"
		_childlookupid.MaxLength = 100
		Me.Fields.Add(_childlookupid)
		'
		'_lettername
		'
		_childProjectLookupId.Name = "CHILDPROJECTLOOKUPID"
		_childProjectLookupId.Caption = "Project ID"
		_childProjectLookupId.MaxLength = 100
		Me.Fields.Add(_childProjectLookupId)
		'
		'_barcode
		'
		' 11/7/12: Memphis turned this off, not sure we want/need it?
		_barcode.Name = "BARCODE"
		_barcode.Caption = "Bar code"
		_barcode.Visible = False
		_barcode.MaxLength = 20
		Me.Fields.Add(_barcode)

		OnCreated()

	End Sub
	''' <summary>
	''' Letter stack
	''' </summary>
	<System.ComponentModel.Description("Letter stack")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [LETTERSTACK]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _letterstack
		End Get
	End Property

	''' <summary>
	''' OK
	''' </summary>
	<System.ComponentModel.Description("OK")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [RESULTSOK]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		Get
			Return _resultsok
		End Get
	End Property


	''' <summary>
	''' Bar code
	''' </summary>
	<System.ComponentModel.Description("Bar code")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [BARCODE]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _barcode
		End Get
	End Property

	''' <summary>
	''' Scan status
	''' </summary>
	<System.ComponentModel.Description("Scan status")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [SCANSTATUS]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _scanstatus
		End Get
	End Property
	''' <summary>
	''' Exception
	''' </summary>
	<System.ComponentModel.Description("Exception")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [EXCEPTION]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _exception
		End Get
	End Property


	''' <summary>
	''' Message
	''' </summary>
	<System.ComponentModel.Description("Message")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [SCANMESSAGE]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _scanmessage
		End Get
	End Property


	''' <summary>
	''' Sponsor ID
	''' </summary>
	<System.ComponentModel.Description("Sponsor ID")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [SPONSORLOOKUPID]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _sponsorlookupid
		End Get
	End Property

	''' <summary>
	''' Child ID
	''' </summary>
	<System.ComponentModel.Description("Child ID")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [CHILDLOOKUPID]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _childlookupid
		End Get
	End Property

	''' <summary>
	''' Project ID
	''' </summary>
	<System.ComponentModel.Description("Project ID")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [CHILDPROJECTLOOKUPID]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _childProjectLookupId
		End Get
	End Property

End Class
