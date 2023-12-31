﻿<%@ Page Title="Servicios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="SistemaInventario.Maestros.Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script> 
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"  src="Servicios.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" /> 
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />   
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titulo" >Servicios</div> 
                        <div id="divTabs">
                        <ul>
                            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
                        </ul>

                        <div id="tabRegistro">
                               <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 640px">
                                   <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                    REGISTRO DE Servicios
                                   </div>
                           
                                   <div >  
                                         <table  cellpadding="0" cellspacing="0" class="form-inputs">
                                            <tr>
                                        <td style="font-weight: bold; width: 120">
                                            Codigo
                                        </td>
                                        <td>
                                                        <asp:TextBox ID="txtCodigo" runat="server" Width="244px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>                            
                                    </tr>

                                            <tr>

                                     <td   style="font-weight: bold">
                                            Descripcion
                                     </td>

                                    
                                      <td>
                                        <asp:TextBox ID="txtDescripcion" runat="server" Width="549px" Font-Names="Arial"  
                                              ForeColor="Blue"  Font-Bold="True"  TextMode="MultiLine" Height="132px"></asp:TextBox>
                                     </td>
                                                                         
                                     </tr>                               
                                   
                                        </table>
                             
                            </div>     
                                 <div class="linea-button">
                                      <asp:Button ID="btnGrabar" runat="server" Text="Grabar"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial"  Font-Bold="True"    Width="120px"   />
                                  </div>
                               
                        </div>

                        </div>

                        <div id="tabConsulta">
                            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                        
                                       <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                                 Criterio de busqueda
                                        </div>
                                        
                                        <div class="ui-jqdialog-content">
                                       <div class="ui-jqdialog-content">
                                        <table cellpadding="0" cellspacing="0" class="form-inputs" >
                                        <tr>
                                             <td style="font-weight: bold" >
                                               Descripcion
                                             </td>

                                             <td>
                                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="647" Font-Names="Arial"  ForeColor="Blue" Font-Bold="True"  ></asp:TextBox>
                                             </td>

                                        </tr>

                                        </table>
                                                      
                            </div>

                               <div class="linea-button">
                                       <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar"  
                                            CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                                    Font-Names="Arial"  Width="120"   />
                                  </div>
                                                      
                            </div>

                              
                        </div>
                          <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblNumeroConsulta">0</label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
                        <div id="div_consulta" style="padding-top:5PX;">
                                                    <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" 
                                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                            Width="1005px" >
                                            
                                                <Columns>
                                                 
                                                    <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" id="imgAnularDocumento" ImageUrl="../Asset/images/EliminarBtn.png" ToolTip="Eliminar Servicio" OnClientClick="F_AnularRegistro(this); return false;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                    <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" id="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif" ToolTip="Editar Servicio" OnClientClick="F_EditarRegistro(this); return false;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Codigo" HeaderStyle-HorizontalAlign ="Center" >
                                                        <ItemStyle HorizontalAlign="left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>' CssClass="detallesart"></asp:Label>
                                                             <asp:HiddenField ID="lblID" runat="server" Value='<%# Bind("ID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                        
                                                </Columns>

                                            </asp:GridView>
                                    
                                    </div>
                      </div>  

                      </div>

                        <div id="divEdicionRegistro" style="display:none;">
                           
                                  <div class="ui-jqdialog-content">
                                   <table  cellpadding="0" cellspacing="0" class="form-inputs">
                                        <tr>

                                     <td  style="font-weight: bold">
                                            Codigo
                                     </td>

                                       <td style="padding-left:4px;" >
                                        <asp:TextBox ID="txtCodigoEdicion" runat="server" Width="120px" Font-Names="Arial"  
                                              ForeColor="Blue"  Font-Bold="True"></asp:TextBox>
                                                                                
                                     </td>

                                     </tr>
                                
                                        <tr>
                                                                
                                 <td style="font-weight: bold">
                                   Descripcion
                                 </td>
                                                                    
                                 <td colspan='5'   style="padding-left:4px;">
                                   <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="549px" Font-Names="Arial"  
                                              ForeColor="Blue"  Font-Bold="True"  TextMode="MultiLine" Height="132px"  ></asp:TextBox>
                                 </td>

                                 </tr>
                                        <tr>
                                     <td colspan='6' align="right">
                                     <asp:Button ID="btnEdicion" runat="server" Text="Grabar"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial"  Width="120px"   />
                                     </td>
                                     </tr>
                                                                          
                                        </table>
                                    </div>
                                </div>

                        <div id="dlgWait" style="background-color:#CCE6FF; text-align:center; display:none;">
        <br /><br />
        <center><asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large" style="text-align:center"></asp:Label></center>
        <br />
        <center><img alt="Wait..." src="../Asset/images/ajax-loader2.gif"/></center>
    </div>  

     <input id="hfCodCtaCte" type="hidden"  value="0" />
     <input id="hfCodCtaCteConsulta" type="hidden"  value="0" />
     <input id="hfCodigoTemporal" type="hidden"  value="0" />
     <input id="hfCodProducto" type="hidden" value="0" />
     <input id="hfMoneda" type="hidden"  value="0" />
</asp:Content>
