﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Collections;
using System.Configuration;
using CapaNegocios;
using CapaEntidad;
using System.Web.Services;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;

namespace SistemaInventario.Maestros
{
    public partial class MantenimientoSerie : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Mostrar_Correlativo_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_Mostrar_Serie_NET);
        }

        private string _menu = "1000"; private string _opcion = "6";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            //if (Menu == null | (_menu != Menu | _opcion != Opcion) | Utilitarios.Menu.F_PermisoOpcion(_menu, _opcion) == false)
            //{
            //    Response.Redirect("../Maestros/TipoCambio.aspx");
            //    return;
            //}
            //Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            Session["datos"] = true;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_documento_html = "";
            String str_ddl_igv_html = "";
            String str_numerofactura = "";

            decimal TC = 0;
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Controles_Inicializar(obj_parametros, ref ddlSerie, ref ddlDocumento);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddl_documento_html = Mod_Utilitario.F_GetHtmlForControl(ddlDocumento);
         
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_ddl_serie_html
                + "~" +
                str_ddl_documento_html
                   + "~" +
                TC.ToString()
                  + "~" +
                str_numerofactura
                  + "~" +
                str_ddl_igv_html;

            return str_resultado;
        }

        public String F_Mostrar_Correlativo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numero = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numero);
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_numero;

            return str_resultado;
        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref str_mensaje_operacion);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_numerofactura;
            
            return str_resultado;
        }

        public String F_TipoCambio_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Decimal TipoCambio = 0;
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_TipoCambio(obj_parametros, ref TipoCambio);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                TipoCambio.ToString();
            
            return str_resultado;
        }

        public String F_Mostrar_Serie_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlserie_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Mostrar_Serie(obj_parametros, ref ddlSerie);
                str_ddlserie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_ddlserie_html;

            return str_resultado;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_comboserie,
                                            ref DropDownList ddl_combodocumento)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = 1;
            objEntidad.CodEstado = 1;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserie.Items.Clear();

            ddl_comboserie.DataSource = dta_consulta;
            ddl_comboserie.DataTextField = "SerieDoc";
            ddl_comboserie.DataValueField = "CodSerie";
            ddl_comboserie.DataBind();

            TCDocumentosCN objOperacionDocumentos = null;
            objOperacionDocumentos = new TCDocumentosCN();
            dta_consulta = null;
            dta_consulta = objOperacionDocumentos.F_TCDocumentos_ListarVentas();

            ddl_combodocumento.Items.Clear();

            ddl_combodocumento.DataSource = dta_consulta;
            ddl_combodocumento.DataTextField = "Descripcion";
            ddl_combodocumento.DataValueField = "CodTipoDoc";
            ddl_combodocumento.DataBind();                     
        }

        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio)
        {
            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            DataTable dta_consulta = null;
            
            objEntidad = new TCTipoCambioCE();

            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new TCTipoCambioCN();

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);
        }

        public void P_Obtener_NumeroCorrelativo(Hashtable objTablaFiltro, ref String Numero)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodEmpresa = 3;
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Numero_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                Numero = Convert.ToString(dta_consulta.Rows[0]["NumeroDoc"]);
        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            objEntidad = new TCCorrelativoCE();
            int iCodEmpresa = 3;

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.FechaRegistro = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            objOperacion = new TCCorrelativoCN();

            objOperacion.F_TCCorrelativo_Edicion(objEntidad);

            MsgError = objEntidad.MsgError;            
        }

        public void P_TipoCambio(Hashtable objTablaFiltro, ref Decimal TC)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            objEntidad = new TCTipoCambioCE();
            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);

            objOperacion = new TCTipoCambioCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count == 0)
                TC = 0;
            else
                TC = Convert.ToDecimal(dta_consulta.Rows[0][0]);


        }

        public void P_Mostrar_Serie(Hashtable objTablaFiltro, ref DropDownList comboserie)
        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;
            int iCodEmpresa = 3;
            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodEstado = 1;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            comboserie.Items.Clear();

            comboserie.DataSource = dta_consulta;
            comboserie.DataTextField = "SerieDoc";
            comboserie.DataValueField = "CodSerie";
            comboserie.DataBind();

        }

    }
}