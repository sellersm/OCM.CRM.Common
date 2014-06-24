Option Infer On
Option Strict Off

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace WebApiClient

	Namespace DataLists

		'<@ENUMS@>

		''' <summary>
		''' Provides WebApi access to the "Designations with BBNC ID Data List" catalog feature.  Contains Designation information, including the ID used for BBIS payments
		''' </summary>
		<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
		Public NotInheritable Class [DesignationsWithBBNCIDDataList]

			Private Sub New()
				'this is a static class (only shared methods) that should never be instantiated.
			End Sub

			Private Shared ReadOnly _specId As Guid = New Guid("027fc290-ea81-490f-822a-d5f4445a93b5")
			''' <summary>
			''' The DataList ID value for the "Designations with BBNC ID Data List" datalist
			''' </summary>
			Public Shared ReadOnly Property SpecId() As Guid
				Get
					Return _specId
				End Get
			End Property

			Private Shared ReadOnly _rowFactoryDelegate As Blackbaud.AppFx.WebAPI.DataListRowFactoryDelegate(Of [DesignationsWithBBNCIDDataListRow]) = AddressOf CreateListRow

			Private Shared Function CreateListRow(ByVal rowValues As String()) As [DesignationsWithBBNCIDDataListRow]
				Return New [DesignationsWithBBNCIDDataListRow](rowValues)
			End Function

			Public Shared Function CreateRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.DataListLoadRequest
				Return Blackbaud.AppFx.WebAPI.DataListServices.CreateDataListLoadRequest(provider, [DesignationsWithBBNCIDDataList].SpecId)
			End Function

			Public Shared Function GetRows(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal recordID As String) As DesignationsWithBBNCIDDataListRow()

				If String.IsNullOrEmpty(recordID) Then Throw New ArgumentException("recordID is required for this datalist.", "recordID")

				Dim request = CreateRequest(provider)

				request.ContextRecordID = recordID

				Return GetRows(provider, request)

			End Function

			Public Shared Function GetRows(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.DataListLoadRequest) As DesignationsWithBBNCIDDataListRow()
				Return bbAppFxWebAPI.DataListServices.GetListRows(Of [DesignationsWithBBNCIDDataListRow])(provider, _rowFactoryDelegate, request)
			End Function

		End Class

#Region "Row Data Class"

		<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
		<System.Serializable()> _
		Public NotInheritable Class [DesignationsWithBBNCIDDataListRow]


			Private [_DESIGNATIONID] As System.Guid
			Public Property [DESIGNATIONID] As System.Guid
				Get
					Return Me.[_DESIGNATIONID]
				End Get
				Set(ByVal value As System.Guid)
					Me.[_DESIGNATIONID] = value
				End Set
			End Property

			Private [_DESIGNATIONNAME] As String
			Public Property [DESIGNATIONNAME] As String
				Get
					Return Me.[_DESIGNATIONNAME]
				End Get
				Set(ByVal value As String)
					Me.[_DESIGNATIONNAME] = value
				End Set
			End Property

			Private [_BBNCID] As Integer
			Public Property [BBNCID] As Integer
				Get
					Return Me.[_BBNCID]
				End Get
				Set(ByVal value As Integer)
					Me.[_BBNCID] = value
				End Set
			End Property




			Public Sub New()
				MyBase.New()
			End Sub

			Friend Sub New(ByVal dataListRowValues() As String)

				Blackbaud.AppFx.WebAPI.DataListServices.ValidateDataListOutputColumnCount(2, dataListRowValues, DesignationsWithBBNCIDDataList.SpecId)

				Me.[_DESIGNATIONID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToGuid(dataListRowValues(0))

				Me.[_DESIGNATIONNAME] = dataListRowValues(1)

				Me.[_BBNCID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToInt(dataListRowValues(2))



			End Sub

		End Class

#End Region



	End Namespace

End Namespace


