﻿<%@ Page Title="管理帳戶" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Account_Manage" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<%@ Import Namespace="Microsoft.AspNet.Membership.OpenAuth" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <section id="passwordForm">
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="message-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>

        <p>您是以 <strong><%: User.Identity.Name %></strong> 身分登入。</p>

        <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
            <p>
                您沒有此站台的本機密碼。新增本機密碼，
                不需外部登入即可登入。
            </p>
            <fieldset>
                <legend>設定密碼表單</legend>
                <ol>
                    <li>
                        <asp:Label runat="server" AssociatedControlID="password">密碼</asp:Label>
                        <asp:TextBox runat="server" ID="password" TextMode="Password" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                            CssClass="field-validation-error" ErrorMessage="密碼欄位是必要欄位。"
                            Display="Dynamic" ValidationGroup="SetPassword" />
                        
                        <asp:Label runat="server" ID="newPasswordMessage" CssClass="field-validation-error"
                            AssociatedControlID="password" />
                        
                    </li>
                    <li>
                        <asp:Label runat="server" AssociatedControlID="confirmPassword">確認密碼</asp:Label>
                        <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                            CssClass="field-validation-error" Display="Dynamic" ErrorMessage="確認密碼欄位是必要欄位。"
                            ValidationGroup="SetPassword" />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                            CssClass="field-validation-error" Display="Dynamic" ErrorMessage="密碼和確認密碼不相符。"
                            ValidationGroup="SetPassword" />
                    </li>
                </ol>
                <asp:Button runat="server" Text="設定密碼" ValidationGroup="SetPassword" OnClick="setPassword_Click" />
            </fieldset>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
            <h3>變更密碼</h3>
            <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage.aspx?m=ChangePwdSuccess">
                <ChangePasswordTemplate>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                    <fieldset class="changePassword">
                        <legend>變更密碼詳細資料</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">目前密碼</asp:Label>
                                <asp:TextBox runat="server" ID="CurrentPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="field-validation-error" ErrorMessage="確認密碼欄位是必要欄位。" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">新密碼</asp:Label>
                                <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="field-validation-error" ErrorMessage="需要新密碼。" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">確認新密碼</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="需要確認新密碼。" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="新密碼與確認密碼不相符。" />
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="ChangePassword" Text="變更密碼" />
                    </fieldset>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </asp:PlaceHolder>
    </section>

    <section id="externalLoginsForm">
        
        <asp:ListView runat="server" ID="externalLoginsList" ViewStateMode="Disabled"
            DataKeyNames="ProviderName,ProviderUserId" OnItemDeleting="externalLoginsList_ItemDeleting">
        
            <LayoutTemplate>
                <h3>註冊的外部登入</h3>
                <table>
                    <thead><tr><th>服務</th><th>使用者名稱</th><th>上次使用</th><th>&nbsp;</th></tr></thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    
                    <td><%# HttpUtility.HtmlEncode(Item<OpenAuthAccountData>().ProviderDisplayName) %></td>
                    <td><%# HttpUtility.HtmlEncode(Item<OpenAuthAccountData>().ProviderUserName) %></td>
                    <td><%# HttpUtility.HtmlEncode(ConvertToDisplayDateTime(Item<OpenAuthAccountData>().LastUsedUtc)) %></td>
                    <td>
                        <asp:Button runat="server" Text="移除" CommandName="Delete" CausesValidation="false" 
                            ToolTip='<%# "從您的帳戶" + Item<OpenAuthAccountData>().ProviderDisplayName + "移除此登入" %>'
                            Visible="<%# CanRemoveExternalLogins %>" />
                    </td>
                    
                </tr>
            </ItemTemplate>
        </asp:ListView>

        <h3>新增外部登入</h3>
        <uc:OpenAuthProviders runat="server" ReturnUrl="~/Account/Manage.aspx" />
    </section>
</asp:Content>
