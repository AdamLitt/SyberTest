<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="SyberSystemsSurvey.DefaultPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Test Survey</h1>
    </div>
    <div class="TestForm">
       <asp:GridView ID="grd" runat="server" DataKeyNames="CircuitType" AutoGenerateColumns="false" OnRowDataBound="Grid_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Circuit Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtCircuitName" runat="server" Text='<%# Eval("CircuitName") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Resistance">
                <ItemTemplate>
                    <asp:TextBox ID="txtResistance" runat="server" Text='<%# Eval("Resistance") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Circuit Type">
                <ItemTemplate>
                    <asp:TextBox ID="txtCircuitType" runat="server" Text='<%# Eval("CircuitType") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Circuit Type">
                <ItemTemplate>
                    <asp:DropDownList runat="server" id="CircuitTypeId" DataSource='<%# GetCircuitTypes() %>' DataTextField="Text" DataValueField="Value"  />
                </ItemTemplate> 
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Passed">
                <ItemTemplate>
                    <asp:CheckBox ID="TestPass" runat="server" AutoPostBack="false" OnCheckedChanged="TestPass_CheckedChanged"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:Button ID="btnAddRow" runat="server" OnClick="btnAddRow_Click" Text="Add Row" />
    </div>

</asp:Content>
