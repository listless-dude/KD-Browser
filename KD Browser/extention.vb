Imports System.Net
Public Class extention
    Inherits WebClient
    Friend lastHttpWebRequest As HttpWebRequest
    Friend lastHttpWebResponse As HttpWebResponse
    Friend referer As String
    Friend cookieJar As CookieContainer = New CookieContainer
    Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest
        Dim webRequest As WebRequest = MyBase.GetWebRequest(address)
        lastHttpWebRequest = TryCast(webRequest, HttpWebRequest)
        If lastHttpWebRequest IsNot Nothing Then
            lastHttpWebRequest.CookieContainer = cookieJar
            lastHttpWebRequest.Referer = referer
        End If
        Return webRequest
    End Function
    Protected Overrides Function GetWebResponse(ByVal request As WebRequest) As WebResponse
        Dim webResponse As WebResponse = MyBase.GetWebResponse(request)
        lastHttpWebResponse = TryCast(webResponse, HttpWebResponse)
        If lastHttpWebResponse IsNot Nothing Then
            cookieJar.Add(lastHttpWebResponse.Cookies)
            referer = lastHttpWebResponse.ResponseUri.ToString
        End If
        Return webResponse
    End Function
End Class
