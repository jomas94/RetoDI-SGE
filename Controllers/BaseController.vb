Imports System.Net
Imports System.Web.Http
Imports RetoDI_SGE.Alerts

Namespace Controllers
    Public Class BaseController
        'Inherits ApiController

        Public Sub Alert(message As String, notificationType As NotificationType)

            Dim msg As String = "<script language='javascript'>Swal.fire('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>"


            If Not IsNothing(HttpContext.Current.Session("notification")) Then
                HttpContext.Current.Session("notification") = msg
            End If

        End Sub

        Public Sub Message(message As String, notificationType As NotificationType)

            If Not IsNothing(HttpContext.Current.Session("notification")) Then
                HttpContext.Current.Session("notification2") = message
            End If

            Select Case notificationType
                Case notificationType.success
                    HttpContext.Current.Session("NotificationCSS") = "alert-box success"

                Case NotificationType.erro
                    HttpContext.Current.Session("NotificationCSS") = "alert-box errors"

                Case NotificationType.warning
                    HttpContext.Current.Session("NotificationCSS") = "alert-box warning"

                Case NotificationType.info
                    HttpContext.Current.Session("NotificationCSS") = "alert-box notice"

            End Select




        End Sub

    End Class
End Namespace